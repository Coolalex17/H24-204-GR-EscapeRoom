using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Inventaire;

public class ControlerHud : MonoBehaviour
{
    [SerializeField] private UIDocument HUDJoueur;

    private Label Timer;
    private double TempsEcoule;

    private GroupBox ContenantInventaire;
    [SerializeField] private Inventaire InventaireJoueur;
    void Start()
    {
        Timer = HUDJoueur.rootVisualElement.Q<Label>("Timer");
        TempsEcoule = 0;//TODO prendre le temps du fichier de sauvegarde

        ContenantInventaire = HUDJoueur.rootVisualElement.Q<GroupBox>("ContenantInventaire");
    }
    void Update()
    {
        ContenantInventaire.Add(new Label { text = "Test" });
        TempsEcoule += Time.deltaTime;
        Timer.text = ( (int)TempsEcoule ).ToString();
        afficherInventaire();
    }
    private void afficherInventaire()
    {
        ContenantInventaire.Clear();
        Items[] InventaireTemp = InventaireJoueur.ObtenirInventaire().ToArray();

        for (int i = 0;i < InventaireTemp.Length;i++)
        {
            Image ImageTemp = new Image();
            ImageTemp.image = InventaireJoueur.ObtenirImage(InventaireTemp[i]);
            ContenantInventaire.Add(ImageTemp);

        }

    }

}
