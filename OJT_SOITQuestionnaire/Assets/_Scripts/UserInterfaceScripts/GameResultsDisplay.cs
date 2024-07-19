using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;

public class GameResultsDisplay : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI display;
    [SerializeField] private GameEvent onStatChange;
    [SerializeField] private GameEvent onCourseVideoStart;
    [SerializeField] private Animator myAnimation;
    [SerializeField] private UI_StatsRadarChart uiStatsRadarChart;
    [SerializeField] private TextMeshProUGUI[] scoreDisplay;

    private Stats stats;

    private int[] scores;
    private Vector2[] scoresRanked;
    private GameManager gameManager;
    private string scoreString;
    private int scoreTotal;

    private readonly int StartVid = Animator.StringToHash("CourseVideoStart");
    private readonly int EndVid = Animator.StringToHash("CourseVideoEnd"); 
private readonly int OutroAnimation = Animator.StringToHash("OutroAnimation");
    private readonly int TalkingDone = Animator.StringToHash("TalkingDone");

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scores = gameManager.Scores;
        scoresRanked = gameManager.ScoresRanking;
        onStatChange.Raise(this, scoresRanked);

        for (int i = 0; i < scoresRanked.Length; i++)
        {
            /*Debug.Log(getCategory((int)scores[i].x) + " = " + scores[i].y);*/
            scoreString += (getCategory((int)scoresRanked[i].x) + " = " + (scoresRanked[i].y).ToString() + "\n");
            scoreTotal += (int)scoresRanked[i].y;

            switch ((int)scoresRanked[i].x)
            {
                case (int)Category.CS:
                    scoreDisplay[0].text = (scoresRanked[i].y).ToString();
                    break;
                case (int)Category.IT:
                    scoreDisplay[1].text = (scoresRanked[i].y).ToString();
                    break;
                case (int)Category.IS:
                    scoreDisplay[2].text = (scoresRanked[i].y).ToString();
                    break;
                case (int)Category.EMC:
                    scoreDisplay[3].text = (scoresRanked[i].y).ToString();
                    break;
                case (int)Category.DS:
                    scoreDisplay[4].text = (scoresRanked[i].y).ToString();
                    break;
                default:
                    break;
            }
        }

        scoreString += scoreTotal.ToString();

        //display.text = scoreString;
        Debug.Log(scoreString);

        Stats.STAT_MAX = (int)scoresRanked[0].y;
        stats = new Stats(scores[0], scores[1], scores[2], scores[3], scores[4]);

        uiStatsRadarChart.SetStats(stats);
    }

    public void startAnimation()
    {
        uiStatsRadarChart.ActivateAnimation();
    }

    public void animationState(Component sender, object data)
    {
        int num = (int)data;

        switch (num)
        {
            case 1:
                myAnimation.CrossFade(StartVid, 0, 0);

                onCourseVideoStart.Raise(this, getCategory((int)scoresRanked[0].x));
                break;

            case 2:
                myAnimation.CrossFade(EndVid, .5f, 0);

                break;

            case 4:
                Debug.Log("I die");

                Application.Quit();

                break;
        }
    }

    public void finalAnimation()
    {
        myAnimation.CrossFade(OutroAnimation, 1f, 0);

        StartCoroutine(die());
    }

    IEnumerator die()
    {
        Debug.Log("I die");

        yield return new WaitForSeconds(23.5f);

        Time.timeScale = 0;
        Application.Quit();
        //EditorApplication.Exit(0);

        Debug.Log("didnt die whoops???");
    }

    public void adjustStatsGraphPosition()
    {
        myAnimation.CrossFade(TalkingDone, 0.5f, 0);
    }

    public static string getCategory(int x)
    {
        switch (x)
        {
            case (int)Category.CS:
                return "CS";
            case (int)Category.IT:
                return "IT";
            case (int)Category.IS:
                return "IS";
            case (int)Category.EMC:
                return "EMC";
            case (int)Category.DS:
                return "DS";
            default:
                return "na";
        }
    }



}