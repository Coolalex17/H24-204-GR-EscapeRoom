using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{

    public GameObject piece;

    // Start is called before the first frame update
    void Start()
    {
        // Placer la pièce sur le plateau
        Instantiate(piece, new Vector3(0, 0, -1), Quaternion.identity);
    }

    
}
