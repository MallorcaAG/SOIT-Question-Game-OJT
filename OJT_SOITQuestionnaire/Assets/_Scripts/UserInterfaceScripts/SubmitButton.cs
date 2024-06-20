using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitButton : MonoBehaviour
{
    [SerializeField] private GameEvent onTriggerNextQuestion;

    public void triggerNextQuestion()
    {
        onTriggerNextQuestion.Raise(this, 0);
    }
}
