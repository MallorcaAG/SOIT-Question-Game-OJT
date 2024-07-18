using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public Vector2[] scoresOrderRanking;
    public float[] statisticsData;
    public int CS_MAXTotal = 173, IT_MAXTotal = 181, IS_MAXTotal = 172, EMC_MAXTotal = 197, DS_MAXTotal = 168;
    public int CS_MAXTotalMini = 67, IT_MAXTotalMini = 65, IS_MAXTotalMini = 71, EMC_MAXTotalMini = 69, DS_MAXTotalMini = 67;

    public TextMeshProUGUI dataDisplay;

    public void ReceiveScoreRanking(Component sender, object data)
    {
        if(data != null)
        {
            scoresOrderRanking = (Vector2[])data;
        }
    }

    public void ReceiveStatisticsData(Component sender, object data)
    {
        statisticsData = (float[])data;
    }

    public void setDataDisplay()
    {

        string course1 = GameResultsDisplay.getCategory((int)scoresOrderRanking[0].x);
        string course2 = GameResultsDisplay.getCategory((int)scoresOrderRanking[1].x);
        string course3 = GameResultsDisplay.getCategory((int)scoresOrderRanking[2].x);
        string course4 = GameResultsDisplay.getCategory((int)scoresOrderRanking[3].x);
        string course5 = GameResultsDisplay.getCategory((int)scoresOrderRanking[4].x);


        string text = "Total Score: " + statisticsData[0].ToString("0.##") + "\n" +
                      "Mean: " + statisticsData[1].ToString("0.##") + "\n" +
                      "Median: " + statisticsData[2].ToString("0.##") + "\n" +
                      course1 + ": " + scoresOrderRanking[0].y + "pts (" + statisticsData[5].ToString("0.##") + "%)\n" +
                      course2 + ": " + scoresOrderRanking[1].y + "pts (" + statisticsData[6].ToString("0.##") + "%)\n" +
                      course3 + ": " + scoresOrderRanking[2].y + "pts (" + statisticsData[7].ToString("0.##") + "%)\n" +
                      course4 + ": " + scoresOrderRanking[3].y + "pts (" + statisticsData[8].ToString("0.##") + "%)\n" +
                      course5 + ": " + scoresOrderRanking[4].y + "pts (" + statisticsData[9].ToString("0.##") + "%)\n" +
                      course1 + " to mean diff: " + statisticsData[3].ToString("0.##") + "%\n" +
                      "% diff (" + course1 + ", Mean): +" + Mathf.Abs(((statisticsData[1] / scoresOrderRanking[0].y) - 1) * 100).ToString("0.##") + "%\n" +
                      course1 + " to " + course2 + "diff: " + statisticsData[3].ToString("0.##") + "%\n" +
                      "% diff (" + course1 + ", " + course2 + "): " + Mathf.Abs(((scoresOrderRanking[1].y / scoresOrderRanking[0].y) - 1) * 100).ToString("0.##") + "\n";


        dataDisplay.text = text;
    }

}
