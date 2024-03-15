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
    [SerializeField] private Material materielVerification;
    [SerializeField] private Transform conteneurProjectiles;
    [SerializeField] private Transform fleche;

   


    private Slider sliderForce;
    private Slider sliderAngle;
    private Button boutonTirer;
    private bool jeuDebute;
    private float tempsActivationGravitee;

    private GameObject projectile;
    private bool projectileEnVie;
    private Vector3 vitesse;

    private GameObject verificateur;

    private readonly float DELAI_GRAVITE = 1;
    private readonly float DELAI_VALIDATION = 2;
    private float tempsValidation;
    private float taille;
    private float distanceCorecte;
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
        distanceCorecte = Random.Range(15, 40) + planete.transform.localScale.x;

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
        verificateur.transform.localScale = new Vector3(verificateur.transform.localScale.x * distanceCorecte , verificateur.transform.localScale.y/10 , verificateur.transform.localScale.z * distanceCorecte);
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
        gravitee = 0.5f * taille;

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
    private void validerCompletion()
    {
        float distance = Mathf.Abs((projectile.transform.position - planete.transform.position).magnitude);
        Debug.Log(distance);

        if (distance <= (projectile.transform.localScale.x /2 + planete.transform.localScale.x /2)) 
        {
            enleverProjectile();
        }
        if( distance < distanceCorecte)
        {
            tempsValidation += Time.deltaTime;

            if (tempsValidation > DELAI_VALIDATION)   
            {
                enleverProjectile();
            }
        }

    }

    

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
    private void enleverProjectile()
    {
        Destroy(projectile);
        projectile = null;
        projectileEnVie = false;
    }
    private void tirer(ClickEvent ev)
    {
        enleverProjectile();
        projectileEnVie = true;
        projectile = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        projectile.transform.localScale = new Vector3(0.1f, 0.1f,0.1f);
        projectile.transform.SetParent(parentJeu.transform, false);
        projectile.transform.localPosition = conteneurProjectiles.localPosition;
        projectile.transform.rotation = Quaternion.Euler(90, 0, 0);
        float angle = Mathf.Deg2Rad * (-sliderAngle.value * 1.5f + 70) ;
        float moduleVitesse = Mathf.Sqrt(sliderForce.value)/5 + 20;

        vitesse = new Vector3(moduleVitesse * Mathf.Cos(angle),moduleVitesse * Mathf.Sin(angle),0);
        tempsActivationGravitee = DELAI_GRAVITE;
        tempsValidation = 0;
    }

}
