using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Camera CameraJoueur;
    [SerializeField] private Transform Joueur;
    private float sensitivite = 1;
    private float RotationVerticale = 0;
    private readonly float DISTANCE_INTERACTION = 10;

    void Start()
    {
        //Centre et cache le curseur du joueur
        Cursor.lockState = CursorLockMode.Locked;

    }
    void FixedUpdate()
    {

        RotationVerticale += Input.GetAxis("Mouse Y") * -sensitivite;
        RotationVerticale = Mathf.Clamp(RotationVerticale, -100, 100);

        Joueur.transform.Rotate(Vector3.down * Input.GetAxis("Mouse X") * -sensitivite);


        transform.localRotation = Quaternion.Euler(RotationVerticale,0f, 0f);

        if(Input.GetMouseButtonDown(0)) {
            RaycastHit HitGauche;
            
            if(Physics.Raycast(CameraJoueur.transform.position,CameraJoueur.transform.TransformDirection(Vector3.forward) * DISTANCE_INTERACTION,out HitGauche)) {
                if(HitGauche.transform.GetComponent<Interactible>() != null) {
                    HitGauche.transform.GetComponent<Interactible>().InteractionGauche();
                }

            }
        }
        if(Input.GetMouseButtonDown(1)) {
            RaycastHit HitDroit;
            Debug.DrawRay(CameraJoueur.transform.position, CameraJoueur.transform.TransformDirection(Vector3.forward) * DISTANCE_INTERACTION);
            if (Physics.Raycast(CameraJoueur.transform.position, CameraJoueur.transform.TransformDirection(Vector3.forward) * DISTANCE_INTERACTION,out HitDroit)) {
                if(HitDroit.transform.GetComponent<Interactible>() != null) {
                   HitDroit.transform.GetComponent<Interactible>().InteractionDroite();

                }
            }
        }

    }
}
