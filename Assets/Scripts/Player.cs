using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player {
    public GameObject handGo;
    public List<CardView> hand = new List<CardView>();

    public Player() {
        handGo = GameObject.Instantiate(Resources.Load<GameObject>("Hand"));
        handGo.transform.SetParent(Pile.instance.transform);
        handGo.transform.localPosition = Vector3.zero;
    }

    public bool isFirstTurn {
        get; set;
    }
}
