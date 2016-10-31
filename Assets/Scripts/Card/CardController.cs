using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class CardController : ScriptableObject {
    public CardModel model;

    public abstract bool CanBePlayed();

    public CardView CreateGameobject() {
        CardView i = Instantiate(Resources.Load<CardView>("Card"));

        i.gameObject.GetComponent<Image>().sprite = model.cardFace;

        i.transform.SetParent(GameManager.CurrentPlayer.HandGameObject.transform);
        i.controller = this;
        return i;
    }

    public virtual void OnPlay() {

    }
}
