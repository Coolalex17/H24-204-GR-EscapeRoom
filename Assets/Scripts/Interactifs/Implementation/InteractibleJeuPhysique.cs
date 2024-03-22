using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleJeuPhysique : MonoBehaviour, Interactible
{
        [SerializeField] private ControleurJeuPhysique jeuPhysique;

        public void InteractionDroite(Transform Joueur)
        {
            
        }

        public void InteractionGauche(Transform Joueur)
        {
        jeuPhysique.debuterJeu(Joueur.GetComponent<MouvementJoueur>());
        }

    
}

