using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntreactibleKeypad : MonoBehaviour, Interactible
{
    [SerializeField] private Keypad keypad;
    public int nombre;
    public void boutonPresse()
    {
        if (!keypad.IsReponseTrouvee()) { 
        keypad.Nombre(nombre);
        }
    }

    public void InteractionDroite(Transform Joueur)
    {
      //Rien pour l'Instant              
    }
    public void InteractionGauche(Transform Joueur)
    {
        boutonPresse();            
    }
}
