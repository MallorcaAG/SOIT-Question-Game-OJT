using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPaperTransitionEnd : MonoBehaviour
{
    [SerializeField] private GameEvent onQuizEnd;

    public void TransitionDone()
    {
        onQuizEnd.Raise(this, 0);
    }
}
