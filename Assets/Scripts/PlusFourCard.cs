using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Cards/PlusFourCard", menuName = "PlusFourCard")]
public class PlusFourCard : ColorSelectCard {
    public override bool CanBePlayed() {
        bool IsPlayable = true;
        for (int i = 0; i < GameManager.CurrentPlayer.hand.Count; i++)
        {
            
            if (GameManager.CurrentPlayer.hand[i].controller.Model.color == CurrentCard.Color)
            {
                IsPlayable = false;
            }
           
        }
        return IsPlayable;
    }

    public override void OnPlay() {
        base.OnPlay();
        Pile.ForcePullCard(4);
    }

}
