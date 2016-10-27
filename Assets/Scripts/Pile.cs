using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Pile : MonoBehaviour {
    public List<CardController> pile = new List<CardController>();
    public Random random;

    public void Awake() {
    }

    public void TaskOnClick() {
        int cardIndex = 0;
        pile[cardIndex].CreateGameobject(transform);
        pile.RemoveAt(cardIndex);
    }

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
