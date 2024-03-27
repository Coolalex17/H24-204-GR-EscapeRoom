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
    private readonly float DISTANCE_INTERACTION = 10;
    [SerializeField] private RawImage imageCurseur;
    private bool cameraPermise;

    void Start()
    {
        partirCamera();
    }
    private void Update()
    {
        if (cameraPermise)
        {
            VerifierInteraction();
        }

    }
    private void VerifierInteraction()
    {
        RaycastHit Hit;

        if (Physics.Raycast(CameraJoueur.transform.position, CameraJoueur.transform.TransformDirection(Vector3.forward) * DISTANCE_INTERACTION, out Hit) && Hit.transform.GetComponent<Interactible>() != null)
        {
            if(imageCurseur != null)
            {
                imageCurseur.color = new Color32(45, 109, 0, 255);
            }

            if (Input.GetMouseButtonDown(0))
            {
                Hit.transform.GetComponent<Interactible>().InteractionGauche(Joueur);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Hit.transform.GetComponent<Interactible>().InteractionDroite(Joueur);

            }
        }
        else
        {
            if (imageCurseur != null)
            {
                imageCurseur.color = new Color32(181, 181, 181, 255);
            }

        }
    }
    private void bougerCamera()
    {

        RotationVerticale += Input.GetAxis("Mouse Y") * -PreferencesJoueur.ObtenirSensibiliteeCamera();
        RotationVerticale = Mathf.Clamp(RotationVerticale, -100, 100);

        Joueur.transform.Rotate(Vector3.down * Input.GetAxis("Mouse X") * -PreferencesJoueur.ObtenirSensibiliteeCamera());


        transform.localRotation = Quaternion.Euler(RotationVerticale, 0f, 0f);
    }
    void FixedUpdate()
    {
        if (cameraPermise)
        {
            bougerCamera();
        }


    }
    public void stopperCamera()
    {
        cameraPermise = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void partirCamera()
    {
        //Centre et cache le curseur du joueur
        Cursor.lockState = CursorLockMode.Locked;
        cameraPermise = true;
    }
}
