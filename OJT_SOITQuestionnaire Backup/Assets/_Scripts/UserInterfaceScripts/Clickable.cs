using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clickable : MonoBehaviour
{
    public float alphaThreshold = 0.1f;
    public Image[] images;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].alphaHitTestMinimumThreshold = alphaThreshold;
        }
    }

}
