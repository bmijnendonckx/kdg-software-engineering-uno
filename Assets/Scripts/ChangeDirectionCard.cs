using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Cards/NewChangeDirectionCard", menuName = "ChangeDirectionCard")]
public class ChangeDirectionCard : ColoredCard {
    public override void OnPlay()
    {
        if(GameManager.PlayerIndex < 2) {
            GameManager.ToggleNextPlayer(true);
            GameManager.EndTurn();
        } else {
            GameManager.ToggleNextPlayer(false);
        }
    }
}
