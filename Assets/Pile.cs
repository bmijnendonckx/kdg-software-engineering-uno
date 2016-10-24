using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pile : MonoBehaviour {

    public List<Card> pile = new List<Card>();
    public GameObject CurrentCard
    {
        get; set;
    }
    public string Color
    {
        get; set;
    }
    public string Value
    {
        get; set;
    }
    public void stripComponent()
    {

    }
}
