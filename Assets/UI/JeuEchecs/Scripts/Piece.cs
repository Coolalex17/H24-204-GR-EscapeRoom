using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public void Activer() {
        controlleur = GameObject.FindGameObjectWithTag("GameController");

        // Ajuster les coordonnées
        SetCoordonnees();

        switch (this.name)
        {
            case "roi_noir": this.GetComponent<SpriteRenderer>().sprite = roi_noir; break;
            case "dame_noir": this.GetComponent<SpriteRenderer>().sprite = dame_noir; break;
            case "tour_noir": this.GetComponent<SpriteRenderer>().sprite = tour_noir; break;
            case "cavalier_noir": this.GetComponent<SpriteRenderer>().sprite = cavalier_noir; break;
            case "fou_noir": this.GetComponent<SpriteRenderer>().sprite = fou_noir; break;
            case "pion_noir": this.GetComponent<SpriteRenderer>().sprite = pion_noir; break;
            
            case "roi_blanc": this.GetComponent<SpriteRenderer>().sprite = roi_blanc; break;
            case "dame_blanc": this.GetComponent<SpriteRenderer>().sprite = dame_blanc; break;
            case "tour_blanc": this.GetComponent<SpriteRenderer>().sprite = tour_blanc; break;
            case "cavalier_blanc": this.GetComponent<SpriteRenderer>().sprite = cavalier_blanc; break;
            case "fou_blanc": this.GetComponent<SpriteRenderer>().sprite = fou_blanc; break;
            case "pion_blanc": this.GetComponent<SpriteRenderer>().sprite = pion_blanc; break;

        }
    }
    
    public void SetCoordonnees() {
        float x = xGrille;
        float y = yGrille;

        float vraieOrigineGrille = -13.55f;

        float tailleCase = 2.7f;
        float tailleDemieCase = tailleCase / 2;

        x = vraieOrigineGrille + xGrille * tailleCase + tailleDemieCase;
        y = vraieOrigineGrille + yGrille * tailleCase + tailleDemieCase;


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
}
