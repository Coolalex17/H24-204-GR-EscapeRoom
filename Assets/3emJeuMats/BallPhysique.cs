
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*sources: 
1-https://www.youtube.com/watch?v=X_Hrwcj7G_4&t=1s&ab_channel=ImNotAlexx
2-https://www.youtube.com/watch?v=JZvNFrS7wTM&t=2909s&ab_channel=Hooson
3-ChatGPT*/

public class BallPhysique : MonoBehaviour
{
    /// <summary>
    /// Les variables en anglais étaient difficiles de le rechanger en français,
    /// donc, voici un résumé
    /// initialSpeed = vitesseInitial
    /// speedIncrease = acceleration
    /// PlayerScore = joueurScore
    /// hitCounter = compteurTouche;
    /// private void ResetBall() -- private void recommencerBalle()
    /// private void PlayerBounce() -- private void bondirBallon()
    /// private void GameOver(string winner) -- private void GameOver(string winner)

    [SerializeField] private float initialSpeed = 10;
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] private Text PlayerScore;
    [SerializeField] private Text AIScore;

    private bool gameOver = false;
    private int hitCounter; 
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2f);

    }

    //modifier la physique du joueur telle que l'augmentation de l'acceleration

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCounter));
    }

    //Le debut du mouvement de la balle, et qu'elle se dirige vers le joueur. 
    private void StartBall()
    {
        rb.velocity = new Vector2(-1, 0) * (initialSpeed + speedIncrease * hitCounter);
    }

    //Recommencer le position de la balle lorsque un des joueurs marque

    private void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        hitCounter = 0;
        Invoke("StartBall", 2f);
    }

    //Physique de la balle lorsqu'elle touche un des joueurs
    private void PlayerBounce(Transform myObject)
    {
        hitCounter++;
        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;

        float xDirection = transform.position.x > 0 ? -1 : 1;
        float yDirection = (ballPos.y - playerPos.y) / myObject.GetComponent
            <Collider2D>().bounds.size.y;

        if (yDirection == 0)
        {
            yDirection = 0.25f;
        }
        rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + (speedIncrease * hitCounter));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != null && (collision.gameObject.name == "Player" || collision.gameObject.name == "AI"))
        {
            PlayerBounce(collision.transform);
        }
    }

    //Lorsqu'un des joueurs marque, l'affichage des scores change 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            
            ResetBall();
            int playerScore = int.Parse(PlayerScore.text) + 1;
            PlayerScore.text = playerScore.ToString();

           
            Debug.Log("Player Score: " + playerScore);

           
            if (playerScore >= 2)
            {
                GameOver("Player");
            }
        }
        else if (transform.position.x < 0)
        {
            ResetBall();
           
            int aiScore = int.Parse(AIScore.text) + 1;
            AIScore.text = aiScore.ToString();
            Debug.Log("AI Score: " + aiScore);

            
            if (aiScore >= 2)
            {
                GameOver("AI");
                
            }
        }
    }
    //Lorsqu'on termine le jeu, on se dirige vers la scene PartiFini


    private void GameOver(string winner)
    {
        Debug.Log(winner + " wins!");
        AIScore.text = "0";
        PlayerScore.text = "0";

        // Check if the Inventaire object is not null before calling AjouterItem
        if (winner != "AI") {
            Cursor.lockState = CursorLockMode.Confined;
            if (!PreferencesJoueur.getFiniJeuSoccer()) {
                PreferencesJoueur.GetSavedInventaire().Add(Inventaire.Items.CLEE_VERTE);
            }
            PreferencesJoueur.FinirJeuSoccer();
            SceneManager.LoadScene("PartiFini");
        }

    }


}