using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public partial class Inventaire : MonoBehaviour
{
    private List<Items> ConteneurInventaire;
    [SerializeField] private Texture[] Images;

    void Start()
    {
        ConteneurInventaire = new List<Items>();
    }
    public List<Items> ObtenirInventaire()
    {
        return ConteneurInventaire;
    }


    public int VerifierPossesionItem(Items item)
    {
        int QuantiteeItems = 0;
        Items[] InventaireTemp = ConteneurInventaire.ToArray();

        for (int i = 0;i < InventaireTemp.Length; i++)
        {
            if (InventaireTemp[i] == item)
            {
                QuantiteeItems++;
            }
        }
        return QuantiteeItems;
    }
    public bool EnleverItem(Items item,int Quantitee)
    {
       int QuantiteeRestante = VerifierPossesionItem(item);
       if (QuantiteeRestante < Quantitee)
       {
            return false;
       }
         for (int i = 0;i < Quantitee; i++)
        {
            Debug.Log(ConteneurInventaire.ToArray().Length);
            ConteneurInventaire.Remove(item);
            Debug.Log(ConteneurInventaire.ToArray().Length);
       }
       
       
       return true;
    }
    public void AjouterItem(Items items,int Quantitee)
    {
        for (int i = 0;i < Quantitee; i++)
        {
            ConteneurInventaire.Add(items);
        }
    }

    



}

