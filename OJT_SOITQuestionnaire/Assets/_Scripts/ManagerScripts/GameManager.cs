using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    [Header("User Stats")]
    [SerializeField] private int scoreCS = 0;
    [SerializeField] private int scoreIT = 0;
    [SerializeField] private int scoreIS = 0;
    [SerializeField] private int scoreEMC = 0;
    [SerializeField] private int scoreDS = 0;

    [Header("Event Reference")]
    [SerializeField] private GameEvent onQuizStart;

    #region Encapsulation methods
    public int ScoreCS
    {
        get { return scoreCS; }
    }
    public int ScoreIT
    {
        get { return scoreIT; }
    }
    public int ScoreIS
    {
        get { return scoreIS; }
    }
    public int ScoreEMC
    {
        get { return scoreEMC; }
    }
    public int ScoreDS
    {
        get { return scoreDS; }
    }
    public void addCS(int num)
    {
        scoreCS += num;
    }
    public void addIT(int num)
    {
        scoreIT += num;
    }
    public void addIS(int num)
    {
        scoreIS += num;
    }
    public void addEMC(int num)
    {
        scoreEMC += num;
    }
    public void addDS(int num)
    {
        scoreDS += num;
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

    #region Event methods
    public void StartQuiz()
    {
        onQuizStart.Raise(this, 0);
    }
    #endregion
}

