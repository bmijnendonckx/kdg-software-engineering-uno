using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player {
    public List<CardView> hand = new List<CardView>();

    public bool isFirstTurn {
        get; set;
    }
}
