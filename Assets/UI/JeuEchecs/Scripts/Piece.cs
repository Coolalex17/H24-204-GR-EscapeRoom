using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    public GameObject controlleur;
    public GameObject grilleDeplacements;

    // Positions
    private int xGrille = -1;
    private int yGrille = -1;

    // Couleur de la pièce du joueur
    private string joueur;

    // References pour tous les sprites
    public Sprite roi_noir, dame_noir, tour_noir, fou_noir, cavalier_noir, pion_noir;
    public Sprite roi_blanc, dame_blanc, tour_blanc, fou_blanc, cavalier_blanc, pion_blanc;

    // 
    public void Activer()
    {
        controlleur = GameObject.FindGameObjectWithTag
    }
}
