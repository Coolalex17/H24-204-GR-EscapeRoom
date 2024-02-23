using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Camera CameraJoueur;
    [SerializeField] private Transform Joueur;
    private float RotationVerticale = 0;
    private readonly float DISTANCE_INTERACTION = 10;

    void Start()
    {
        //Centre et cache le curseur du joueur
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit HitGauche;

            if (Physics.Raycast(CameraJoueur.transform.position, CameraJoueur.transform.TransformDirection(Vector3.forward) * DISTANCE_INTERACTION, out HitGauche))
            {
                if (HitGauche.transform.GetComponent<Interactible>() != null)
                {
                    HitGauche.transform.GetComponent<Interactible>().InteractionGauche(Joueur);
                }

            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("RightCLik");
            RaycastHit HitDroit;
            if (Physics.Raycast(CameraJoueur.transform.position, CameraJoueur.transform.TransformDirection(Vector3.forward) * DISTANCE_INTERACTION, out HitDroit))
            {
                if (HitDroit.transform.GetComponent<Interactible>() != null)
                {
                    HitDroit.transform.GetComponent<Interactible>().InteractionDroite(Joueur);

                }
            }
        }

    }
    void FixedUpdate()
    {

        RotationVerticale += Input.GetAxis("Mouse Y") * -PreferencesJoueur.ObtenirSensibiliteeCamera();
        RotationVerticale = Mathf.Clamp(RotationVerticale, -100, 100);

        Joueur.transform.Rotate(Vector3.down * Input.GetAxis("Mouse X") * -PreferencesJoueur.ObtenirSensibiliteeCamera());


        transform.localRotation = Quaternion.Euler(RotationVerticale,0f, 0f);


    }
}
