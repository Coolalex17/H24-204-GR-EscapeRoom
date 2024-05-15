using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleKeypadExecuter : MonoBehaviour, Interactible
{

    [SerializeField] private Keypad keypad;

    public void boutonPresse()
    {
        if (!keypad.IsReponseTrouvee())
        {
            keypad.Execute();
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
