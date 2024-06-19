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
    public bool scrambleItems = false;

    public Choice[] scrambledArray;


    public void shuffleItems()
    {
        copyArray();
        Choice[] itemsCopy = scrambledArray;
        int l = items.Length;
        System.Random rand = new System.Random();

        for(int i = 0; i < l; i++)
        {
            swap(itemsCopy, i, i + rand.Next(l - i));
        }

        scrambledArray = itemsCopy;
    }

    public void copyArray()
    {
        scrambledArray = new Choice[items.Length];
        for (int i = 0; i < items.Length;i++)
        {
            scrambledArray[i] = items[i];
        }
    }

    private void swap(Choice[] arr, int first, int second)
    {
        Choice temp = arr[first];
        arr[first] = arr[second];
        arr[second] = temp;
    }

}


