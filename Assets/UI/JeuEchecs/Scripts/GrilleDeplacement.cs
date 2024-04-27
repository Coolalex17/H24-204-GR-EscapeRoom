using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleDeplacement : MonoBehaviour
{
    public GameObject controlleur;

    GameObject reference = null; //la grille de déplacement de chaque pièce s'affiche quand on clique sur la pièce, donc chaque grille de déplacement doit avoir sa pièce référence

    // Positions sur la grille, pas dans le monde
    int matriceX; 
    int matriceY;

    // vérifier si le déplacement qu'on a fait attaque une autre pièce
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
       

        // Check if the move matches the correct move
        if (reference.GetComponent<Piece>().GetXGrille() == controlleur.GetComponent<Jeu>().GetCorrectMoveStart().x &&
            reference.GetComponent<Piece>().GetYGrille() == controlleur.GetComponent<Jeu>().GetCorrectMoveStart().y &&
            matriceX == controlleur.GetComponent<Jeu>().GetCorrectMoveEnd().x && matriceY == controlleur.GetComponent<Jeu>().GetCorrectMoveEnd().y)
        {
            controlleur.GetComponent<Jeu>().FinPartie();
        }
        else
        {
            // Move is incorrect, shake the screen and do not update piece's position
            StartCoroutine(controlleur.GetComponent<Jeu>().ShakeScreen());
            return; // Exit the method without making the move
        }


        controlleur = GameObject.FindGameObjectWithTag("GameController");

        if (attaque)
        {
            GameObject piece = controlleur.GetComponent<Jeu>().GetPositions(matriceX, matriceY);

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
