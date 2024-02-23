using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{
    private readonly float VITESSE_MARCHE = 3f;
    private readonly float VITESSE_COURSE = 4f;
    private readonly float ACCELERATION = 2f;
    [SerializeField] private Rigidbody Joueur;
    [SerializeField] private Camera CameraJoueur;
    
    
    
    void Start()
    {
        
    }
   
    void FixedUpdate()
    {
        BoujerJoueur();
    }
    private float ObtenirVitesseMax()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))//Retourne la vitesse maximale du joueur selon letat de la touche sprint
        {//Modifier la touche qui sera utiliser afin dutiliser le input manager correctement
            return VITESSE_COURSE;
        }
        return VITESSE_MARCHE;

    }
    private Vector3 OrienterMouvementSelondDirectionCamera;
    private void BoujerJoueur()//Va bouger le joueur selon les touches selon la direction que le joueur a choisis 
    {
        //Transforme les Inputs du joueur en vecteur
        Vector3 DirectionMouvement = new Vector3();
        DirectionMouvement.x = Input.GetAxis("Horizontal");
        DirectionMouvement.z = Input.GetAxis("Vertical");

        if (DirectionMouvement.x == 0 && DirectionMouvement.z == 0)
        {
            Joueur.velocity = Vector3.zero;
            Joueur.angularVelocity = Vector3.zero;
        }
        else
        {



            //Normalize le vecteur mouvement
            DirectionMouvement = DirectionMouvement.normalized;



            //Decide la direction finale du joueur
            DirectionMouvement = Joueur.transform.TransformDirection(DirectionMouvement.x, 0, DirectionMouvement.z);


            //ajoute la nouvelle vitesse au joueur
            Joueur.velocity += DirectionMouvement * ACCELERATION;

            //Limite la vitesse du joueur
            Joueur.velocity = Vector3.ClampMagnitude(Joueur.velocity, ObtenirVitesseMax());

        }



        


    }

}
