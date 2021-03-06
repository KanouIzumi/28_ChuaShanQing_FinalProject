﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Controller : MonoBehaviour
{

    public static GameManager_Controller instance;

    public GameObject EnermyPrefab;
    public int numberOfSpawn;

    //Timer
    int timeCountInt;
    float timerCount = 60;
    bool isStartCount;
    public GameObject timerTextGO;

    // Start is called before the first frame update
    void Start()
    {
        isStartCount = true;

        if (instance == null)
        {
            instance = this;
        }

        //This code is for the random spawn
        for (int i = 0; i < numberOfSpawn; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));

            if (Random.Range(0, 2) < 1)
            {
                Instantiate(EnermyPrefab, randomPos, Quaternion.identity);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartCount == true)
        {
            timerCountDown();
        }

    }

    private void timerCountDown()
    {
        if (timerCount > 0)
        {
            timerCount -= Time.deltaTime;
            timeCountInt = Mathf.RoundToInt(timerCount);
            timerTextGO.GetComponent<Text>().text = "Timer: " + timeCountInt;
        }

        else if (timerCount < 1)
        {
            timerCount = 60.0f;
            isStartCount = false;
        }
    }
}
