using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class JeuDrapeau : MonoBehaviour //ChatGPT
{
    public Image flagImage;
    public List<Sprite> flagSprites; // List to hold flag sprites
    public Button[] optionButtons; // Buttons to display country names
    public Text timerText;
    public Text scoreText;

    private int correctIndex;
    private int score = 0;
    private float timer = 3.0f;
    private bool isPlaying = true;
    public Text finPartie;

    void Start()
    {
        scoreText.text = "Score : " + score;
        NextFlag();
    }

    void Update()
    {
        if (!isPlaying) return;

        timer -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Round(timer).ToString();

        if (timer <= 0)
        {
            NextFlag();
        }
    }

    void NextFlag()
    {
        if (score >= 20)
        {
            Debug.Log("Win!");
            finPartie.gameObject.SetActive(true); // Show win message
            isPlaying = false; // Stop the game logic
            foreach (var button in optionButtons)
            {
                button.interactable = false; // Disable all answer buttons
            }
            timerText.gameObject.SetActive(false); // Optionally hide the timer
            return;
        }

        timer = 3.0f; // Reset the timer

        int flagIndex = Random.Range(0, flagSprites.Count);
        flagImage.sprite = flagSprites[flagIndex];

        correctIndex = Random.Range(0, optionButtons.Length);
        List<int> usedIndices = new List<int>(); // To avoid repeating countries

        for (int i = 0; i < optionButtons.Length; i++)
        {
            int buttonIndex = i; // Capture the current index in a local variable
            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(() => Answer(buttonIndex));

            if (i == correctIndex)
            {
                optionButtons[i].GetComponentInChildren<Text>().text = GetCountryName(flagSprites[flagIndex].name);
            }
            else
            {
                Sprite incorrectFlag;
                int randomIndex;
                do
                {
                    randomIndex = Random.Range(0, flagSprites.Count);
                    incorrectFlag = flagSprites[randomIndex];
                } while (incorrectFlag.name == flagSprites[flagIndex].name || usedIndices.Contains(randomIndex));

                optionButtons[i].GetComponentInChildren<Text>().text = GetCountryName(incorrectFlag.name);
                usedIndices.Add(randomIndex); // Add this index to the used list
            }
        }
    }


    void Answer(int index)
    {
        Debug.Log("Answer Index: " + index + ", Correct Index: " + correctIndex);
        if (index == correctIndex)
        {
            score++;
            scoreText.text = "Score: " + score;
            Debug.Log("Score Updated: " + score); // Confirm score is updated
        }
        NextFlag();
    }


    string GetCountryName(string flagName)
    {
        // Assuming the flag's name is the country name; adjust if it's not
        return flagName;
    }
}

