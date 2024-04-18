using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jeu : MonoBehaviour
{

    public GameObject pieceDeJeu;

    // Positions et couleur de chaque pièce
    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] joueurBlanc = new GameObject[16];
    private GameObject[] joueurNoir = new GameObject[16];

    private string joueurCourrant = "blanc";

    private Vector2Int correctMoveStart;
    private Vector2Int correctMoveEnd;

    private bool finDuJeu = false;

    private string nomSceneActuelle;
    private string prochaineScene;


    void Start()
    {
        nomSceneActuelle = SceneManager.GetActiveScene().name;

        switch (nomSceneActuelle)
        {
            case "SceneJeuEchecsDefault":
                InitialiserJeuDefault();
                prochaineScene = "SceneJeuEchecs1";
                break;
            case "SceneJeuEchecs1":
                InitialiserJeu1();
                prochaineScene = "SceneJeuEchecs2";
                break;
            case "SceneJeuEchecs2":
                InitialiserJeu2();
                prochaineScene = "SceneJeuEchecs3";
                break;
            case "SceneJeuEchecs3":
                InitialiserJeu3();
                prochaineScene = "SceneJeuEchecs4";
                break;
            case "SceneJeuEchecs4":
                InitialiserJeu4();
                prochaineScene = "SceneJeuEchecsDefault";
                break;
        }

        // Remplir tableau des positions de la grille avec les pièces
        

        for (int i = 0; i < joueurNoir.Length; i++)
        {
            if (joueurNoir[i] != null) SetPosition(joueurNoir[i]);
        }

        for (int i = 0; i < joueurBlanc.Length; i++)
        {
            if (joueurBlanc[i] != null) SetPosition(joueurBlanc[i]);
        }
    }

    public void Update()
    {
        if (finDuJeu && Input.GetMouseButtonDown(0))
        {
            finDuJeu = false;

            SceneManager.LoadScene(prochaineScene);

        }
    }

    public void InitialiserJeuDefault()
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

        correctMoveStart = new Vector2Int(2, 1);
        correctMoveEnd = new Vector2Int(2, 2);
    }

    public void InitialiserJeu1()
    {
        // Remplir tableaux des couleurs des joueurs avec leurs pièces
        joueurBlanc = new GameObject[] {
            Creer("tour_blanc", 3, 0), Creer("roi_blanc", 6, 0),
            Creer("pion_blanc", 0, 4), Creer("pion_blanc", 5, 1),
            Creer("pion_blanc", 6, 1), Creer("pion_blanc", 7, 2) };

        joueurNoir = new GameObject[] {
            Creer("tour_noir", 1, 1), Creer("fou_noir", 5, 3), 
            Creer("roi_noir", 6, 7), Creer("pion_noir", 0, 5), Creer("pion_noir", 5, 6),
            Creer("pion_noir", 6, 6), Creer("pion_noir", 7, 6) };

        correctMoveStart = new Vector2Int(3, 0);
        correctMoveEnd = new Vector2Int(3, 7);
    }

    public void InitialiserJeu2()
    {
        // Remplir tableaux des couleurs des joueurs avec leurs pièces
        joueurBlanc = new GameObject[] {
            Creer("tour_blanc", 4, 2), Creer("cavalier_blanc", 6, 4),
            Creer("fou_blanc", 2, 1), Creer("dame_blanc", 3, 1),
            Creer("roi_blanc", 6, 0), Creer("pion_blanc", 1, 1),
            Creer("pion_blanc", 2, 2), Creer("pion_blanc", 3, 3),
            Creer("pion_blanc", 5, 1), Creer("pion_blanc", 6, 1), 
            Creer("pion_blanc", 7, 1) };

        joueurNoir = new GameObject[] {
            Creer("tour_noir", 3, 7), Creer("cavalier_noir", 6, 5),
            Creer("dame_noir", 0, 1), Creer("roi_noir", 7, 7), 
            Creer("tour_noir", 6, 7), Creer("pion_noir", 0, 6), 
            Creer("pion_noir", 1, 5), Creer("pion_noir", 2, 3), 
            Creer("pion_noir", 3, 4), Creer("pion_noir", 6, 6), 
            Creer("pion_noir", 7, 6) };

        correctMoveStart = new Vector2Int(6, 4);
        correctMoveEnd = new Vector2Int(5, 6);
    }

    public void InitialiserJeu3()
    {
        // Remplir tableaux des couleurs des joueurs avec leurs pièces
        joueurBlanc = new GameObject[] {
            Creer("tour_blanc", 7, 0), Creer("cavalier_blanc", 3, 7),
            Creer("fou_blanc", 6, 0), Creer("dame_blanc", 1, 0),
            Creer("roi_blanc", 3, 5), Creer("fou_blanc", 6, 1),
            Creer("tour_blanc", 6, 7), Creer("pion_blanc", 3, 1),
        Creer("cavalier_blanc", 6, 4)};

        joueurNoir = new GameObject[] {
            Creer("roi_noir", 3, 3), Creer("pion_noir", 7, 2),
            Creer("pion_noir", 0, 6), Creer("pion_noir", 1, 6),
            Creer("pion_noir", 2, 3), Creer("pion_noir", 3, 2),
            Creer("pion_noir", 4, 2), Creer("pion_noir", 5, 6), 
            Creer("pion_noir", 6, 5) };

        correctMoveStart = new Vector2Int(1, 0);
        correctMoveEnd = new Vector2Int(1, 1);
    }

    public void InitialiserJeu4()
    {
        // Remplir tableaux des couleurs des joueurs avec leurs pièces
        joueurBlanc = new GameObject[] {
            Creer("tour_blanc", 1, 6), Creer("cavalier_blanc", 6, 2),
            Creer("fou_blanc", 1, 1), Creer("dame_blanc", 6, 4),
            Creer("roi_blanc", 6, 0), Creer("fou_blanc", 2, 1),
            Creer("cavalier_blanc", 7, 5), Creer("tour_blanc", 5, 0),
            Creer("pion_blanc", 0, 1), Creer("pion_blanc", 3, 4),
            Creer("pion_blanc", 3, 1), Creer("pion_blanc", 4, 2),
            Creer("pion_blanc", 4, 3), Creer("pion_blanc", 6, 1),
            Creer("pion_blanc", 7, 2)};

        joueurNoir = new GameObject[] {
            Creer("tour_noir", 0, 7), Creer("cavalier_noir", 1, 3),
            Creer("fou_noir", 0, 3), Creer("dame_noir", 2, 7),
            Creer("roi_noir", 6, 6), Creer("fou_noir", 5, 7),
            Creer("cavalier_noir", 2, 4), Creer("tour_noir", 3, 7),
            Creer("pion_noir", 0, 4), Creer("pion_noir", 1, 4),
            Creer("pion_noir", 3, 5), Creer("pion_noir", 4, 4),
            Creer("pion_noir", 5, 6), Creer("pion_noir", 6, 5),
            Creer("pion_noir", 7, 6)};

        correctMoveStart = new Vector2Int(1, 1);
        correctMoveEnd = new Vector2Int(4, 4);
    }

    public GameObject Creer(string nom, int x, int y) {

        GameObject objet = Instantiate(pieceDeJeu, new Vector3(0, 0, -1), Quaternion.identity);
        Piece piece = objet.GetComponent<Piece>();
        piece.name = nom;
        piece.SetXGrille(x);
        piece.SetYGrille(y);
        piece.Activer();

        return objet;

    }

    public void SetPosition(GameObject objet)
    {
        Piece piece = objet.GetComponent<Piece>();

        positions[piece.GetXGrille(), piece.GetYGrille()] = objet;
    }

    public void SetPositionVide(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPositions(int x, int y)
    {
        return positions[x, y];
    }

    public bool IsFinDuJeu()
    {
        return finDuJeu;
    }

    public bool PositionSurGrille(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) 
            return false;
        return true;
    }

    public string GetJoueurCourrant()
    {
        return joueurCourrant;
    }

    public void ProchainJoueur()
    {
        if (joueurCourrant == "blanc")
        {
            joueurCourrant = "noir";
        }
        else
        {
            joueurCourrant = "blanc";
        }
    }

    

    public void FinPartie()
    {
        finDuJeu = true;

        GameObject.FindGameObjectWithTag("TexteContinuer").GetComponent<Text>().enabled = true;
    }

    public IEnumerator ShakeScreen(float duration = 0.5f, float magnitude = 0.5f)
    {
        Vector3 originalPos = Camera.main.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            Camera.main.transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null; // Wait until next frame
        }

        Camera.main.transform.localPosition = originalPos; // Reset camera position
    }

    public Vector2Int GetCorrectMoveStart()
    {
        return correctMoveStart;
    }

    public Vector2Int GetCorrectMoveEnd()
    {
        return correctMoveEnd;
    }

}
