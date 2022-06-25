using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountersScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI jumpsMadeText;
    [SerializeField] TextMeshProUGUI scoreText;
    public static CountersScript Instance { get; private set; }

    public static int jumpsMade;
    public static int score;
    private TimeSpan timeCount;
    private float t;
    public bool isGameRunning = false;

    private void Awake()
    {
        Instance = this;
        isGameRunning = true;
    }

    private void Start()
    {
        jumpsMade = 0;
        score = 0;
        t = 0;
        timeText.text = "Time: 00:00:00";
        StartCoroutine(UpdateTimer());
    }

    private void Update()
    {
        timeText.text = "Time: " + t;
        scoreText.text = "Score: " + score;
        jumpsMadeText.text = "Jumps made: " + jumpsMade;        
    }

    //void BeginTimer()
    //{
    //    t = 0f;
    //    StartCoroutine(UpdateTimer());
    //}

    private IEnumerator UpdateTimer()
    {
        while (isGameRunning)
        {
            t += Time.deltaTime;
            timeCount = TimeSpan.FromSeconds(t);
            string timePlayingStr = "Time: " + timeCount.ToString("mm':'ss'.'ff");
            timeText.text = timePlayingStr;

            yield return null;

        }
        
    }
}
