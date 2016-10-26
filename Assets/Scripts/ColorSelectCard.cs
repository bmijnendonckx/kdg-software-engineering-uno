using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Cards/NewColorSelectCard", menuName = "ColorSelectCard")]
public class ColorSelectCard :CardController {
    public override bool CanBePlayed() {
        return true;
    }

    public override void OnPlay()
    {
        base.OnPlay();
    }

}