using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racecar : MonoBehaviour {

    public string carName;
    public float minSpeed;
    public float maxSpeed;
    public Transform goal;
    
    public int numRacesWon = 0;

    float speed;
    float timeAtSpeed;
    float startTime;
    bool inProgress;
    Vector3 initialPos;

    void Awake()
    {
        timeAtSpeed = RandomChangeSpeed();
        initialPos = transform.position;
    }

    float RandomSpeed()
    {
        return Random.Range(minSpeed, maxSpeed);
    }

    float RandomChangeSpeed()
    {
        print(carName + " changed speed");
        startTime = Time.time;
        speed = RandomSpeed();
        return Random.Range(2, 4);
    }

    void Update()
    {
        if (timeAtSpeed - (Time.time - startTime) < 0)
        {
            timeAtSpeed = RandomChangeSpeed();
        }

        inProgress = goal.gameObject.GetComponent<Goal>().raceInProgress;
        if (inProgress)
        {
            transform.position = Vector3.MoveTowards(transform.position, goal.position, speed * Time.deltaTime);
        }
    }

    public void ResetCar()
    {
        transform.position = initialPos;
        speed = RandomSpeed();
        timeAtSpeed = RandomChangeSpeed();
    }
}
