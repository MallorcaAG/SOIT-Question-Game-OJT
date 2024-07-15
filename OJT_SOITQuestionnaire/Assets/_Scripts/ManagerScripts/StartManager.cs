using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

enum gameversion
{
    MINI, FULL
}

public class StartManager : MonoBehaviour
{
    [SerializeField] private gameversion version;
    [SerializeField] private GameEvent onStartButtonPressed;

    public void startAnimationDone()
    {
        if (version == gameversion.MINI)
            onStartButtonPressed.Raise(this, 0);
        else
            onStartButtonPressed.Raise(this, 1);
    }
}
