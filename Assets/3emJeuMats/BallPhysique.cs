
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallPhysique : MonoBehaviour
{

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

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCounter));
    }



    private void StartBall()
    {
        rb.velocity = new Vector2(-1, 0) * (initialSpeed + speedIncrease * hitCounter);
    }

    private void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        hitCounter = 0;
        Invoke("StartBall", 2f);
    }

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            ResetBall();
            int playerScore = int.Parse(PlayerScore.text) + 1;
            PlayerScore.text = playerScore.ToString();
            if (playerScore >= 5)
            {
                GameOver("Player");
            }
        }
        else if (transform.position.x < 0)
        {
            ResetBall();
            int aiScore = int.Parse(AIScore.text) + 1;
            AIScore.text = aiScore.ToString();
            if (aiScore >= 5)
            {
                GameOver("AI");
            }
        }
    }



    private void GameOver(string winner)
    {
        Debug.Log(winner + " wins!");
        gameOver = true;
        PreferencesJoueur.GetSavedInventaire().AjouterItem(Inventaire.Items.CLEE_PORTE2,1);
        SceneManager.LoadScene("SceneJeuV2"); // Load the game over scene
    }
}