using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator myTransitions;
    [Header("Quiz Scenes Setup")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI[] itemTexts;
    [SerializeField] private GameObject[] buttonObjects;

    private readonly int Normal = Animator.StringToHash("Normal");
    private readonly int EndQuizTransition = Animator.StringToHash("EndQuizTransition");

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
        questionText.text = "#" + questionManager.CurrentQuestionNumber.ToString() + "\n\t" + q.questionText;

        for (int i = 0; i < q.scrambledArray.Length; i++)
        {
            buttonObjects[i].SetActive(true);
            buttonObjects[i].GetComponent<ItemButton>().setData(q.scrambledArray[i]);
            itemTexts[i].text = q.scrambledArray[i].itemText;
        }

        if(questionManager.CurrentQuestionNumber != 1)
        {
            myTransitions.CrossFade(Normal, 0, 0);
        }
    }
    #endregion

    public void ActivateQuizEndTransition()
    {
        myTransitions.CrossFade(EndQuizTransition, 0, 0);
    }

}
