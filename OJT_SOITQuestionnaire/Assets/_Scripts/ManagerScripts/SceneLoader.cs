using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene Name Reference")]
    [SerializeField] private string[] sceneNames;

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
