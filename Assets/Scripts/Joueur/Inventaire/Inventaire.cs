using System.Collections.Generic;
using UnityEngine;

public partial class Inventaire : MonoBehaviour
{
    private List<Items> ConteneurInventaire;

    void Start()
    {
        ConteneurInventaire = PreferencesJoueur.GetSavedInventaire();
    }
    
    public List<Items> ObtenirInventaire()
    {
        return ConteneurInventaire;
    }
    /// <summary>
    /// Verifie la quantite d'un type d'item qui est contenu dans l'inventaire
    /// </summary>
    /// <param name="item">type d'item dont on veut verifier la quantitee possedee</param>
    /// <returns>la quantitee qui est contenue  dans l'inventaire</returns>
    public int VerifierPossesionItem(Items item){
        int QuantiteeItems = 0;
        Items[] InventaireTemp = ConteneurInventaire.ToArray();
        for (int i = 0;i < InventaireTemp.Length; i++){

            if (InventaireTemp[i] == item){
                QuantiteeItems++;
                
            }
        }
        return QuantiteeItems;
    }
    /// <summary>
    /// Enleve la quantite voulu du type d'item voulu a linventaire
    /// Ne doit pas etre utilise pour ajouter des items il faudrait plutot utiliser la fonction AjouterItem
    /// </summary>
    /// <param name="item">type d'item qui doit etre enleve</param>
    /// <param name="Quantitee">Quantite d'items qui doivent etre enleve</param>
    /// <returns>Return false si l'inventaire ne possede pas la quantitee ditem requis</returns>
    public bool EnleverItem(Items item,int Quantitee){
       int QuantiteeRestante = VerifierPossesionItem(item);
        Debug.Log(QuantiteeRestante);
       if (QuantiteeRestante < Quantitee){
            return false;
       }
         for (int i = 0;i < Quantitee; i++){
            ConteneurInventaire.Remove(item);
       }
       return true;
    }
    /// <summary>
    /// Ajoute la quantite voulu du type d'item voulu a linventaire
    /// Ne doit pas etre utilise pour enlever des items il faudrait plutot utiliser la fonction EnleverItem
    /// </summary>
    /// <param name="items">le type d'item qui doit etre enleve</param>
    /// <param name="Quantitee">Quantite d'item qui doit etre ajoute</param>
    public void AjouterItem(Items items,int Quantitee){
        if(Quantitee <= 0){
            return;
        }
        for (int i = 0;i < Quantitee; i++){
            ConteneurInventaire.Add(items);
        }
    }

    



}

