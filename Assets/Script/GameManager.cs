using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject endGameCanvas;
    [SerializeField] private GameObject UiCanvas;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private Round round;
    [SerializeField] private TimerCount timer;
    [SerializeField] private CarControler car;
    [SerializeField] private Save save;
    [SerializeField] private Starting startt;

    [SerializeField] private TMP_Text bestTime;
    [SerializeField] private TMP_Text tempsRestant;
    [SerializeField] private TMP_Text bestRound;
    [SerializeField] private TMP_Text Etat;

    private PlayerControler playerControls;
    private InputAction menuToggleAction;
    private End end;

    private int worldChoice;
    private bool endPanelHasAppeared = false;
    private bool starting = false;
    private bool isMenuActive = false;
    private bool stopTimerMenu = false;
    private bool saveScore = true;
    private int i;

    private void Start() 
    {
        end = FindObjectOfType<End>();
        endGameCanvas.SetActive(false);
        player.SetActive(false);
        start.SetActive(false);
        timer.StopCountdown();
        endPanelHasAppeared = false;
        worldChoice = PlayerPrefs.GetInt("WorldChoice", 0);
        i = PlayerPrefs.GetInt("MapChoice", 0);
    }

    private void OnEnable()
    {
        playerControls = new PlayerControler();
        menuToggleAction = playerControls.Player.Menu;

        menuToggleAction.performed += ToggleMenuAction;

        menuToggleAction.Enable();
    }

    private void OnDisable()
    {
        menuToggleAction.Disable();
        menuToggleAction.performed -= ToggleMenuAction;
    }
    private void Update()
    {
        if(isMenuActive)
        {
            timer.StopCountdown();
            car.PoseGame();
        }
        else {
            if(stopTimerMenu)
            {
                timer.ActiveCountdown();
            }
            car.IsPoseGame();
        }
        if(starting)
        {
            start.SetActive(true);
            timer.StopCountdown();


        }
        else
        {
            start.SetActive(false);
            if(!startt.GetTest())
            {
                timer.ActiveCountdown();
                startt.GetTest(true);
            }
                

        }
        if (worldChoice == 1)
        {
            if (round.GetTour() > round.GetTotalTour() || timer.getCurentime() == 0)
            {
                if (endPanelHasAppeared)
                    return;

                if (timer.getCurentime() > 0)
                {
                    timer.StopCountdown();
                    Etat.text = "Win";
                }
                else
                {
                    Etat.text = "Loose";
                }
                tempsRestant.text = $"{ConvertMinute(timer.getCurentime())}";

                GetMinValueAndIndex(end.GetTours());
                endGameCanvas.SetActive(true);
                player.SetActive(false);
                endPanelHasAppeared = true;
                Debug.Log("fin");
            }
        }
        else if(timer.getCurentime() == 0)
        {
            Etat.text = "Time Over";
            if (save.GetCardScore(i) < round.GetTour())
            {
                save.UpdateCardScore(i,round.GetTour());
            }
            tempsRestant.text = $"{save.GetCardScore(i)}";
            GetMinValueAndIndex(end.GetTours());
            endGameCanvas.SetActive(true);
            player.SetActive(false);
            endPanelHasAppeared = true;
            bestRound.text = "Best Round";
        }
    }

    private void ToggleMenuAction(InputAction.CallbackContext context)
    {
        isMenuActive = !isMenuActive;

        stopTimerMenu = true;
        print(stopTimerMenu);
        if (isMenuActive)
        {
            mainMenu.SetActive(true);
        }
        else
        {
            mainMenu.SetActive(false);
        }
    }

    public void IsStarting() { starting = true; }

    public void EndStarting() { starting = false; }
   
    public void GetMinValueAndIndex(List<float> floats)
    {
        if (floats.Count == 0)
        {
            throw new ArgumentException("La liste est vide !");
        }

        float minValue = floats[0];
        int minIndex = 0;

        for (int i = 1; i < floats.Count; i++)
        {
            if (floats[i] < minValue)
            {
                minValue = floats[i];
                minIndex = i;
            }
        }
        bestTime.text = $"Meilleure tour {minIndex + 1:D2}  {ConvertMinute(minValue)}";
    }

    private string ConvertMinute( float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return $"{minutes:D2}:{seconds:D2}";
    }
}
