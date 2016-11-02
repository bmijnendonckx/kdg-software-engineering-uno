using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    static Player[] players = new Player[2];
    static int playerIndex = 0;
    static GameObject continueUI;
    static GameManager instance;

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

    public void Start() {
        instance = this;     
        for(int i = 0; i < players.Length; i++) {
            players[i] = new Player();
        }

        GameObject.FindGameObjectWithTag("CardHolder").GetComponent<Button>().onClick.AddListener(onPileClick);

        //Start game
        StartGame();
    }

    public void onPileClick() {
        Pile.PullCard();
    }

    public static void StartGame() {
        //First player
        PlayerIndex = 0;

        //Set first turn for all players true
        foreach(Player p in players) {
            p.isFirstTurn = true;
        }

        BeginTurn();
    }

    public static void BeginTurn() {
        //Set current hand as scrollable
        Pile.instance.GetComponent<ScrollRect>().content = CurrentPlayer.HandGameObject.GetComponent<RectTransform>();
        //Set current player in textbar
        GameObject.FindGameObjectWithTag("PlayerTextBar").GetComponentInChildren<Text>().text = "PLAYER " + (PlayerIndex + 1) + "'S TURN";
        //if this is the first turn for you as a player take 7 cards
        if(CurrentPlayer.isFirstTurn) {
            Pile.PullCard(7);
            CurrentPlayer.isFirstTurn = false;
        }

        CurrentPlayer.HandGameObject.SetActive(true);
    }

    public static void createContinueUI() {
        continueUI = Resources.Load<GameObject>("Press Continue");
        continueUI = Instantiate<GameObject>(continueUI);
        continueUI.transform.SetParent(Pile.instance.transform);
        continueUI.transform.SetAsLastSibling();
        continueUI.transform.localPosition = new Vector3(0, 300, 0);
        continueUI.GetComponentInChildren<Text>().text = "END OF PLAYER " + (PlayerIndex+1) + "'S TURN";
        continueUI.GetComponentInChildren<Button>().onClick.AddListener(OnContinueUIClick);
    }

    public static void EndTurn() {
        CurrentPlayer.HandGameObject.SetActive(false);
        createContinueUI();
    }

    public static void OnContinueUIClick() {
        Destroy(continueUI);
        ToggleNextPlayer(true);
    }

    public static void ToggleNextPlayer(bool nextPlayer) {
        if (nextPlayer == true)
        { PlayerIndex++;
        }
        if (nextPlayer == false)
        {
            PlayerIndex--;
        }
        BeginTurn();
    }
}