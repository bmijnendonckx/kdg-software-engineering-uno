using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class CardController : ScriptableObject {
    [SerializeField]
    private CardModel model;

    public CardModel Model {
        get {
            return model;
        }
    }

    //returns true or false whether card can be played or not
    public abstract bool CanBePlayed();
    //onPlay of the wild & special cards Do something
    public virtual void OnPlay() {
        GameManager.EndTurn();
    }

    public CardView CreateGameobject() {
        CardView i = Instantiate(Resources.Load<CardView>("Card"));

        i.gameObject.GetComponent<Image>().sprite = Model.cardFace;

        i.transform.SetParent(GameManager.CurrentPlayer.HandGameObject.transform);
        i.controller = this;
        return i;
    }
    public CardView DrawOpponentCard()
    {
        CardView i = Instantiate(Resources.Load<CardView>("Card"));

        i.gameObject.GetComponent<Image>().sprite = Model.cardFace;

        i.transform.SetParent(GameManager.NextPlayer.HandGameObject.transform);
        i.controller = this;
        return i;
    }
}
