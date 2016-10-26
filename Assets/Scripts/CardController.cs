using UnityEngine;
using System.Collections;

public abstract class CardController : ScriptableObject {
    public CardModel model;

    public abstract bool CanBePlayed();

    public void CreateGameobject() {
        CardView i = GameObject.Instantiate(Resources.Load<CardView>("Card"));
        i.controller = this;
    }

    public virtual void OnPlay() {

    }
}
