using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using static Inventaire;

[System.Serializable] class SaveData 
{
    public bool testBool;
    //public List<Items> ConteneurInventaire;

    public SaveData SavingData()
    {
        var saveDate = new SaveData();
        saveDate.testBool = true;
        //saveDate.ConteneurInventaire = (Joueur.GetComponent<Inventaire>()).ObtenirInventaire();

        return saveDate;
    }
}
