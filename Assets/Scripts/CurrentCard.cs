using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentCard:MonoBehaviour {
    public static CardModel m = new CardModel();
    private static CurrentCard instance;
    public Color red, yellow, blue, green;

    public Color getColor (string c) {
        switch(c) {
            case "red":
                return red;
            case "yellow":
                return yellow;
            case "blue":
                return blue;
            case "green":
                return green;
            default:
                return new Color(0, 0, 0);
        }
    }

    public void onChangeCard() {
        GetComponent<Image>().sprite = CardFace;
        GameObject.FindGameObjectWithTag("Background").GetComponent<Image>().color = getColor(Color);
    }

    public void Start() {
        instance = this;

        while(Pile.instance.pile[0].model.color == "wild") {
            Pile.RestockPile();
            Pile.instance.Shuffle();
        }

        setCurrentCard(Pile.instance.pile[0].CreateGameobject().gameObject);
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
        instance.onChangeCard();
    }

    public static string currentCard() {
        return "Color: " + m.color + ", value: " + m.value;
    }
}
