using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleJeuPhysique : MonoBehaviour, Interactible
{
        //Le jeu qui va etre demaree lorsque lutilisateur appuie sur 
        [SerializeField] private ControleurJeuPhysique jeuPhysique;

        public void InteractionDroite(Transform Joueur)
        {
            //pas utile presentement
        }

        //Appelle la metode du jeu de physique qui demare le jeu
        public void InteractionGauche(Transform Joueur)
        {
        if (PreferencesJoueur.getFiniJeuPhysique()) {
            return;
        }
        jeuPhysique.debuterJeu(Joueur.GetComponent<MouvementJoueur>());
        }

    
}

