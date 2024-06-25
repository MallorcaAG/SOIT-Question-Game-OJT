using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameResultsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI display;

    private Vector2[] scores;
    private GameManager gameManager;
    private string scoreString;
    private int scoreTotal;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scores = gameManager.Scores;

        for (int i = 0; i < scores.Length; i++)
        {
            /*Debug.Log(getCategory((int)scores[i].x) + " = " + scores[i].y);*/
            scoreString += (getCategory((int)scores[i].x) + " = " + (scores[i].y).ToString() + "\n");
            scoreTotal += (int)scores[i].y;
        }

        scoreString += scoreTotal.ToString();

        display.text = scoreString;
    }

    private string getCategory(int x)
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
//Percentage (Add scores, divide certain score from the total) etc etc