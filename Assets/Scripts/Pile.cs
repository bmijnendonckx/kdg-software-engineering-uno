using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Pile : MonoBehaviour {
    public List<CardController> pile = new List<CardController>();

    public void Awake() {
        // shuffle here
    }

    public void TaskOnClick() {
        int cardIndex = 0; // <= random here (temp)
        pile[cardIndex].CreateGameobject(transform); //create card as gameobject from pile
        pile.RemoveAt(cardIndex); //remove card from pile
        //playerHand.add => card gameobject
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
