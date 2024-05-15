using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    //https://www.youtube.com/watch?v=TO0g5jyjpYU
    public string reponse;
    [SerializeField] private Text Ans;
    [SerializeField] private Animator Refregirateur;
   [SerializeField] private Animator Coffre;
    private bool reponseTrouvee = false; 


    public void Nombre(int nombre)
    {
        if (Ans.text== "Incorrect" || Ans.text == "Correct"){
            Ans.text = "" ;
        }
        Ans.text += nombre.ToString();
    }
    public void Execute()
    {
        if (Ans.text == reponse)
        {
            Ans.text = "Correct";
            Refregirateur.SetBool("Ouvert", true);
            Coffre.Play("TreasureChest_OPEN", 0);
            reponseTrouvee = true;
            StartCoroutine("Stop");
          
        }
        else
        {
            Ans.text = "Incorrect";
        }
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.5f);
        Refregirateur.SetBool("Ouvert", false);
        Refregirateur.enabled = false;
    }


    public bool IsReponseTrouvee()
    {
        return reponseTrouvee;
    }

  

}

