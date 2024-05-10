using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeEchec : MonoBehaviour
{
    public string code ="6878" ;
    [SerializeField] TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        if (PreferencesJoueur.getFiniJeuEchec()) {
            text.text = code;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
