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
        GameObject ColorChangeMenu;
        ColorChangeMenu = Resources.Load<GameObject>("ColorSelectMenu");
        ColorChangeMenu = Instantiate<GameObject>(ColorChangeMenu);
        ColorChangeMenu.transform.SetParent(GameObject.FindGameObjectWithTag("screen").transform);
        ColorChangeMenu.transform.SetAsLastSibling();
        ColorChangeMenu.transform.localPosition = new Vector3(0, 300, 0);


    }

}