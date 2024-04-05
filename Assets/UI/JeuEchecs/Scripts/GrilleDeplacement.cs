using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleDeplacement : MonoBehaviour
{
    public GameObject controlleur;

    GameObject reference = null; //la grille de d�placement de chaque pi�ce s'affiche quand on clique sur la pi�ce, donc chaque grille de d�placement doit avoir sa pi�ce r�f�rence

    // Positions sur la grille, pas dans le monde
    int matriceX; 
    int matriceY;

    // v�rifier si le d�placement qu'on a fait attaque une autre pi�ce
    public bool attaque = false;

    public void Start()
    {
        if (attaque)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnMouseUp()
    {
        controlleur = GameObject.FindGameObjectWithTag("GameController");

        if (attaque)
        {
            GameObject piece = controlleur.GetComponent<Jeu>().GetPositions(matriceX, matriceY);

            if (piece.name == "roi_blanc") controlleur.GetComponent<Jeu>().Gagnant("noir");
            if (piece.name == "roi_noir") controlleur.GetComponent<Jeu>().Gagnant("blanc");


            Destroy(piece);
        }

        controlleur.GetComponent<Jeu>().SetPositionVide(reference.GetComponent<Piece>().GetXGrille(), reference.GetComponent<Piece>().GetYGrille());

        reference.GetComponent<Piece>().SetXGrille(matriceX);
        reference.GetComponent<Piece>().SetYGrille(matriceY);
        reference.GetComponent<Piece>().SetCoordonnees();

        controlleur.GetComponent<Jeu>().SetPosition(reference);

        controlleur.GetComponent<Jeu>().ProchainJoueur();

        reference.GetComponent<Piece>().DetruireGrilleDeplacement();
    }

    public void SetCoordonnees(int x, int y)
    {
        matriceX = x;
        matriceY = y;
    }

    public void SetReference(GameObject objet)
    {
        reference = objet;
    }

    public GameObject GetReference()
    {
        return reference;
    }



}
