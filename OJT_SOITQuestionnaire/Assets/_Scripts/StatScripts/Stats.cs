using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Stats 
{
    public static int STAT_MIN = 1;
    public static int STAT_MAX = 10;

    private SingleStat CS;
    private SingleStat IT;
    private SingleStat IS;
    private SingleStat EMC;
    private SingleStat DS;



    public Stats(int CSscore, int ITscore, int ISscore, int EMCscore, int DSscore)
    {
        CS = new SingleStat(CSscore);
        IT = new SingleStat(ITscore);
        IS = new SingleStat(ISscore);
        EMC= new SingleStat(EMCscore);
        DS = new SingleStat(DSscore);

    }

    public int Stat(Category type)
    {
        return getSingleStat(type).Stat;
    }
    public float StatNormalized(Category type)
    {
        return getSingleStat(type).StatNormalized; 
    }
    public void setStat(Category type, int statAmount)
    {
        getSingleStat(type).setStat(statAmount);
    }
    public void increaseStat(Category type)
    {
        getSingleStat(type).increaseStat();
    }
    public void decreaseStat(Category type)
    {
        getSingleStat(type).decreaseStat();
    }

    private SingleStat getSingleStat(Category type) 
    {
        switch (type)
        {
            case Category.CS:
                return CS;
            case Category.IT:
                return IT;
            case Category.IS:
                return IS;
            case Category.EMC:
                return EMC;
            case Category.DS:
                return DS;
            default:
                return null;
        }
    }
   


    private class SingleStat
    {
        private int stat;

        public SingleStat(int statAmount)
        {
            setStat(statAmount);
        }

        public int Stat
        {
            get { return stat; }
        }
        public float StatNormalized
        {
            get { return (float)stat / (float)STAT_MAX; }
        }
        public void setStat(int statAmount)
        {
            stat = Mathf.Clamp(statAmount, STAT_MIN, STAT_MAX);
        }
        public void increaseStat()
        {
            setStat(stat + 1);
        }
        public void decreaseStat()
        {
            setStat(stat - 1);
        }
    }

}
