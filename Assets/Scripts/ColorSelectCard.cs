using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Cards/NewColorSelectCard", menuName = "ColorSelectCard")]
public class ColorSelectCard : CardController {
    GameObject ColorChangeMenu;

    public override bool CanBePlayed() {
        return true;
    }

    public override void OnPlay() {
        ColorChangeMenu = Resources.Load<GameObject>("ColorSelectMenu");
        ColorChangeMenu = Instantiate<GameObject>(ColorChangeMenu);
        ColorChangeMenu.transform.SetParent(GameObject.FindGameObjectWithTag("screen").transform);
        ColorChangeMenu.transform.SetAsLastSibling();
        ColorChangeMenu.transform.localPosition = new Vector3(0, 300, 0);

        ColorChangeMenu.transform.Find("red").GetComponent<Button>().onClick.AddListener(delegate { ChangeColor("red"); });
        ColorChangeMenu.transform.Find("blue").GetComponent<Button>().onClick.AddListener(delegate { ChangeColor("blue"); });
        ColorChangeMenu.transform.Find("green").GetComponent<Button>().onClick.AddListener(delegate { ChangeColor("green"); });
        ColorChangeMenu.transform.Find("Yellow").GetComponent<Button>().onClick.AddListener(delegate { ChangeColor("yellow"); });
    }

    public void ChangeColor(string NewColor) {
        CurrentCard.Color = NewColor;
        GameManager.EndTurn();
        Destroy(ColorChangeMenu);
    }
}