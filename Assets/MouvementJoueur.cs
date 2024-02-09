using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{
    // Start is called before the first frame update
    private readonly float VITESSE_MARCHE = 3f;
    private readonly float VITESSE_COURSE = 4f;
    private readonly float ACCELERATION = 2f;
    [SerializeField] private Rigidbody Joueur;
    [SerializeField] private Camera CameraJoueur;
    
    
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        BoujerJoueur();
    }
    private float ObtenirVitesseMax()
    {//Retourne la vitesse maximale du joueur selon letat de la touche sprint


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {//Modifier la touche qui sera utiliser afin dutiliser le input manager correctement
            return VITESSE_COURSE;
        }
        return VITESSE_MARCHE;

    }
    private Vector3 OrienterMouvementSelondDirectionCamera;
    private void BoujerJoueur()//Va bouger le joueur selon les touches selon la direction que le joueur a choisis 
    {
        Vector3 DirectionMouvement = new Vector3();
        DirectionMouvement.x = Input.GetAxis("Horizontal");
        DirectionMouvement.z = Input.GetAxis("Vertical");


        //Decide la direction finale du joueur
      //  DirectionMouvement = Quaternion.EulerRotation(Camera.);

        //ajoute la nouvelle vitesse au joueur
        Joueur.velocity = Joueur.velocity + DirectionMouvement * ACCELERATION;

        //Limite la vitesse du joueur
        Joueur.velocity = Vector3.ClampMagnitude(Joueur.velocity,ObtenirVitesseMax());
        


    }

}
