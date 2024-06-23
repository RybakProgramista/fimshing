using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel
{
    private readonly string name;
    public string Name { get { return name; } }

    private readonly float maxStrenght;
    public float MaxStrenght { get { return maxStrenght; } }
    private float currStrenght;
    public float CurrStrenght { get { return  currStrenght; } }
    public void changeCurrStrenght(float newVal) { currStrenght = newVal; }

    public Reel(string name, float maxStrenght)
    {
        this.name = name;
        this.maxStrenght = maxStrenght;
        this.currStrenght = maxStrenght;
    }
}
