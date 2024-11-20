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
                SceneManager.LoadScene(i);
                break;

            case "Montre":
                print("ok");
                SceneManager.LoadScene(1);
                PlayerPrefs.SetInt("WorldChoice", 1);
                
                PlayerPrefs.Save();
                
                break;

            case "Tour":
                PlayerPrefs.SetInt("WorldChoice", 2);
                PlayerPrefs.Save();
                break;
            case "Left":
                choiceImage.ShowPreviousImage();
                print("left");
                break;
            case "Right":
                choiceImage.ShowNextImage();
                print("R");
                break;
            case "Select":
                i = choiceImage.GetCurrentIndex() + 2;
                SceneManager.LoadScene(i);
                print("S");
                break;

            default:
                Debug.Log("Tag inconnu : " + buttonTag);
                break;
        }
    }
}

