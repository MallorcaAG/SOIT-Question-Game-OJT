using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScipt : MonoBehaviour
{

    public Question q;

    // Start is called before the first frame update
    void Start()
    {
        scramble();
    }

    void scramble()
    {
        if (q.scrambleItems == true)
        {
            q.shuffleItems();
        }

    }
}
