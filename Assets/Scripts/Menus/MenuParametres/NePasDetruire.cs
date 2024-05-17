using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Empêche ce GameObject d'être détruit lors du changement de scène s'il existe déjà un autre GameObject avec le même tag.
/// </summary>
public class NePasDetruire : MonoBehaviour
{
    private void Awake()
    {
        // Trouve tous les GameObjects avec le tag "GameMusique".
        GameObject[] musiqueObj = GameObject.FindGameObjectsWithTag("GameMusique");

        // Si plus d'un GameObject avec ce tag est trouvé, détruit celui-ci pour éviter les doublons.
        if (musiqueObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        // Empêche ce GameObject d'être détruit lors du changement de scène.
        DontDestroyOnLoad(this.gameObject);
    }
}
