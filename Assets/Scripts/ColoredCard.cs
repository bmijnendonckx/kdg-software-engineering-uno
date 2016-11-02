using UnityEngine;
using System.Collections;
using System;

public class ColoredCard : CardController {
    public string color
    {
        get; set;
    }
    string value
    {
        get; set;
    }

    public override bool CanBePlayed() {
        return (Model.color == CurrentCard.Color || Model.value == CurrentCard.Value);
    }
}
