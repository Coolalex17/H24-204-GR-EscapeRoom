using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMenuOption : MonoBehaviour
{
    public void modifierSliderSensibilitee(float sensibilitee)
    {
        PreferencesJoueur.ModifierSensibiliteeCamera(sensibilitee);
    }
    public void RetourScene()
    {   //Definitivement pas la bonne facon de faire
        SceneManager.LoadScene(1);
    }


}
