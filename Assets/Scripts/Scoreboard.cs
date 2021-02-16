using UnityEngine.UI;
using UnityEngine;
using System;

public class Scoreboard : MonoBehaviour {

    public Text[] carDisplays;
    public GameObject replay;
    public Racecar[] cars;

    public Goal goal;

    Button replayButton;

    void Awake()
    {
        InitializeScoreboard();
        replay.SetActive(false);
    }

    void InitializeScoreboard()
    {
        int len = cars.Length;
        for (int i = 0; i < len; i++)
        {
            string name = cars[i].carName;
            int numWon = cars[i].numRacesWon;
            carDisplays[i].text = name + ": " + numWon;
        }
    }

    public void UpdateScoreboard(Racecar winner)
    {
        int idx = Array.IndexOf(cars, winner);
        carDisplays[idx].text = winner.carName + ": " + winner.numRacesWon;
        replay.SetActive(true);
    }

    public void Reset()
    {
        replay.SetActive(false);
        int len = cars.Length;
        for(int i = 0; i < len; i++)
        {
            cars[i].ResetCar();
        }
        goal.raceInProgress = true;
    }
    
}
