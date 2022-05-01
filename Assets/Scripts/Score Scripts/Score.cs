using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score
{
    public string _name;
    public float score;

    public Score(string name, float score)
    {
        this._name = name;
        this.score = score;
    }
}
