using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu(fileName = "Cards/NewNumberedCard", menuName = "NumberedCard")]
public class NumberedCard : ColoredCard {
    public override bool CanBePlayed() {
        return (base.CanBePlayed());
    }
}
