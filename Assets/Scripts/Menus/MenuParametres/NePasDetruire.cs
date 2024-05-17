using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Emp�che ce GameObject d'�tre d�truit lors du changement de sc�ne s'il existe d�j� un autre GameObject avec le m�me tag.
/// </summary>
public class NePasDetruire : MonoBehaviour
{
    private void Awake()
    {
        // Trouve tous les GameObjects avec le tag "GameMusique".
        GameObject[] musiqueObj = GameObject.FindGameObjectsWithTag("GameMusique");

        // Si plus d'un GameObject avec ce tag est trouv�, d�truit celui-ci pour �viter les doublons.
        if (musiqueObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        // Emp�che ce GameObject d'�tre d�truit lors du changement de sc�ne.
        DontDestroyOnLoad(this.gameObject);
    }
}
