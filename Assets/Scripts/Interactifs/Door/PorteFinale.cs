using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PorteFinale : MonoBehaviour, Interactible
{
    private static bool CadenaRouge = false;
    private static bool CadenaVert = false;
    private static bool CadenaBleu = false;
    [SerializeField] GameObject ImageCadenaRouge;
    [SerializeField] GameObject ImageCadenaVert;
    [SerializeField] GameObject ImageCadenaBleu;

    public void InteractionDroite(Transform Joueur) {
        //pas utile presentement
    }
    public void Start() {
        if(CadenaRouge) {
            ImageCadenaRouge.SetActive(false);
        } 
        if(CadenaVert) {
            ImageCadenaVert.SetActive(false);
        }
        if(CadenaBleu) {
           ImageCadenaBleu.SetActive(false);
        }
    }
    //Load la scène de fin de jeu
    public void InteractionGauche(Transform Joueur) {
        if(Joueur.GetComponent<Inventaire>().EnleverItem(Inventaire.Items.CLEE_BLEU,1)) {
            CadenaBleu = true;
            
        }
        if (Joueur.GetComponent<Inventaire>().EnleverItem(Inventaire.Items.CLEE_ROUGE, 1)) {
            CadenaRouge = true;        
        }
        if (Joueur.GetComponent<Inventaire>().EnleverItem(Inventaire.Items.CLEE_VERTE, 1)) {
            CadenaVert =true;
        }
        Debug.Log(CadenaVert);
        Debug.Log(CadenaBleu);
        Debug.Log(CadenaRouge);
        if(CadenaBleu & CadenaVert & CadenaRouge) {
            Debug.Log("FiniJeu");
        }

        Start();
    }
}
