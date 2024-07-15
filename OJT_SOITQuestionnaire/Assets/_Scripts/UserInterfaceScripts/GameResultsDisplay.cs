using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class GameResultsDisplay : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI display;
    [SerializeField] private GameEvent onStatChange;
    [SerializeField] private UI_StatsRadarChart uiStatsRadarChart;

    private Stats stats;

    private int[] scores;
    private Vector2[] scoresRanked;
    private GameManager gameManager;
    private string scoreString;
    private int scoreTotal;

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
        }

        scoreString += scoreTotal.ToString();

        //display.text = scoreString;
        Debug.Log(scoreString);

        Stats.STAT_MAX = (int)scoresRanked[0].y;
        stats = new Stats(scores[0], scores[1], scores[2], scores[3], scores[4]);

        uiStatsRadarChart.SetStats(stats);
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