using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PreferencesJoueur
{
    private static float SensibiliteeCamera = 100;
    private static Vector3 SavedPlayerPosition;
    private static Inventaire SavedInventaire;
    private static float TempsPartie;
    private static int ScenePrecedente;
    private static bool FiniJeuEchec = false;
    
    public static bool getFiniJeuEchec() {
        return FiniJeuEchec;
    }
    public static void FinirJeuEchec() {
        FiniJeuEchec=true;
    }
    
    public static int getScenePrecedente() { return ScenePrecedente; }
    public static void AssigneScenePrecedente(int scene) {  ScenePrecedente = scene; }

    public static float getTempsPartie() {
        return TempsPartie;
    }
    public static void SaveTempsPartie(float temps) {
        TempsPartie = temps;
    }
    public static Vector3 GetSavedPLayerPosition() {
        if (SavedPlayerPosition == null) { 
            SavedPlayerPosition = new Vector3(0,2.5f,-7);
        }
        return SavedPlayerPosition;
    }
    public static Inventaire GetSavedInventaire() {
        if (SavedInventaire == null) {
            SavedInventaire = new Inventaire();
        }
        return SavedInventaire;
    }
    public static void SavePosition(Vector3 position) {
        SavedPlayerPosition = position;
    }
    public static void SaveInventaire(Inventaire inventaire) {
        SavedInventaire = inventaire;
    }



    public static float ObtenirSensibiliteeCamera()
    {
        return SensibiliteeCamera;
    }
    public static void ModifierSensibiliteeCamera(float sensibilitee)
    {
        SensibiliteeCamera = Mathf.Max(0, 100f, sensibilitee);
    }

}
