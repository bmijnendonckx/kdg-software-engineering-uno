using UnityEngine;
using System.Collections;

public class ColoredCard : CardController {
    public string color
    {
        get; set;
    }
    string value
    {
        get; set;
    }

    public override bool CanBePlayed()
    {
        return true;
        //    if (color == Pile.Color || value == Pile.Value) //this can be used can it? but color and Value need to be static in the Pile for it to work....
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
    }


}
