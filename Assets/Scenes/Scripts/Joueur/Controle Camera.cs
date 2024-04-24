using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class ControleCamera : MonoBehaviour
{
    [SerializeField] private Camera CameraJoueur;
    [SerializeField] private Transform Joueur;
    private float RotationVerticale = 0;

    //Distance maximale avec lequel le joueur pourr
    private readonly float DISTANCE_INTERACTION = 10;
    //Image du point au milieu de lecran pour aider le joueur a viser les objets
    [SerializeField] private RawImage imageCurseur;
    //Determine si le joueur peut bouger la camera et interargir avec lenvironnement
    private bool cameraPermise;

    void Start()
    {
        partirCamera();
    }
    private void Update(){
        if (cameraPermise)
        {
            VerifierInteraction();
            bougerCamera();
        }

    }
    /// <summary>
    /// Verifie a chaque frame si le joueur regarde un objet avec lequel il peut interargir et si le joueur clic avec sa souris, appelle bonne la metode 
    /// </summary>
    private void VerifierInteraction(){
        RaycastHit Hit;
        
        if (Physics.Raycast(CameraJoueur.transform.position, CameraJoueur.transform.TransformDirection(Vector3.forward) * DISTANCE_INTERACTION, out Hit) && Hit.transform.GetComponent<Interactible>() != null){
            if(imageCurseur != null){
                imageCurseur.color = new Color32(45, 109, 0, 255);
            }
            if (Input.GetMouseButtonDown(0)){
                Hit.transform.GetComponent<Interactible>().InteractionGauche(Joueur);
            }
            else if (Input.GetMouseButtonDown(1)){
                Hit.transform.GetComponent<Interactible>().InteractionDroite(Joueur);
            }
        }else{
            if (imageCurseur != null){//Modifie la couleur du curseur si le joueur ne regarde pas un objet avec lequel il peut interargir
                imageCurseur.color = new Color32(181, 181, 181, 255);
            }
        }
    }
    private void bougerCamera(){//Bouge la camera a une vitesse qui depend de la sensibilitee de la camera
        //TODO la sensibilitee depend du script preferenceJoueur qui doit etre enleve il faut donc modifier la reference en consequent
        RotationVerticale += Input.GetAxis("Mouse Y") * -PreferencesJoueur.ObtenirSensibiliteeCamera() * Time.deltaTime;
        RotationVerticale = Mathf.Clamp(RotationVerticale, -100, 100);

        Joueur.transform.Rotate(Vector3.down * Input.GetAxis("Mouse X") * -PreferencesJoueur.ObtenirSensibiliteeCamera() * Time.deltaTime);

        transform.localRotation = Quaternion.Euler(RotationVerticale, 0f, 0f);
    }
    public void stopperCamera(){//Est utilise lorsque lutilisateur est dans un menu ou a besoin de se servir de sa souris
        cameraPermise = false;
        Cursor.lockState = CursorLockMode.Confined;
        imageCurseur.color = new Color(0,0,0,0);
    }
    public void partirCamera(){//Est utilise lorsque lutilisateur quitte un menu ou na plus besoin de se servir de sa souris
        Cursor.lockState = CursorLockMode.Locked;
        cameraPermise = true;
        imageCurseur.color = new Color32(45, 109, 0, 255);
    }
}
