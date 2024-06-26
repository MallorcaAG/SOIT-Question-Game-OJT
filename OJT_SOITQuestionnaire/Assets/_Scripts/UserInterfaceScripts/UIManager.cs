using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Quiz Scenes Setup")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI[] itemTexts;
    [SerializeField] private GameObject[] buttonObjects;

    private QuestionManager questionManager;
    private GameManager gameManager;

    // Start is called before the first frame update
    #region Unity Functions
    private void Start()
    {
        questionManager = GameObject.Find("QuestionManager").GetComponent<QuestionManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (questionText == null)
        {
            return;
        }

        Question q = questionManager.GetQuestion;
        questionText.text = q.questionText;

        for (int i = 0; i < q.scrambledArray.Length; i++)
        {
            buttonObjects[i].SetActive(true);
            buttonObjects[i].GetComponent<ItemButton>().setData(q.scrambledArray[i]);
            itemTexts[i].text = q.scrambledArray[i].itemText;

        }


    }
    #endregion

}
