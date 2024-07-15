using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Codice.Client.Common.GameUI;

enum DialogueType
{
    Static, DynamicResults
}

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ui;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    [SerializeField] private float textDelayBeforeNextLine = 3f;
    [SerializeField] private DialogueType dialogueType;

    private int index;
    private Vector2[] scores;
    private bool isTyping;

    private float remainingTime;

    private void Start()
    {
        remainingTime = textDelayBeforeNextLine;
    }

    public void Initialize(Component sender, object data)
    {
        scores = (Vector2[])data;

        if(dialogueType == DialogueType.DynamicResults)
        {
            DialogueBuilder();
        }

        ui.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if(!isTyping)
        {
            remainingTime -= Time.deltaTime;
        }

        if((remainingTime <= 0))
        {
            if(ui.text == lines[index])
            {
                NextLine();
                remainingTime = textDelayBeforeNextLine;
            }
            else
            {
                StopAllCoroutines();
                ui.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        if (lines[index] == null) yield break;
        foreach (char c in lines[index].ToCharArray())
        {
            isTyping = true;
            ui.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            ui.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    
    void DialogueBuilder()
    {
        int linesScriptLength = 20;
        lines = new string[linesScriptLength];

        string course1 = GameResultsDisplay.getCategory((int)scores[0].x);
        int course1Score = (int)scores[0].y;
        string course2 = GameResultsDisplay.getCategory((int)scores[1].x);
        int course2Score = (int)scores[1].y;
        string lastCourse = GameResultsDisplay.getCategory((int)scores[4].x);
        int lastCourseScore = (int)scores[4].y;


        float mean = (scores[0].y + scores[1].y + scores[2].y + scores[3].y + scores[4].y)/5;
        float course1ToMeanDiff = course1Score - mean;
        float course1ToCourse2Diff = course1Score - course2Score;

        lines[0] = "The results are in!";
        lines[1] = "You’re a "+course1+" major!";
        lines[2] = "Scoring a "+course1Score.ToString()+", "+course1ToMeanDiff.ToString()+" points off the average.";
        lines[3] = "Your second highest course is "+course2+ " with a score of "+course2Score.ToString();
        lines[4] = "That's a " + course1ToCourse2Diff.ToString() + " point difference from your top scoring course.";
        lines[5] = "Your lowest was "+lastCourse+ " with a score of "+lastCourseScore.ToString();
        switch((Category)scores[0].x)
        {
            case Category.CS:
                lines[6] = "Computer Science is . . .";
                lines[7] = "among us";
                lines[8] = "sus";
                lines[9] = "ding ding ding ding";
                lines[10] = "test text";
                break;

            case Category.IT:
                lines[6] = "Information Technology is , no stranger to love";
                lines[7] = "IT knows the rules, and so do I";
                lines[8] = "A full commitments what IT's looking for";
                lines[9] = "Never gunna give you up";
                lines[10] = "test text";
                break;

            case Category.IS:
                lines[6] = "Information System is . . .";
                lines[7] = "Skibidi dop dop dop";
                lines[8] = "yes yes";
                lines[9] = "Skibidi";
                lines[10] = "test text";
                break;

            case Category.EMC:
                lines[6] = "Entertainment and Multimedia Computing is. . .";
                lines[7] = "shikanokonokokoshitantan";
                lines[8] = "shikanokonokokoshitantan";
                lines[9] = "shikanokonokokoshitantan";
                lines[10] = "test text";
                break;

            case Category.DS:
                lines[6] = "Data Science is . . .";
                lines[7] = "text";
                lines[8] = "test";
                lines[9] = "E";
                lines[10] = "test text";
                break;

            default:

                break;
        }

        lines[11] = "Feel free to download the data as reference if you so desire.";
    }






}
