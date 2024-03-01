using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UIElements;

public class ControleurJeuPhysique : MonoBehaviour
{
    [SerializeField] private UIDocument UIJeu;
    [SerializeField] private Camera cameraJoueur;
    [SerializeField] private Camera cameraJeuPhysique;

    [SerializeField] private Transform conteneurProjectiles;
    [SerializeField] private Transform fleche;

   


    private Slider sliderForce;
    private Slider sliderAngle;
    private Button boutonTirer;
    private bool jeuDebute;

    void Start()
    {
        projectileEnVie = false;
        sliderForce = UIJeu.rootVisualElement.Q<Slider>("SliderForce");
        sliderAngle = UIJeu.rootVisualElement.Q<Slider>("SliderRotation");
        boutonTirer = UIJeu.rootVisualElement.Q<Button>("BoutonTirer");

        UIJeu.rootVisualElement.Q<GroupBox>("BoiteBoutons").style.visibility = Visibility.Hidden;
        cameraJeuPhysique.enabled = false;
        jeuDebute = false;

        boutonTirer.RegisterCallback<ClickEvent>(tirer);
    }
    public void debuterJeu()
    {
        jeuDebute = true;
        UIJeu.rootVisualElement.Q<GroupBox>("BoiteBoutons").style.visibility = Visibility.Visible;
        cameraJoueur.enabled = false;
        cameraJeuPhysique.enabled = true;
    }
    private void FixedUpdate()
    {
        if (jeuDebute) {
            conteneurProjectiles.rotation = Quaternion.Euler(0f, 0f, -sliderAngle.value);
            fleche.localScale =new Vector3(1, (sliderForce.value/100) + 0.5f, 1);
            fleche.localPosition = new Vector3(0, (sliderForce.value / 100 + 1.6f) / 2 + 0.2f, 0);

            if (projectileEnVie)
            {
                bougerProjectile();
            }
        }
        
        
    }

    [SerializeField] private GameObject projectile;
    private bool projectileEnVie;
    private float vitesseX;
    private float vitesseY;
    private float gravitee;
    private void bougerProjectile()
    {
        projectile.transform.position += new Vector3(vitesseX,vitesseY,0)* Time.deltaTime;   

    }

    private void tirer(ClickEvent ev)
    {
        projectileEnVie = true;
        projectile = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        projectile.transform.SetParent(conteneurProjectiles, false);
        projectile.transform.localPosition = new Vector3(0,2,0);
        projectile.transform.rotation = Quaternion.Euler(90, 0, 0);
        vitesseY = 1;
        vitesseX = 1;
        //fleche.gameObject.
    }

}
