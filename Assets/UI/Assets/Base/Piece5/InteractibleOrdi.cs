using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleOrdi : MonoBehaviour, Interactible //Permet l'interaction avec les boutons du clavier de l'ordinateur de l'infirmerie
{
    [SerializeField] private CodeOrdinateur ordinateur;
    public int nombre;


    public void BoutonPresse()
    {
        if (!ordinateur.IsReponseTrouvee()) // Si la réponse a été trouvée, le joueur ne peut plus interagir avec les boutons du clavier
        {
            ordinateur.Nombre(nombre);
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
