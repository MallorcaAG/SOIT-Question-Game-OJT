using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameEvent onDialogueDone;
    [SerializeField] private GameEvent onDoneTalking;
    [SerializeField] private TextMeshProUGUI ui;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    [SerializeField] private float textDelayBeforeNextLine = 3f;



    private int index;
    private int num = 0;
    private bool isTyping;
    private bool endReached = false;
    private float remainingTime;

    private void Start()
    {
        remainingTime = textDelayBeforeNextLine;
    }

    public void Initialize()
    {
        gameObject.SetActive(true);
        ui.text = string.Empty;
        StartDialogue();
    }

    public void setDialogue(Component sender, object data)
    {
        lines = (string[])data;
        Initialize();
    }

    private void Update()
    {
        if(!isTyping)
        {
            remainingTime -= Time.deltaTime;
        }

        if((remainingTime <= 0))
        {
            if(ui.text == lines[index])
            {
                NextLine();
                remainingTime = textDelayBeforeNextLine;
                //Debug.Log("next line");
            }
            else
            {
                StopAllCoroutines();
                ui.text = lines[index];

            }

            if(index >= lines.Length - 1 && endReached == false)
            {
                //Debug.Log("I ran");
                num++;
                onDialogueDone.Raise(this, num);
                endReached = true;
            }
            
        }
    }

    void StartDialogue()
    {
        index = 0;

        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        endReached = false;
        if (lines[index] == null) yield break;
        foreach (char c in lines[index].ToCharArray())
        {
            isTyping = true;
            ui.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            ui.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            onDoneTalking.Raise(this, 0);
        }
    }
    

}
