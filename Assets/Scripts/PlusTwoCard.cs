using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Cards/PlusTwoCard", menuName = "PlusTwoCard")]
public class PlusTwoCard : ColoredCard {
    public override void OnPlay() {

        Pile.PullCard(2, 1);
        GameManager.EndTurn();

    }

    public override bool CanBePlayed()
    {
        return base.CanBePlayed();
    }
}
