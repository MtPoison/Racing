using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bouton : MonoBehaviour
{
    public Button[] buttons;
    private ChoiceImage choiceImage;
    
    int i;
    [SerializeField] private GameObject canvaSkin;
    [SerializeField] private Starting start;
    [SerializeField] private GameObject starting;
    [SerializeField] private GameManager gameManager;
    void Start()
    {
        
        choiceImage = FindObjectOfType<ChoiceImage>();
        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    public void OnButtonClick(Button clickedButton)
    {
        string buttonTag = clickedButton.tag;

        switch (buttonTag)
        {
            case "Restart":
                i = PlayerPrefs.GetInt("MapChoice", 0);
                SceneManager.LoadScene(i);
                break;

            case "Montre":
                print("ok");
                SceneManager.LoadScene(1);
                PlayerPrefs.SetInt("WorldChoice", 1);
                PlayerPrefs.Save();
                
                break;

            case "Tour":
                SceneManager.LoadScene(1);
                PlayerPrefs.SetInt("WorldChoice", 2);
                PlayerPrefs.Save();
                break;
            case "Left":
                choiceImage.ShowPreviousImage();
                print("left");
                break;
            case "Right":
                choiceImage.ShowNextImage();
                break;
            case "Select":
                i = choiceImage.GetCurrentIndex() + 2;
                PlayerPrefs.SetInt("MapChoice", i);
                PlayerPrefs.Save();
                SceneManager.LoadScene(i);
                print("S");
                break;

            case "Play":
                choiceImage.SetSkinCar();
                canvaSkin.SetActive(false);
                gameManager.IsStarting();
                start.IsCountdown();
                break;
            case "Main":
                SceneManager.LoadScene(0);
                break;
            case "Leave":
                Application.Quit();
                break;

            default:
                Debug.Log("Tag inconnu : " + buttonTag);
                
                break;
        }
    }
}

