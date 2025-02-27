using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PreferencesJoueur
{
    private static float SensibiliteeCamera = 100;
    private static Vector3 SavedPlayerPosition = new Vector3(0, 3f, -7);
    private static List<Inventaire.Items> SavedInventaire;
    private static float TempsPartie;
    private static int ScenePrecedente;
    private static bool FiniJeuEchec = false;
    private static bool FiniJeuCalcul = false;
    private static bool FiniJeuDrapeaux = false;
    private static bool FiniJeuSoccer = false;
    private static bool FiniJeuPhysique = false;
    private static bool FiniJeuDrapeau = false;

    public static bool getFiniJeuDrapeau() {
        return FiniJeuDrapeau;
    }
    public static void FinirJeuDrapeau() {
        FiniJeuDrapeau = true;
    }


    public static bool getFiniJeuPhysique() {
        return FiniJeuPhysique;
    }
    public static void FinirJeuPhysique() {
        FiniJeuPhysique = true;
    }
    public static bool getFiniJeuSoccer() {
        return FiniJeuSoccer;
    }
    public static void FinirJeuSoccer() {
        FiniJeuSoccer = true;
    }

    public static bool getFiniJeuEchec() {
        return FiniJeuEchec;
    }
    public static void FinirJeuEchec() {
        FiniJeuEchec=true;
    }
    public static bool getFiniJeuCalcul()
    {
        return FiniJeuCalcul;
    }
    public static void FinirJeuCalcul()
    {
        FiniJeuCalcul = true;
    }

    public static bool getFiniJeuDrapeaux()
    {
        return FiniJeuDrapeaux;
    }
    public static void FinirJeuDrapeaux()
    {
        FiniJeuDrapeaux = true;
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
        return SavedPlayerPosition;
    }
    public static List<Inventaire.Items> GetSavedInventaire() {
        if (SavedInventaire == null) {
            SavedInventaire = new List<Inventaire.Items>();
        }
        return SavedInventaire;
    }
    public static void SavePosition(Vector3 position) {
        SavedPlayerPosition = position;
    }
    public static void SaveInventaire(Inventaire inventaire) {
        SavedInventaire = inventaire.ObtenirInventaire();
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
