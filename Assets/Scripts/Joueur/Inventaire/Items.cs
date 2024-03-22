using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public partial class Inventaire
{
    

    public enum Items
    {
        CLEE_PORTE1,
        CLEE_PORTE2,

    }
    
    
    private Dictionary<Items, Texture> DictionaireImage;


    private void AssocierImages()
    {
        DictionaireImage = new Dictionary<Items, Texture>();

        DictionaireImage.Add(Items.CLEE_PORTE1, Images[0]);
        DictionaireImage.Add(Items.CLEE_PORTE2, Images[1]);


    }
    public Texture ObtenirImage(Items item)
    {
        Texture image = null;
        DictionaireImage.TryGetValue(item, out image);
        return image;
    }



}

