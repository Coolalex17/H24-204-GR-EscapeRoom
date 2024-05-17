using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Classe qui doit etre utilise a chaque fois quil doit y avoir une interaction entre lenvironnement et le personnage.
/// si le joueur regarde un objet interactif et clic avec sa souris, la metode respective sera appele 
/// </summary>
public interface Interactible
{
    /// <summary>
    /// Les fonctions ici sont appelé lorsque le joueur appuie sur la touche respective. Le transform du joueur pourra etre utilisé si nécessaire pour, par exemple, acceder a l'inventaire
    /// </summary>
    /// <param name="Joueur"></param>
    public void InteractionGauche(Transform Joueur);
    public void InteractionDroite(Transform Joueur);


}
