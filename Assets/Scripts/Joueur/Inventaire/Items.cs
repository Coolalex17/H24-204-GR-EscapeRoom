using System;
using System.Collections.Generic;
using UnityEngine;

public partial class Inventaire
{
    public enum Items
    {
        CLEE_PORTE1,
        CLEE_PORTE2
    }

    private Dictionary<Items, Texture> DictionaireImage;
    private Texture[] Images_ = new Texture[2]; // Assuming you need at least 2 images

    private void AssocierImages()
    {
        DictionaireImage = new Dictionary<Items, Texture>();

        DictionaireImage.Add(Items.CLEE_PORTE1, Images_[0]);
        DictionaireImage.Add(Items.CLEE_PORTE2, Images_[1]);
    }

    public Texture ObtenirImage(Items item)
    {
        Texture image = null;
        DictionaireImage.TryGetValue(item, out image);
        return image;
    }
}


