using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Video;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class CourseVideoCutsceneController : MonoBehaviour
{
    [SerializeField] private VideoClip CS;
    [SerializeField] private VideoClip IT;
    [SerializeField] private VideoClip IS;
    [SerializeField] private VideoClip EMC;
    [SerializeField] private VideoClip DS;

    private VideoPlayer myVideoPlayer;

    private void Awake()
    {
        myVideoPlayer = GetComponent<VideoPlayer>();
    }

    public void PlayVideo(Component sender, object data)
    {
        string course = (string)data;

        if(course == "CS")
        {
            myVideoPlayer.clip = CS;
        }
        else if (course == "IT")
        {
            myVideoPlayer.clip = IT;
        }
        else if (course == "IS")
        {
            myVideoPlayer.clip = IS;
        }
        else if (course == "EMC")
        {
            myVideoPlayer.clip = EMC;
        }
        else if (course == "DS")
        {
            myVideoPlayer.clip = DS;
        }

        myVideoPlayer.Play();
    }
}
