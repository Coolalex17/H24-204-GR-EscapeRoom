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

    public Texture ObtenirImage(Items item)
    {
        return Images[(int) item];
    }



}

