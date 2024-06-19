using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    static QuestionManager instance;
    [Space]
    [Header("Manager")]
    [SerializeField] private int currentQuestion = 0;
    [Space]
    [Header("Setup")]
    [SerializeField] private Question[] questions;
    [SerializeField] private bool scrambleQuestions;
    [SerializeField] private Question[] scrambledQuestionsArray;

    [Header("Event Reference")]
    [SerializeField] private GameEvent onSendQuestionDetails;

    #region Encapsulation methods
    public int CurrentQuestion
    {
        get { return currentQuestion; }
    }
    public void nextQuestion()
    {
        currentQuestion++;
    }
    public Question GetQuestion
    {
        get { return scrambledQuestionsArray[currentQuestion]; }
    }
    #endregion

    #region Question Shuffler
    public void shuffleQuestions()
    {
        copyArray();
        Question[] questionsCopy = scrambledQuestionsArray;
        int l = questions.Length;
        System.Random rand = new System.Random();

        for (int i = 0; i < l; i++)
        {
            swap(questionsCopy, i, i + rand.Next(l - i));
        }

        scrambledQuestionsArray = questionsCopy;
    }

    private void copyArray()
    {
        scrambledQuestionsArray = new Question[questions.Length];
        for (int i = 0; i < questions.Length; i++)
        {
            scrambledQuestionsArray[i] = questions[i];
        }
    }

    private void swap(Question[] arr, int first, int second)
    {
        Question temp = arr[first];
        arr[first] = arr[second];
        arr[second] = temp;
    }
    #endregion

    #region Singleton functions
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    #region Unity Functions
    private void Start()
    {
        copyArray();
        //Shuffle Items in Question
        for (int i = 0; i < questions.Length;i++)
        {
            if(questions[i].scrambleItems)
            {
                questions[i].shuffleItems();
            }
            else
            {
                questions[i].copyArray();
            }
        }

        //Shuffle Questions
        if(scrambleQuestions)
        {
            shuffleQuestions();
        }

        currentQuestion = 0;

    }
    #endregion

    #region Event Functions
    public void SendQuestionDetails(Component sender, object data)
    {
        onSendQuestionDetails.Raise(this, scrambledQuestionsArray[currentQuestion]);
    }
    #endregion

}
