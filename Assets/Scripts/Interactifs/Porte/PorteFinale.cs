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
    [SerializeField] GameObject ImageFin;

    public void InteractionDroite(Transform Joueur) {
        //pas utile presentement
    }
    /// <summary>
    /// Enl�ve les cadena qui ont d�ja �t� enlev� par le joueur lorsque la scene est charg�
    /// </summary>
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

    /// <summary>
    /// enl�ve les cadenas selon la clee que le joueur pessede
    /// </summary>
    /// <param name="Joueur"></param>
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
        if(CadenaBleu & CadenaVert & CadenaRouge) {
            //Affiche le message de f�licitations
            ImageFin.SetActive(true);
        }

        Start();
    }
}
