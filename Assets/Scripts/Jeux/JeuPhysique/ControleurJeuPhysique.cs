using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UIElements;

public class ControleurJeuPhysique : MonoBehaviour
{
    //Elemments du UI 
    [SerializeField] private UIDocument UIJeu;
    [SerializeField] private Camera cameraJoueur;
    [SerializeField] private Camera cameraJeuPhysique;

    //Parents qui seront utilise pour assigner les projectiles et autres objets
    [SerializeField] private GameObject parentJeu;
    [SerializeField] private Transform conteneurProjectiles;


    [SerializeField] private Material materielVerification;


    [SerializeField] private Transform fleche;

   


    private Slider sliderForce;
    private Slider sliderAngle;
    private Button boutonTirer;
    private bool jeuDebute;

    private GameObject projectile;
    private bool projectileEnVie;
    private Vector3 vitesse;

    private GameObject verificateur;

    private readonly float DELAI_VALIDATION = 5f;
    private float tempsValidation;
    private float taille;
    private float distanceValidation;
    private readonly Vector3 POSITION_PLANETE = new Vector3(2, 1, 0);

    //Le projectile aura une masse de 1 pour simplifier les calculs
    private float gravitee;
    


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
        creerPlanete();

        creerVerificateurDistance();
    }
    private void creerVerificateurDistance()
    {
        distanceValidation = Random.Range(35, 60) + planete.transform.localScale.x;

        verificateur = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        verificateur.transform.SetParent(parentJeu.transform);

        //La position pourrait changer si on veut mais jai hard code la position pour le moment
        verificateur.transform.localPosition = POSITION_PLANETE;
        verificateur.transform.rotation = Quaternion.Euler(90, 0, 0);

        //Enleve les ombres de lobjet
        verificateur.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        verificateur.GetComponent<MeshRenderer>().receiveShadows = false;
        verificateur.GetComponent<MeshRenderer>().material = materielVerification;

        //Change la taille et la gravitee
        verificateur.transform.localScale = new Vector3(verificateur.transform.localScale.x * distanceValidation, verificateur.transform.localScale.y/10 , verificateur.transform.localScale.z * distanceValidation );


    }


    private void creerPlanete()
    {
        taille = Random.Range(1.5f, 3f);


        planete = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        planete.transform.SetParent(parentJeu.transform);

        //La position pourrait changer si on veut mais jai hard code la position pour le moment
        planete.transform.localPosition = POSITION_PLANETE;
        planete.transform.rotation = Quaternion.Euler(90, 0, 0);

        //Enleve les ombres de lobjet
        planete.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        planete.GetComponent<MeshRenderer>().receiveShadows = false;

        //Change la taille et la gravitee
        planete.transform.localScale = new Vector3(planete.transform.localScale.x * taille * 5, planete.transform.localScale.y, planete.transform.localScale.z * taille * 5);


        gravitee =  2f * taille;

    }
    private GameObject planete;
    private void FixedUpdate()
    {
        if (jeuDebute) {
            conteneurProjectiles.rotation = Quaternion.Euler(0f, 0f, -sliderAngle.value * 1.5f - 20);
            fleche.localScale =new Vector3(1, (sliderForce.value/100) + 0.5f, 1);
            fleche.localPosition = new Vector3(0, (sliderForce.value / 100 + 1.6f) / 2 + 0.2f, 0);

            if (projectileEnVie)
            {
                bougerProjectile();
                validerCompletion();
            }
        }
        
        
    }
    private float obtenirDistance()
    {
        return Mathf.Abs((projectile.transform.position - planete.transform.position).magnitude);
    }
    private void validerCompletion()
    {
        float distance = obtenirDistance();
        if (distance <= (projectile.transform.localScale.x + planete.transform.localScale.x) * 5) 
        {
            enleverProjectile();
        }
        if( distance*2 < distanceValidation)
        {
            tempsValidation += Time.deltaTime;
            Debug.Log(tempsValidation);
            if (tempsValidation > DELAI_VALIDATION)   
            {
                enleverProjectile();
            }
        }
        else if (tempsValidation > 0)
        {
            
            tempsValidation -= Time.deltaTime;
        }

    }


    private float delaiGravite = 1;
    private float activationGravite;

    private void bougerProjectile()
    {
        //Version 1
        
        if(activationGravite < delaiGravite)
        {
            activationGravite += Time.deltaTime;
        }
        else
        {
          
            vitesse = vitesse - gravitee * Time.deltaTime * (projectile.transform.position - planete.transform.position);

        }
        



        //Version 2
        /*
         
        //Verifie que le joueur est dans un certain rayon de la planete
        if(obtenirDistance() < distanceValidation)
        {
            vitesse = vitesse - gravitee * Time.deltaTime * (projectile.transform.position - planete.transform.position);
        }*/



        projectile.transform.position += vitesse * Time.deltaTime;
        
    }
    private void enleverProjectile()
    {// Enleve le projectile lorsque necessaire
        Destroy(projectile);
        projectile = null;
        projectileEnVie = false;
    }
    private void tirer(ClickEvent ev)
    {
        //Enleve le projectile qui aurai pu etre deja present
        enleverProjectile();

        //Creer le projectile
        projectileEnVie = true;
        projectile = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        //Change sa taille
        projectile.transform.localScale = new Vector3(0.1f, 0.1f,0.1f);

        //modifie la position et la rotation du projectile par rapport au jeu de physique
        projectile.transform.SetParent(parentJeu.transform, false);
        projectile.transform.localPosition = conteneurProjectiles.localPosition;
        projectile.transform.rotation = Quaternion.Euler(90, 0, 0);

        //Calcule langle et la vitesse du projectile
        float angle = Mathf.Deg2Rad * (-sliderAngle.value * 1.5f + 70) ;
        float moduleVitesse = Mathf.Sqrt(sliderForce.value) * 1.5f + 20;
        vitesse = new Vector3(moduleVitesse * Mathf.Cos(angle),moduleVitesse * Mathf.Sin(angle),0);
       
        //Reset le temps pour valider le defi et le temps avant lactivation de la gravitee
        tempsValidation = 0;
        activationGravite = 0;
    }

}
