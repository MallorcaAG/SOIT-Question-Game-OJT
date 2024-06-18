using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Question/Multiple Choice Question")]
public class MultipleChoiceQuestion : Question
{
    [TextArea] public string itemAText;
    [TextArea] public string itemBText;
    [TextArea] public string itemCText;
    [TextArea] public string itemDText;
    [TextArea] public string itemEText;

    #region Inspector Texts
    [Header("X = Category, Y = Value, Z = Item" + "\n" +
             "\tX: 0 = na \n" + "" +
             "\t    1 = CS \n" +
             "\t    2 = IT \n" +
             "\t    3 = IS \n" +
             "\t    4 = EMC \n" +
             "\t    5 = DS \n" +
             "\t    9 = SOIT \n" +
             "Z: Put the Item Number. \nExamples, item A is 1, item B is 2, so on. . .")]
    [Tooltip("X = Category, Y = Value, Z = Item" + "\n" +
             "\tX: 0 = na \n" + "" +
             "\t    1 = CS \n" +
             "\t    2 = IT \n" +
             "\t    3 = IS \n" +
             "\t    4 = EMC \n" +
             "\t    5 = DS \n" +
             "\t    9 = SOIT \n" +
             "Z: Put the Item Number. \nExamples, item A is 1, item B is 2, so on. . .")]
    #endregion
    public Vector3[] Values;
}
