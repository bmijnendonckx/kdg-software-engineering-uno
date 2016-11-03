using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Cards/NewChangeDirectionCard", menuName = "ChangeDirectionCard")]
public class ChangeDirectionCard : ColoredCard {
    public override void OnPlay()
    {
        if (GameManager.PlayerIndex < 2)
        {
            Model.value = "block";
        }
        else
        {
            GameManager.ToggleNextPlayer(false);
        }
    }
}
