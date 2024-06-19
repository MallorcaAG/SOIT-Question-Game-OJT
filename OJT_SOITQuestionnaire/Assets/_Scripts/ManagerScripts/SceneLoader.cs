using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene Name Reference")]
    [SerializeField] private string[] sceneNames;

    [Header("Quiz Scenes Setup")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI[] itemTexts;
    [SerializeField] private GameObject[] buttonObjects;

    private QuestionManager questionManager;
    private GameManager gameManager;

    #region Unity Functions
    private void Start()
    {
        questionManager = GameObject.Find("QuestionManager").GetComponent<QuestionManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(questionText == null)
        {
            return;
        }

        Question q = questionManager.GetQuestion;
        questionText.text = q.questionText;

        for(int i = 0; i < q.scrambledArray.Length; i++)
        {
            buttonObjects[i].SetActive(true);
            itemTexts[i].text = q.scrambledArray[i].itemText;

            /* NOTE:
             * 
             * Attach a 'DataHolder' script to all button game object, and assign a Choice scriptable object
             * as one of its fields during runtime. This will be used later to get score of selected choice.
             * 
             * DataHolder script will be used by the Button component to trigger a GameEvent that will
             * send data to GameManager and trigger Scene change.
             * 
             * I think move all these UI assignment stuff to another script.
             */
        }


    }
    #endregion

    public void LoadScene(Component sender, object data)
    {
        Question q = (Question)data;

        switch(q.scrambledArray.Length)
        {
            case 2: //True or False Question
                SceneManager.LoadScene(sceneNames[1]);
                break;

            case 4: 
                if (q.questionType == QuestionSelectionType.radio)
                { //Single-select Multiple Choice 4 items
                    SceneManager.LoadScene(sceneNames[1]);
                }
                else if (q.questionType == QuestionSelectionType.checkbox)
                { //Multi-select Multiple Choice 4 items
                    SceneManager.LoadScene(sceneNames[2]);
                }
                break;

            case 5:
                if (q.questionType == QuestionSelectionType.radio)
                { //Single-select Multiple Choice 5 items
                    SceneManager.LoadScene(sceneNames[1]);
                }
                else if (q.questionType == QuestionSelectionType.checkbox)
                { //Multi-select Multiple Choice 5 items
                    SceneManager.LoadScene(sceneNames[2]);
                }
                break;

            case 33: //Multi-select Multiple Choice 33 items
                SceneManager.LoadScene(sceneNames[3]);
                break;

            default:
                Debug.Log(q.scrambledArray.Length);
                break;
        }
    }

}
