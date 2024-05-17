using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleEntree : MonoBehaviour, Interactible
{
    [SerializeField] private CodeOrdinateur ordinateur; //Permet l'interaction avec le bouton Entrée de l'ordinateur de l'infirmerie afin d'envoyer la réponse

    public void BoutonPresse()
    {
        if (!ordinateur.IsReponseTrouvee()) // Si la réponse a été trouvée, le joueur ne peut plus interagir avec le bouton Entrée
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
