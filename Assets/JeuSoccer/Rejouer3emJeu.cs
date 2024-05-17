using UnityEngine;
using UnityEngine.SceneManagement;

/*sources: 
1-https://www.youtube.com/watch?v=X_Hrwcj7G_4&t=1s&ab_channel=ImNotAlexx
2-https://www.youtube.com/watch?v=JZvNFrS7wTM&t=2909s&ab_channel=Hooson
3-ChatGPT*/

public class ReplayButton : MonoBehaviour
{
    //Lorsque le joueur clique sur rejouer, il se dirige vers la scene du jeu
    public void ReplayGame()
    {
        SceneManager.LoadScene("3emJeu"); // Load the main scene
    }

    //Lorsque le joueur cliquer sur quitter, il se dirigie vers la scene prinicpale du jeu (la base)
    public void QuitterJeuEtRetourner()
    {
        SceneManager.LoadScene("SceneJeuV2"); 
    }

}
