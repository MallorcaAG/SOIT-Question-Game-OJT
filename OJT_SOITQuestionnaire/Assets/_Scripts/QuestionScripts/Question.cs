using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestionSelectionType
{
    radio, checkbox
}

[CreateAssetMenu(menuName = "Question/Question")]
public class Question : ScriptableObject
{
    [Space]
    [TextArea] 
    public string questionText;
    public QuestionSelectionType questionType;
    public Choice[] items;
}


