using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    static Player[] players = new Player[2];
    static int playerIndex = 0;
    GameObject continueUI;

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
        GameObject.FindGameObjectWithTag("PlayerTextBar").GetComponentInChildren<Text>().text = "PLAYER " + (PlayerIndex + 1) + "'S TURN";
        //if this is the first turn for you as a player take 7 cards
        if(CurrentPlayer.isFirstTurn) {
            Pile.PullCard(7);
            CurrentPlayer.isFirstTurn = false;
        }
    }

    public void createContinueUI() {
        continueUI = new GameObject("Press Continue");
        continueUI.transform.SetParent(transform);
        continueUI.transform.SetAsLastSibling();

        Image image = continueUI.AddComponent<Image>();
        image.color = new Color(0, 0, 0);

        RectTransform rt = image.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(Screen.width / 2, Screen.height / 4);
        rt.localPosition = Vector3.zero;

        GameObject t = new GameObject("Text");
        t.transform.SetParent(continueUI.transform);

        Text text = t.AddComponent<Text>();
        text.font = Resources.Load<Font>("Fonts/Montserrat-Regular");
        text.fontSize = 50;
        text.alignment = TextAnchor.MiddleCenter;
        text.text = "PLAYER " + (PlayerIndex+1);

        RectTransform rt2 = t.GetComponent<RectTransform>();
        rt2.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y/2);
        t.transform.localPosition = new Vector3(0, rt2.sizeDelta.y / 2, 0);
    }

    public void EndTurn() {
        createContinueUI();

        ToggleNextPlayer();
    }
    public void ToggleNextPlayer()
    {
        PlayerIndex++;
        BeginTurn();
    }
}