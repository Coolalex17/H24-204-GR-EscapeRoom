
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractibleJeuCalcul : MonoBehaviour, Interactible
{
    public void InteractionDroite(Transform Joueur)
    {
        //pas utile presentement
    }

    //Load la scène du jeu d'échecs
    public void InteractionGauche(Transform Joueur)
    {
        if (PreferencesJoueur.getFiniJeuCalcul())
        {
            return;
        }
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("JeuMath");
    }
    public void Quitter()
    {
        // Load or activate the school scene
        SceneManager.LoadScene("SceneJeuV2");
    }


}
