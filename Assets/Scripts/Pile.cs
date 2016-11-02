using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Pile : MonoBehaviour {
    public List<CardController> pile = new List<CardController>();
    public static List<CardController> stock = new List<CardController>();
    public static Pile instance;
    private System.Random r;

    public void Awake() {
        instance = this;
        r = new System.Random();
        Shuffle();
    }

    public static void RestockPile() {
        foreach(CardController controller in stock) {
            instance.pile.Add(controller);
        }
        stock.Clear();
    }

    public void Shuffle() {
        CardController temp;
        int randomNum;

        for(int i = 0; i < pile.Count; i++) { 
            temp = pile[i]; //switch Card A with B, First Card A in Temp, (A,B, Temp = A)
            randomNum = r.Next(0, pile.Count);
            pile[i] = pile[randomNum]; //Put Card B where Card A is (B, B, Temp = A)
            pile[randomNum] = temp; //Put Card A from Temp where Card B was (B, A) what previously was (A, B)
        }
    }

    public static void PullCard() {
        //Card 0 is the top card of the pile
        GameManager.CurrentPlayer.hand.Add(instance.pile[0].CreateGameobject());
        instance.pile.RemoveAt(0); //remove from pile add to hand from the currently playing player
    }

    //Pull Cards equal to passed amount
    public static void PullCard(int cards) {
        for(int i = 0; i < cards; i++) {
            PullCard();
        }
    }

    public static void ForcePullCard(int cards) {
        for (int i = 0; i < cards; i++) {
            GameManager.NextPlayer.hand.Add(instance.pile[0].DrawOpponentCard());
            instance.pile.RemoveAt(0);
        }
    }
}