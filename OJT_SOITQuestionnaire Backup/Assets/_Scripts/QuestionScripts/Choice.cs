using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question/Item")]
public class Choice : ScriptableObject
{
    [TextArea]
    public string itemText;
    public int itemScoreCS = 0, itemScoreIT = 0, itemScoreIS = 0, itemScoreEMC = 0, itemScoreDS = 0;
}
