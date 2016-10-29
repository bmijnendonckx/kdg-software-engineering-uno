using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentCard:MonoBehaviour {
    public static CardModel m = new CardModel();

    public void onChangeCard() {
        GetComponent<Image>().sprite = CardFace;
    }

    public static Sprite CardFace {
        set {
            m.cardFace = value;
        }
        get {
            return m.cardFace;
        }
    }

    public static string Color {
        set {
            m.color = value;
        }
        get {
            return m.color;
        }
    }

    public static string Value {
        set {
            m.value = value;
        }
        get {
            return m.value;
        }
    }

    public static void setCurrentCard(GameObject go) {
        CardView view = go.GetComponent<CardView>();
        CardController controller = view.controller;
        CardModel model = controller.model;

        Color = model.color;
        Value = model.value;
        CardFace = model.cardFace;

        GameManager.CurrentPlayer.hand.Remove(view);
        Pile.stock.Add(controller);
        Destroy(go);
    }

    public static string currentCard() {
        return "Color: " + m.color + ", value: " + m.value;
    }
}
