using System.Collections.Generic;
using UnityEngine;

public partial class Inventaire : MonoBehaviour
{
    private Dictionary<Items, int> ConteneurInventaire;
    void Start()
    {
        ConteneurInventaire = new Dictionary<Items, int>();
    }


    public int VerifierPossesionItem(Items item)
    {
        int QuantiteeItems = 0;
        ConteneurInventaire.TryGetValue(item,out QuantiteeItems);
        return QuantiteeItems;

    }
    public bool EnleverItem(Items item,int Quantitee)
    {
       int QuantiteeRestante = VerifierPossesionItem(item);
       if (QuantiteeRestante < Quantitee)
        {
            return false;
        }
        ConteneurInventaire[item] = QuantiteeRestante - Quantitee;
       
       
       return true;
    }
    public void AjouterItem(Items items,int Quantitee)
    {
        if(ConteneurInventaire.ContainsKey(items)) {
            ConteneurInventaire[items] += Quantitee;
            return;
        }
        ConteneurInventaire.Add(items, Quantitee);
    }


}

