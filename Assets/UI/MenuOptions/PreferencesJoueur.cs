using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PreferencesJoueur
{
    private static float SensibiliteeCamera = 10;
    public static float ObtenirSensibiliteeCamera()
    {
        return SensibiliteeCamera;
    }
    public static void ModifierSensibiliteeCamera(float sensibilitee)
    {
        SensibiliteeCamera = Mathf.Max(0, 1f, sensibilitee);
    }

}
