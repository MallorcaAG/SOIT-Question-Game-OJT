using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameEvent onVideoEnd;
    [SerializeField] private VideoPlayer cutscene;

    // Start is called before the first frame update
    void Start()
    {
        cutscene.loopPointReached += VidEnd;
    }

    void VidEnd(VideoPlayer vid)
    {
        onVideoEnd.Raise(this, 0);
    }
}
