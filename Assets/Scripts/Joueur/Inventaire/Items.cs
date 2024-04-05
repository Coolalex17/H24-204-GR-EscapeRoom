using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public partial class Inventaire
{
    //Array avec toutes les textures de tout les items.
    //le textures doivent etre assigne dans le meme ordre que les objets dans lenum Items
    [SerializeField] private Texture[] Images;

    //Liste de tout les items qui peuvent etre donne au joueur
    public enum Items{
        CLEE_PORTE1,
        CLEE_PORTE2,
    }

    //est appele pour afficher linventaire du joueur correctement
    public Texture ObtenirImage(Items item)
    {
        return Images[(int) item];
    }



}

