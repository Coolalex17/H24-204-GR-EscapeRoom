using UnityEngine;
using UnityEngine.SceneManagement;

public class OverturePause : MonoBehaviour
{
    float delai;
    // Start is called before the first frame update
    void Start()
    {
        delai = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        delai -= Time.deltaTime;
        if (delai < 0f) {
            if (Input.GetButtonDown("Cancel")) {
                if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MenuPause")) {
                    PreferencesJoueur.AssigneScenePrecedente(SceneManager.GetActiveScene().buildIndex);
                    SceneManager.LoadScene("MenuPause");
                    Cursor.lockState = CursorLockMode.Confined;
                } else {
                    SceneManager.LoadScene(PreferencesJoueur.getScenePrecedente());
                }

            }
        }

    }
}
