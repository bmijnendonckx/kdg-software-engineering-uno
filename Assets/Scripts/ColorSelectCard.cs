using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Cards/NewColorSelectCard", menuName = "ColorSelectCard")]
public class ColorSelectCard :CardController {
    public override bool CanBePlayed() {
        return true;
    }

    public override void OnPlay()
    {

        Instantiate(Resources.Load("ColorSelectMenu"));

    }

}