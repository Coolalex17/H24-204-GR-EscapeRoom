using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*sources: 
1-https://www.youtube.com/watch?v=X_Hrwcj7G_4&t=1s&ab_channel=ImNotAlexx
2-https://www.youtube.com/watch?v=JZvNFrS7wTM&t=2909s&ab_channel=Hooson
3-ChatGPT*/

public class JoueurPhysique : MonoBehaviour

/// <summary>
/// Les variables en anglais étaient difficiles de le rechanger en français,
/// donc, voici un résumé
/// mouvementSpeed = mouvementVitesse
/// isAI = estAI
/// private void PlayerControl() -- private void ControlJoueur()
/// private void AIControl() -- private void AIControl()
{
    [SerializeField] private float mouvementSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rb;
    private Vector2 playerMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isAI)
        {
            AIControl();
        }
        else
        {
            PlayerControl();

        }
    }

    //Le joueur peut naviguer vers le bas et le haut

    private void PlayerControl()
    {
        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }

    //Le nagivgue vers le bas et le haut dependamment de l'orientation de la balle 
    private void AIControl()
    {
        if (ball.transform.position.y > transform.position.y + 0.5f)
        {
            playerMove = new Vector2(0, 1);

        }
        else if (ball.transform.position.y < transform.position.y - 0.5f)
        {
            playerMove = new Vector2(0, -1);

        }
        else
        {
            playerMove = new Vector2(0, 0);
        }
    }
    //La vitesse du joueur qui augmente avec l'acceleration

    private void FixedUpdate()
    {
        rb.velocity = playerMove * mouvementSpeed;

    }




}