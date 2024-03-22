using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Piece : MonoBehaviour
{

    public GameObject controlleur;
    public GameObject grilleDeplacement;

    // Positions
    private int xGrille = -1;
    private int yGrille = -1;

    // Couleur de la pièce du joueur
    private string joueur;

    // References pour tous les sprites
    public Sprite roi_noir, dame_noir, tour_noir, fou_noir, cavalier_noir, pion_noir;
    public Sprite roi_blanc, dame_blanc, tour_blanc, fou_blanc, cavalier_blanc, pion_blanc;

    // 
    public void Activer() {
        controlleur = GameObject.FindGameObjectWithTag("GameController");

        // Ajuster les coordonnées
        SetCoordonnees();

        switch (this.name)
        {
            case "roi_noir": this.GetComponent<SpriteRenderer>().sprite = roi_noir; joueur = "noir"; break;
            case "dame_noir": this.GetComponent<SpriteRenderer>().sprite = dame_noir; joueur = "noir"; break;
            case "tour_noir": this.GetComponent<SpriteRenderer>().sprite = tour_noir; joueur = "noir"; break;
            case "cavalier_noir": this.GetComponent<SpriteRenderer>().sprite = cavalier_noir; joueur = "noir"; break;
            case "fou_noir": this.GetComponent<SpriteRenderer>().sprite = fou_noir; joueur = "noir"; break;
            case "pion_noir": this.GetComponent<SpriteRenderer>().sprite = pion_noir; joueur = "noir"; break;
            
            case "roi_blanc": this.GetComponent<SpriteRenderer>().sprite = roi_blanc; joueur = "blanc"; break;
            case "dame_blanc": this.GetComponent<SpriteRenderer>().sprite = dame_blanc; joueur = "blanc"; break;
            case "tour_blanc": this.GetComponent<SpriteRenderer>().sprite = tour_blanc; joueur = "blanc"; break;
            case "cavalier_blanc": this.GetComponent<SpriteRenderer>().sprite = cavalier_blanc; joueur = "blanc"; break;
            case "fou_blanc": this.GetComponent<SpriteRenderer>().sprite = fou_blanc; joueur = "blanc"; break;
            case "pion_blanc": this.GetComponent<SpriteRenderer>().sprite = pion_blanc; joueur = "blanc"; break;
        }
    }
    
    public void SetCoordonnees() {
        float x = xGrille;
        float y = yGrille;

        float vraieOrigineGrille = -13.55f;

        float tailleCase = 2.7f;
        float tailleDemieCase = tailleCase / 2;


        x *= tailleCase;
        y *= tailleCase;

        x += vraieOrigineGrille + tailleDemieCase + tailleCase;
        y += vraieOrigineGrille + tailleDemieCase + tailleCase;



        //x = vraieOrigineGrille + xGrille * tailleCase + tailleDemieCase + tailleCase; // optimize this
        //y = vraieOrigineGrille + yGrille * tailleCase + tailleDemieCase + tailleCase;


        /*
        x += -13.5f;
        y += -13.5f;

        x *= 2.7f;
        y *= 2.7f;

        x += 1.35f;
        y += 1.35f;
        */

        this.transform.position = new Vector3(x, y, -1.0f);
    }
    

    public int GetXGrille()
    {
        return xGrille;
    }

    public int GetYGrille()
    {
        return yGrille;
    }

    public void SetXGrille(int x)
    {
        xGrille = x;
    }

    public void SetYGrille(int y)
    {
        yGrille = y;
    }

    private void OnMouseUp()
    {
        if (!controlleur.GetComponent<Jeu>().IsFinDuJeu() && controlleur.GetComponent<Jeu>().GetJoueurCourrant() == joueur)
        {
            DetruireGrilleDeplacement(); //Détruit la grille de déplacement qui a été créée
                                     //pour la pièce sur laquelle on a cliqué juste avant,
                                     //pour pouvoir ensuite créer la nouvelle grille de déplacement pour la pièce courrante
           
            InitialiserGrilleDeplacement();
        }
        
    }

    public void DetruireGrilleDeplacement()
    {
        GameObject[] grilleDeplacements = GameObject.FindGameObjectsWithTag("GrilleDeplacement");
        for (int i = 0; i < grilleDeplacements.Length; i++)
        {
            Destroy(grilleDeplacements[i]);
        }
    }

    public void InitialiserGrilleDeplacement()
    {
        switch (this.name)
        {
            case "dame_noir":
            case "dame_blanc":
                GrilleDeplacementLigne(1, 0);
                GrilleDeplacementLigne(0, 1);
                GrilleDeplacementLigne(1, 1);
                GrilleDeplacementLigne(-1, 0);
                GrilleDeplacementLigne(0, -1);
                GrilleDeplacementLigne(-1, 1);
                GrilleDeplacementLigne(1, -1);
                GrilleDeplacementLigne(-1, -1);
                break;
            case "cavalier_noir":
            case "cavalier_blanc":
                GrilleDeplacementEnL();
                break;
            case "fou_noir":
            case "fou_blanc":
                GrilleDeplacementLigne(1, 1);
                GrilleDeplacementLigne(-1, 1);
                GrilleDeplacementLigne(1, -1);
                GrilleDeplacementLigne(-1, -1);
                break;
            case "roi_noir":
            case "roi_blanc":
                GrilleDeplacementUnitaire(); // peut juste bouger une case autour de lui
                break;
            case "tour_noir":
            case "tour_blanc":
                GrilleDeplacementLigne(1, 0);
                GrilleDeplacementLigne(0, 1);
                GrilleDeplacementLigne(-1, 0);
                GrilleDeplacementLigne(0, -1);
                break;
            case "pion_noir":
                GrilleDeplacementPion(xGrille, yGrille - 1); // les noirs commencent en haut de la grille
                break;
            case "pion_blanc":
                GrilleDeplacementPion(xGrille, yGrille + 1); // les blancs commencent en bas de la grille
                break;
        }
    }

    public void GrilleDeplacementLigne(int xIncrementation, int yIncrementation)
    {
        Jeu jeu = controlleur.GetComponent<Jeu>();

        int x = xGrille + xIncrementation;
        int y = yGrille + yIncrementation;

        while (jeu.PositionSurGrille(x, y) && jeu.GetPositions(x, y) == null)
        {
            CreerGrilleDeplacement(x, y, false);
            x += xIncrementation;
            y += yIncrementation;
        }

        if (jeu.PositionSurGrille(x, y) && jeu.GetPositions(x, y).GetComponent<Piece>().joueur != joueur)
        {
            CreerGrilleDeplacement(x, y, true);
        }
    }

    public void GrilleDeplacementEnL()
    {
        GrilleDeplacementEnPoint(xGrille + 1, yGrille + 2);
        GrilleDeplacementEnPoint(xGrille - 1, yGrille + 2);
        GrilleDeplacementEnPoint(xGrille + 2, yGrille + 1);
        GrilleDeplacementEnPoint(xGrille + 2, yGrille - 1);
        GrilleDeplacementEnPoint(xGrille + 1, yGrille - 2);
        GrilleDeplacementEnPoint(xGrille - 1, yGrille - 2);
        GrilleDeplacementEnPoint(xGrille - 2, yGrille + 1);
        GrilleDeplacementEnPoint(xGrille - 2, yGrille - 1);
    }

    public void GrilleDeplacementUnitaire()
    {
        GrilleDeplacementEnPoint(xGrille, yGrille + 1);
        GrilleDeplacementEnPoint(xGrille, yGrille - 1);
        GrilleDeplacementEnPoint(xGrille - 1, yGrille - 1);
        GrilleDeplacementEnPoint(xGrille - 1, yGrille);
        GrilleDeplacementEnPoint(xGrille - 1, yGrille + 1);
        GrilleDeplacementEnPoint(xGrille + 1, yGrille - 1);
        GrilleDeplacementEnPoint(xGrille + 1, yGrille);
        GrilleDeplacementEnPoint(xGrille + 1, yGrille + 1);
    }

    public void GrilleDeplacementEnPoint(int x, int y)
    {
        Jeu jeu = controlleur.GetComponent<Jeu>();
        
        if (jeu.PositionSurGrille(x, y))
        {
            GameObject piece = jeu.GetPositions(x, y);

            if (piece == null)
            {
                CreerGrilleDeplacement(x, y, false);
            }
            else if (piece.GetComponent<Piece>().joueur != joueur)
            {
                CreerGrilleDeplacement(x, y, true);
            }
        }
    }

    public void GrilleDeplacementPion(int x, int y)
    {
        Jeu jeu = controlleur.GetComponent<Jeu>();

        if (jeu.PositionSurGrille(x, y))
        {
            if (jeu.GetPositions(x, y) == null)
            {
                CreerGrilleDeplacement(x, y, false);
            }
            
            if (jeu.PositionSurGrille(x + 1, y) && jeu.GetPositions(x + 1, y) != null && 
                jeu.GetPositions(x + 1, y).GetComponent<Piece>().joueur != joueur)

            {
                CreerGrilleDeplacement(x + 1, y, true);
            }

            if (jeu.PositionSurGrille(x - 1, y) && jeu.GetPositions(x - 1, y) != null &&
                jeu.GetPositions(x - 1, y).GetComponent<Piece>().joueur != joueur)

            {
                CreerGrilleDeplacement(x - 1, y, true);
            }
        }
    }

    public void CreerGrilleDeplacement(int matriceX, int matriceY, bool attaque)
    {
        float x = matriceX;
        float y = matriceY;

        float vraieOrigineGrille = -13.55f;

        float tailleCase = 2.7f;
        float tailleDemieCase = tailleCase / 2;


        x *= tailleCase;
        y *= tailleCase;

        x += vraieOrigineGrille + tailleDemieCase + tailleCase;
        y += vraieOrigineGrille + tailleDemieCase + tailleCase;

        GameObject gd = Instantiate(grilleDeplacement, new Vector3(x, y, -1.0f), Quaternion.identity); // gd: grille deplacement

        GrilleDeplacement scriptGrilleDeplacement = gd.GetComponent<GrilleDeplacement>();
        if (attaque)
        {
            scriptGrilleDeplacement.attaque = true;
        }
        scriptGrilleDeplacement.SetReference(gameObject);
        scriptGrilleDeplacement.SetCoordonnees(matriceX, matriceY);
    }

}
