using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{

    public GameObject pieceDeJeu;

    // Positions et couleur de chaque pièce
    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] joueurBlanc = new GameObject[16];
    private GameObject[] joueurNoir = new GameObject[16];

    private string joueurCourrant = "blanc";

    private bool finDuJeu = false;


    void Start()
    {
        // Remplir tableaux des couleurs des joueurs avec leurs pièces
        joueurBlanc = new GameObject[] {
            Creer("tour_blanc", 0, 0), Creer("cavalier_blanc", 1, 0),
            Creer("fou_blanc", 2, 0), Creer("dame_blanc", 3, 0),
            Creer("roi_blanc", 4, 0), Creer("fou_blanc", 5, 0),
            Creer("cavalier_blanc", 6, 0), Creer("tour_blanc", 7, 0),
            Creer("pion_blanc", 0, 1), Creer("pion_blanc", 1, 1),
            Creer("pion_blanc", 2, 1), Creer("pion_blanc", 3, 1),
            Creer("pion_blanc", 4, 1), Creer("pion_blanc", 5, 1),
            Creer("pion_blanc", 6, 1), Creer("pion_blanc", 7, 1) };

        joueurNoir = new GameObject[] {
            Creer("tour_noir", 0, 7), Creer("cavalier_noir", 1, 7),
            Creer("fou_noir", 2, 7), Creer("dame_noir", 3, 7),
            Creer("roi_noir", 4, 7), Creer("fou_noir", 5, 7),
            Creer("cavalier_noir", 6, 7), Creer("tour_noir", 7, 7),
            Creer("pion_noir", 0, 6), Creer("pion_noir", 1, 6),
            Creer("pion_noir", 2, 6), Creer("pion_noir", 3, 6),
            Creer("pion_noir", 4, 6), Creer("pion_noir", 5, 6),
            Creer("pion_noir", 6, 6), Creer("pion_noir", 7, 6) };

        // Remplir tableau des positions de la grille avec les pièces
        for (int i = 0; i < joueurNoir.Length; i++)
        {
            SetPosition(joueurNoir[i]);
            SetPosition(joueurBlanc[i]);
        }
    }

    public GameObject Creer(string nom, int x, int y) {

        GameObject objet = Instantiate(pieceDeJeu, new Vector3(0, 0, -1), Quaternion.identity);
        Piece piece = objet.GetComponent<Piece>();
        piece.name = nom;
        piece.SetXGrille(x);
        piece.SetXGrille(y);
        piece.Activer();

        return objet;

    }

    public void SetPosition(GameObject objet)
    {
        Piece piece = objet.GetComponent<Piece>();

        positions[piece.GetXGrille(), piece.GetYGrille()] = objet;
    }
    
}
