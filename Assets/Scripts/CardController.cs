using UnityEngine;
using System.Collections;

public abstract class CardController : ScriptableObject {
    public CardModel model;

    public abstract bool CanBePlayed();

    public CardView CreateGameobject(Transform parent) {
        CardView i = GameObject.Instantiate(Resources.Load<CardView>("Card"));
        i.transform.SetParent(parent);
        i.controller = this;
        return i;
    }

    public virtual void OnPlay() {

    }
}
