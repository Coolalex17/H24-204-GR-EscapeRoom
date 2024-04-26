using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{
    private readonly float VITESSE = 5f;
    private readonly float ACCELERATION = 2f;
    [SerializeField] private Rigidbody Joueur;
    [SerializeField] private Camera cameraJoueur;
    private bool mouvementPermi;
    
    
    void Start(){
        mouvementPermi = true;
    }
   
    void FixedUpdate(){
        if (mouvementPermi){
            BoujerJoueur();
        }
    }
    public void StopperMouvement() { 
        mouvementPermi=false;
        Joueur.velocity = Vector3.zero;
        cameraJoueur.GetComponent<ControleCamera>().stopperCamera();
    }
    public void demarerJoueur(){
        mouvementPermi = true;
        cameraJoueur.GetComponent<ControleCamera>().partirCamera();
    }
    private void BoujerJoueur(){//Va bouger le joueur selon les touches selon la direction que le joueur a choisis 

        //Transforme les Inputs du joueur en vecteur
        Vector3 DirectionMouvement = new Vector3();
        DirectionMouvement.x = Input.GetAxisRaw("Horizontal");
        DirectionMouvement.z = Input.GetAxisRaw("Vertical");

        if (DirectionMouvement.x == 0 && DirectionMouvement.z == 0){//arrete le mouvement du joueur si il ne veut pas bouger
            Joueur.velocity = Vector3.zero;
            Joueur.angularVelocity = Vector3.zero;
        }else{
            //Normalize le vecteur mouvement
            DirectionMouvement = DirectionMouvement.normalized;
            //Decide la direction finale du joueur
            DirectionMouvement = Joueur.transform.TransformDirection(DirectionMouvement.x, 0, DirectionMouvement.z);
            //ajoute la nouvelle vitesse au joueur
            Joueur.velocity += DirectionMouvement * ACCELERATION;
            //Limite la vitesse du joueur
            Joueur.velocity = Vector3.ClampMagnitude(Joueur.velocity,  VITESSE);

        }
    }
}
