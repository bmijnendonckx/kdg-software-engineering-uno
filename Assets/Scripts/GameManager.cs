using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    static Player[] players = new Player[2];
    static int playerIndex = 0;
    Pile pile;

    public static int PlayerIndex {
        get {return playerIndex;}
        set {playerIndex = (value + players.Length) % players.Length;
        }
    }

    public static Player CurrentPlayer {
        get {
            return players[PlayerIndex];
        }
    }

    public void Awake() {
        pile = GameObject.FindGameObjectWithTag("Pile").GetComponent<Pile>();
        
        for(int i = 0; i < players.Length; i++) {
            players[i] = new Player();
        }
        //Start game
        StartGame();
    }

    public void StartGame() {
        //First player
        PlayerIndex = 0;

        //Set first turn for all players true
        foreach(Player p in players) {
            p.isFirstTurn = true;
        }

        BeginTurn();
    }

    public void BeginTurn() {
        //Set current player in textbar
        GameObject.FindGameObjectWithTag("PlayerTextBar").GetComponentInChildren<Text>().text = "PLAYER " + (PlayerIndex + 1);
        //if this is the first turn for you as a player take 7 cards
        if(CurrentPlayer.isFirstTurn) {
            Pile.PullCard(7);
            CurrentPlayer.isFirstTurn = false;
        } else {       
            for (int i = 0; i < CurrentPlayer.hand.Count; i++)
            {
                //Debug.Log(players[playerIndex].hand[i].controller.model.color);
                CurrentPlayer.hand[i].controller.CreateGameobject();
            }
        }
    }

    public void EndTurn() {
        GameObject[] cardsOnField = GameObject.FindGameObjectsWithTag("Card");
        for (int i = 0; i < cardsOnField.Length; i++)
        {
            Destroy(cardsOnField[i]);
        }
        ToggleNextPlayer();
    }
    public void ToggleNextPlayer()
    {
        PlayerIndex++;
        BeginTurn();
    }
}