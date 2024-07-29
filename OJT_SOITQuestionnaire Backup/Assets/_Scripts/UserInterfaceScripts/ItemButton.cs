using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private Choice myData;
    [Header("Events")]
    [SerializeField] private GameEvent onItemSelected;
    [SerializeField] private GameEvent onItemDeselected;
    [SerializeField] private GameEvent onTriggerNextQuestion;   

    public void setData(Choice data)
    {
        myData = data;
    }

    public void itemSelected()
    {
        onItemSelected.Raise(this, myData);
    }
    public void itemToggled(Boolean active)
    {
        //Debug.Log(active);
        if(active)
        {
            onItemSelected.Raise(this, myData);
        }
        else
        {
            onItemDeselected.Raise(this, myData);
        }
    }
    public void triggerNextQuestion()
    {
        onTriggerNextQuestion.Raise(this, 0);
    }


}
