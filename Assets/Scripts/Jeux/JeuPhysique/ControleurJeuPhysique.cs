using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        }
    }
    private void tirer(ClickEvent ev)
    {

    }

}
