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

    //Materiaux qui sont utilise et seront change au cours du jeu
    [SerializeField] private Material materielVerification;
    [SerializeField] private Material materielVert;
    [SerializeField] private Material materielPlanete;
    [SerializeField] private Material materielBalle;

    
    [SerializeField] private ParticleSystem explosion;  
    [SerializeField] private Transform fleche;


    private GameObject planete;


    private Slider sliderForce;
    private Slider sliderAngle;
    private Button boutonTirer;
    private Label messageInformation; 
    private bool jeuDebute;

    private GameObject projectile;
    private bool projectileEnVie;
    private Vector3 vitesse;

    private GameObject verificateur;
    private GameObject cercleVert;

    private readonly float DELAI_VALIDATION = 5f;
    private float tempsValidation;
    private float taille;
    private float distanceValidation;
    private readonly Vector3 POSITION_PLANETE = new Vector3(2, 1, 0);

    //Le projectile aura une masse de 1 pour simplifier les calculs
    private float gravitee;

    [SerializeField] private GameObject Background;
    private float tempsShake;
   
    


    void Start(){
        projectileEnVie = false;
        //Trouve les elements du UI necessaire au fonctionnement du code
        sliderForce = UIJeu.rootVisualElement.Q<Slider>("SliderForce");
        sliderAngle = UIJeu.rootVisualElement.Q<Slider>("SliderRotation");
        boutonTirer = UIJeu.rootVisualElement.Q<Button>("BoutonTirer");
        messageInformation = UIJeu.rootVisualElement.Q<Label>("Message");

        UIJeu.rootVisualElement.Q<GroupBox>("BoiteBoutons").style.visibility = Visibility.Hidden;
        messageInformation.style.visibility = Visibility.Hidden;
        cameraJeuPhysique.enabled = false;
        jeuDebute = false;

        boutonTirer.RegisterCallback<ClickEvent>(tirer);
    }
    public void debuterJeu(MouvementJoueur joueur){
        joueur.StopperMouvement();
        jeuDebute = true;
        UIJeu.rootVisualElement.Q<GroupBox>("BoiteBoutons").style.visibility = Visibility.Visible;
        messageInformation.style.visibility= Visibility.Visible;
        modifierTexte("Envoyez un projectile dans le cercle");
        cameraJoueur.enabled = false;
        cameraJeuPhysique.enabled = true;
        creerPlanete();
        creerVerificateurDistance();
        creerCercleVert();
        mouvementJoueur = joueur;
    }
    private MouvementJoueur mouvementJoueur;
    private void terminerJeu(){
        jeuDebute = false;
        UIJeu.rootVisualElement.Q<GroupBox>("BoiteBoutons").style.visibility = Visibility.Hidden;
        cameraJoueur.enabled = true;
        cameraJeuPhysique.enabled = false;
        enleverProjectile();
        Destroy(planete);
        Destroy(verificateur);
        Destroy(cercleVert);
        mouvementJoueur.demarerJoueur();
        PreferencesJoueur.GetSavedInventaire().Add(Inventaire.Items.CLEE_ROUGE);
        PreferencesJoueur.FinirJeuPhysique();
    }
    private void creerVerificateurDistance(){
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
        verificateur.transform.localScale = new Vector3(verificateur.transform.localScale.x * (distanceValidation + 40), verificateur.transform.localScale.y/10 , verificateur.transform.localScale.z * (distanceValidation + 40) );
    }
    private void grandirCerlceVert(){
        cercleVert.transform.localScale = new Vector3((verificateur.transform.localScale.x) * tempsValidation / DELAI_VALIDATION, 1/ 10.1f,verificateur.transform.localScale.z * tempsValidation/DELAI_VALIDATION);
    }
    private void creerCercleVert(){
        cercleVert = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cercleVert.transform.SetParent(parentJeu.transform);

        //La position pourrait changer si on veut mais jai hard code la position pour le moment
        cercleVert.transform.localPosition = POSITION_PLANETE;
        cercleVert.transform.rotation = Quaternion.Euler(90, 0, 0);

        //Enleve les ombres de lobjet
        cercleVert.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        cercleVert.GetComponent<MeshRenderer>().receiveShadows = false;
        cercleVert.GetComponent<MeshRenderer>().material = materielVert;

  
        
        grandirCerlceVert();
    }

    private void creerPlanete(){//Cree la planete autour de laquelle le joueur devra faire modifier la gravitee et modifie la gravite
        taille = Random.Range(1.5f, 3f);
        planete = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        planete.transform.SetParent(parentJeu.transform);

        //La position pourrait changer si on veut mais jai hard code la position pour le moment
        planete.transform.localPosition = POSITION_PLANETE;
        planete.transform.rotation = Quaternion.Euler(90, 0, 0);

        //Enleve les ombres de lobjet
        planete.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        planete.GetComponent<MeshRenderer>().receiveShadows = false;
        planete.GetComponent<MeshRenderer>().material = materielPlanete;

        //Change la taille et la gravitee
        planete.transform.localScale = new Vector3(planete.transform.localScale.x * taille * 5, planete.transform.localScale.y, planete.transform.localScale.z * taille * 5);

        gravitee =  2f * taille;
    }
    private void FixedUpdate(){
        if (jeuDebute) {
            conteneurProjectiles.rotation = Quaternion.Euler(0f, 0f, -sliderAngle.value * 1.5f - 20);
            fleche.localScale =new Vector3(1, (sliderForce.value/200) + 0.5f, 1);
            fleche.localPosition = new Vector3(0, (sliderForce.value / 200 + 1.6f) / 2 + 0.2f, 0);
            if (projectileEnVie){
                bougerProjectile();
                validerCompletion();
            }
            if (tempsShake >0){
                ShakeBackground();
            }
            updaterTexte();
        }   
    }
    private void modifierTexte(string message)
    {
        messageInformation.text = message;
        messageInformation.style.opacity = 100;
        opaciteeActuelle = 1;
        delaiOpacitee = TempsOpacitee;
    }
    private float delaiOpacitee;
    private readonly float TempsOpacitee = 1;
    private float opaciteeActuelle;
    private void updaterTexte()
    {
        if (delaiOpacitee > 0)
        {
            delaiOpacitee -= Time.deltaTime;
        }
        else
        {
            opaciteeActuelle -= Time.deltaTime * 10;
            messageInformation.style.opacity = opaciteeActuelle;
        }
    }
    private float obtenirDistance(){
        return Mathf.Abs((projectile.transform.position - planete.transform.position).magnitude);
    }
    private void validerCompletion(){
        float distance = obtenirDistance();
        if (distance <= (projectile.transform.localScale.x + planete.transform.localScale.x) * 5) {
            modifierTexte("Envoyez un projectile en orbite");
            enleverProjectile();
        }
        //Le +40 ajoute une marge derreur au joueur
        if( distance*2 < distanceValidation + 40){
            tempsValidation += Time.deltaTime;   
            if (tempsValidation > DELAI_VALIDATION){
                enleverProjectile();
                terminerJeu();
            }
        }
        else if (tempsValidation > 0){   
            tempsValidation -= Time.deltaTime;
        }
        grandirCerlceVert();
    }
    private float delaiGravite = 1;
    private float activationGravite;
    private void bougerProjectile(){
        float distanceAvant = (projectile.transform.position - planete.transform.position).magnitude;
        if(activationGravite < delaiGravite){
            activationGravite += Time.deltaTime;
        }else{
              vitesse = vitesse - gravitee * Time.deltaTime * (projectile.transform.position - planete.transform.position);
        }
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

        projectile.GetComponent<MeshRenderer>().material = materielBalle;

        //Reset le temps pour valider le defi et le temps avant lactivation de la gravitee
        tempsValidation = 0;
        activationGravite = 0;

        //Fait des effets visuels
        explosion.Play();
        if (tempsShake <= 0){
            tempsShake = 0.5f;
        }
        //TODO jouer un effet sonore lorsque le joueur tire

    }
    private void ShakeBackground()
    {

            Background.transform.position = new Vector3(Background.transform.position.x + Mathf.Sin(tempsShake * 5 *  2 * 360 * Mathf.Deg2Rad), Background.transform.position.y, Background.transform.position.z);

        Background.transform.position = new Vector3(Background.transform.position.x , Background.transform.position.y + Mathf.Sin(tempsShake * 4 * 2 *  360 * Mathf.Deg2Rad) * 1.2f, Background.transform.position.z);

        tempsShake -= Time.deltaTime;    
    }

}
