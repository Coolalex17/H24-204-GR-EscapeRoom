using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleDeplacement : MonoBehaviour
{
    public GameObject controlleur;

    GameObject reference = null; //la grille de déplacement de chaque pièce s'affiche quand on clique sur la pièce,
                                 //donc chaque grille de déplacement doit avoir sa pièce référence

    // Positions sur la grille, pas dans le monde
    int matriceX; 
    int matriceY;

    // Vérifier si le déplacement qu'on a fait attaque une autre pièce
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
       

        // Vérifier si le déplacement concorde avec le bon déplacement
        if (reference.GetComponent<Piece>().GetXGrille() == controlleur.GetComponent<Jeu>().GetCorrectMoveStart().x &&
            reference.GetComponent<Piece>().GetYGrille() == controlleur.GetComponent<Jeu>().GetCorrectMoveStart().y &&
            matriceX == controlleur.GetComponent<Jeu>().GetCorrectMoveEnd().x && matriceY == controlleur.GetComponent<Jeu>().GetCorrectMoveEnd().y)
        {
            controlleur.GetComponent<Jeu>().FinPartie();
        }
        else
        {
            // Si le déplacemenet est incorrect, faire bouger l'écran pour donner l'effet que la réponse est mauvaise
            StartCoroutine(controlleur.GetComponent<Jeu>().ShakeScreen());
            return; // Quitter la méthode sans effectuer le déplacement
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
