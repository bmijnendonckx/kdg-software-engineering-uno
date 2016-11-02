using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Cards/PlusTwoCard", menuName = "PlusTwoCard")]
public class PlusTwoCard : ColoredCard {
    public override void OnPlay() {

        base.OnPlay();
        Pile.ForcePullCard(2);
    }

    public override bool CanBePlayed()
    {
        return base.CanBePlayed();
    }
}
