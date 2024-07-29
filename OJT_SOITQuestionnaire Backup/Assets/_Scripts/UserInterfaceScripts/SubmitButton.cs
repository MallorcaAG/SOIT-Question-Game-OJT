using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitButton : MonoBehaviour
{
    [SerializeField] private GameEvent onTriggerNextQuestion;

    //ADD FUNCTIONALITY THAT CHECKS FOR ATLEAST 1 CHOSEN ANSWER

    public void triggerNextQuestion()
    {
        onTriggerNextQuestion.Raise(this, 0);
    }
}
