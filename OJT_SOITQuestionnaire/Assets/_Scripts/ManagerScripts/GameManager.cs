using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build.Player;
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
    [Header("X = Category, Y = Score" + "\n" +
             "\tX: 0 = na \n" + "" +
             "\t    1 = CS \n" +
             "\t    2 = IT \n" +
             "\t    3 = IS \n" +
             "\t    4 = EMC \n" +
             "\t    5 = DS \n" +
             "\t    9 = SOIT")]
    [Tooltip("X = Category, Y = Score" + "\n" +
             "\tX: 0 = na \n" + "" +
             "\t    1 = CS \n" +
             "\t    2 = IT \n" +
             "\t    3 = IS \n" +
             "\t    4 = EMC \n" +
             "\t    5 = DS \n" +
             "\t    9 = SOIT")]
    [SerializeField] private Vector2[] scoresRanking;

    #region Encapsulation methods
    public Vector2[] Scores
    {
        get { return scoresRanking; } 
    }
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
    public void subtractCS(int num)
    {
        scoreCS -= num;
    }
    public void subtractIT(int num)
    {
        scoreIT -= num;
    }
    public void subtractIS(int num)
    {
        scoreIS -= num;
    }
    public void subtractEMC(int num)
    {
        scoreEMC -= num;
    }
    public void subtractDS(int num)
    {
        scoreDS -= num;
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
    
    public void receiveAddData(Component sender, object data)
    {
        Choice c = (Choice)data;
        addCS(c.itemScoreCS);
        addIT(c.itemScoreIT);
        addIS(c.itemScoreIS);
        addEMC(c.itemScoreEMC);
        addDS(c.itemScoreDS);
    }
    public void receiveSubtractData(Component sender, object data)
    {
        Choice c = (Choice)data;
        subtractCS(c.itemScoreCS);
        subtractIT(c.itemScoreIT);
        subtractIS(c.itemScoreIS);
        subtractEMC(c.itemScoreEMC);
        subtractDS(c.itemScoreDS);
    }

    #endregion

    #region Final Score Functions
    
    public void sortScore()
    {
        Vector2[] list = new Vector2[5];
        list[0].x = (int)Category.CS; list[0].y = scoreCS;
        list[1].x = (int)Category.IT; list[1].y = scoreIT;
        list[2].x = (int)Category.IS; list[2].y = ScoreIS;
        list[3].x = (int)Category.EMC; list[3].y = ScoreEMC;
        list[4].x = (int)Category.DS; list[4].y = ScoreDS;

        Vector2[] sortedList = list.OrderByDescending(v => v.y).ToArray<Vector2>();
        scoresRanking = sortedList;

        
        
    }
    


    #endregion




}

