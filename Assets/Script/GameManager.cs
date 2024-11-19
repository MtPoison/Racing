using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int nbTour;

    private void Start()
    {
        nbTour = 0;
    }

    public void AddTour()
    {
        nbTour++;
    }

    public int GetTour()
    {
        return nbTour;
    }
}
