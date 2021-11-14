using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MonologueBrick", order = 1)]
public class MonologueBrick : ScriptableObject
{
    public string Text;
    public MonologueBrick nextBrick;
}
