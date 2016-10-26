using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    Player[] TotalNumberOfPlayers = new Player[2];

    Player Currentplayer {
        get; set;
    }
}
