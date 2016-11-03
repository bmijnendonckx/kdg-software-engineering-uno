using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Cards/PlusFourCard", menuName = "PlusFourCard")]
public class PlusFourCard : ColorSelectCard {
    public override bool CanBePlayed() {
        return true;
    }

    public override void OnPlay() {
        
            base.OnPlay();
            Pile.ForcePullCard(4);
        

    }

}
