using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UI namespace for standard UI components
using TMPro;

public class CodeOrdinateur : MonoBehaviour
{
    private string reponse = "221";
    [SerializeField] private Text Ans;
    private bool reponseTrouvee = false;




    public void Nombre(int nombre)
    {
        if (Ans.text == "Incorrect" || Ans.text == "Correct")
        {
            Ans.text = "";
        }
        Ans.text += nombre.ToString();
    }
    public void Execute()
    {
        if (Ans.text == reponse)
        {
            Ans.text = "Correct";
            reponseTrouvee = true;
        }
        else
        {
            Ans.text = "Incorrect";
        }
    }
    public bool IsReponseTrouvee()
    {
        return reponseTrouvee;
    }
}
