using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Classe qui doit etre utilise a chaque fois quil doit y avoir une interaction entre lenvironnement et le personnage.
/// si le joueur regarde un objet interactif et clic avec sa souris, la metode respective sera appele 
/// </summary>
public interface Interactible
{
    public void InteractionGauche(Transform Joueur);
    public void InteractionDroite(Transform Joueur);


}
