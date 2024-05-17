using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleEntree : MonoBehaviour, Interactible
{
    [SerializeField] private CodeOrdinateur ordinateur; //Permet l'interaction avec le bouton Entr�e de l'ordinateur de l'infirmerie afin d'envoyer la r�ponse

    public void BoutonPresse()
    {
        if (!ordinateur.IsReponseTrouvee()) // Si la r�ponse a �t� trouv�e, le joueur ne peut plus interagir avec le bouton Entr�e
        {
            ordinateur.Execute();
        }

    }

    public void InteractionDroite(Transform Joueur)
    {
        //Rien pour l'Instant              
    }
    public void InteractionGauche(Transform Joueur)
    {
        BoutonPresse();
    }
}
