using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    
    public bool raceInProgress = true;
    public Scoreboard scoreboard;

	void OnTriggerEnter(Collider winner)
    {
        Racecar car = winner.transform.parent.GetComponent<Racecar>();
        print(car.carName);
        raceInProgress = false;
        car.numRacesWon++;
        scoreboard.UpdateScoreboard(car);
    }

}
