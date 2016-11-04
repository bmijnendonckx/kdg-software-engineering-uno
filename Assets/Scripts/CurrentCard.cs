using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentCard:MonoBehaviour {
    public static CardModel m = new CardModel();
    private static CurrentCard instance;
    public Color red, yellow, blue, green;
    private static int plusFourStreak;
    private static int plusTwoStreak;

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

    public static Sprite CardFace {
        set {
            m.cardFace = value;
            instance.onChangeCard();
        }
        get {
            return m.cardFace;
        }
    }
    public static string Color {
        set {
            m.color = value;
            instance.onChangeCard();
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

    public static bool IsFirstCard {
        get; set;
    }

    public void onChangeCard() {
        GetComponent<Image>().sprite = CardFace;
        GameObject.FindGameObjectWithTag("Background").GetComponent<Image>().color = getColor(Color);
    }

    public void Start() {
        IsFirstCard = true;
        instance = this;

        while(Pile.instance.pile[0].Model.color == "wild") {
            Pile.RestockPile();
            Pile.instance.Shuffle();
        }

        GameManager.PlayerIndex--;
        setCurrentCard(Pile.instance.pile[0], true);
        Pile.instance.pile.RemoveAt(0);
        IsFirstCard = false;
        GameManager.PlayerIndex++;
    }

    public static void setCurrentCard(CardController c, bool firstCard = false) {
        CardModel model = c.Model;

        Color = model.color;
        Value = model.value;
        CardFace = model.cardFace;

        Pile.stock.Add(c);

        if(!firstCard || c is ColoredCard)
            c.OnPlay();
    }

    public static void setCurrentCard(GameObject go) {
        CardView view = go.GetComponent<CardView>();
        setCurrentCard(view.controller);
        GameManager.CurrentPlayer.hand.Remove(view);
        
        Destroy(go);
    }

    public static string currentCard() {
        return "Color: " + m.color + ", value: " + m.value;
    }

}
