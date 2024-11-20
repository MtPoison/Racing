using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bouton : MonoBehaviour
{
    public Button[] buttons; 

    void Start()
    {
        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    void OnButtonClick(Button clickedButton)
    {
        string buttonTag = clickedButton.tag;

        switch (buttonTag)
        {
            case "Restart":
                SceneManager.LoadScene(0);
                break;

            case "Settings":
                Debug.Log("Ouvrir les paramètres !");
                // Exemple d'action : Afficher un menu d'options
                break;

            case "Quit":
                Debug.Log("Quitter le jeu !");
                // Exemple d'action : Quitter l'application
                Application.Quit();
                break;

            default:
                Debug.Log("Tag inconnu : " + buttonTag);
                break;
        }
    }
}

