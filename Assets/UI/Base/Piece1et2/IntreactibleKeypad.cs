using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntreactibleKeypad : MonoBehaviour, Interactible
{
    [SerializeField] private Keypad keypad;
    public int nombre;
    public void boutonPresse()
    {
        keypad.Nombre(nombre);
        Debug.Log("Button pressed!");
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
