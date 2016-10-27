using UnityEngine;
using System.Collections;

public abstract class CardController : ScriptableObject {
    public CardModel model;

    public abstract bool CanBePlayed();

    public void CreateGameobject(Transform parent) {
        CardView i = GameObject.Instantiate(Resources.Load<CardView>("Card"));
        i.transform.SetParent(parent);
        i.controller = this;
    }

    public virtual void OnPlay() {

    }
}
