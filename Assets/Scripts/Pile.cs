using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pile : MonoBehaviour {
    public List<CardController> pile = new List<CardController>();

    public void Awake() {
        
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
