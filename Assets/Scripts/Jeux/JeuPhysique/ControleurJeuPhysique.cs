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
    [SerializeField] private GameObject parentJeu;

    [SerializeField] private Transform conteneurProjectiles;
    [SerializeField] private Transform fleche;

   


    private Slider sliderForce;
    private Slider sliderAngle;
    private Button boutonTirer;
    private bool jeuDebute;
    private float tempsActivationGravitee;

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
        float taille = Random.Range(1.5f,3f);
        planete = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        planete.transform.SetParent(parentJeu.transform);

        //La position pourrait changer si on veut mais jai hard code la position pour le moment
        planete.transform.localPosition = new Vector3(2, 1, 0);
        planete.transform.rotation = Quaternion.Euler(90,0,0);
        planete.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        planete.GetComponent<MeshRenderer>().receiveShadows = false;
            
        planete.transform.localScale =new Vector3(planete.transform.localScale.x * taille * 5, planete.transform.localScale.y, planete.transform.localScale.z * taille * 5);
        gravitee = 0.5f * taille;
    }
    private GameObject planete;
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

    private GameObject projectile;
    private bool projectileEnVie;
    private Vector3 vitesse;
    
    //Le projectile aura une masse de 1 pour simplifier les calculs
    private float gravitee;
    private void bougerProjectile()
    {
        if(tempsActivationGravitee < 0)
        {
            vitesse = vitesse - gravitee * Time.deltaTime * (projectile.transform.position - planete.transform.position);
        }
        else
        {
            tempsActivationGravitee -= Time.deltaTime;
        }


        projectile.transform.position += vitesse * Time.deltaTime;
        

    }
    private readonly float DELAI_GRAVITE = 1;
    private void tirer(ClickEvent ev)
    {
     //   if (projectileEnVie) return;
        projectileEnVie = true;
        projectile = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        projectile.transform.localScale = new Vector3(0.1f, 0.1f,0.1f);
        projectile.transform.SetParent(parentJeu.transform, false);
        projectile.transform.localPosition = conteneurProjectiles.localPosition;
        projectile.transform.rotation = Quaternion.Euler(90, 0, 0);
        float angle = Mathf.Deg2Rad * (-sliderAngle.value + 90);
        float moduleVitesse = Mathf.Sqrt(sliderForce.value / 10) + 30;

        vitesse = new Vector3(moduleVitesse * Mathf.Cos(angle),moduleVitesse * Mathf.Sin(angle),0);
        tempsActivationGravitee = DELAI_GRAVITE;
    }

}
