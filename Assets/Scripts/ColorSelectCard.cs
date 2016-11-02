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

        ColorChangeMenu.transform.Find("red").GetComponent<Button>().onClick.AddListener(ChangeToRed); //Can't give a parameter in an addlisterer. Need to find a better solution
        ColorChangeMenu.transform.Find("blue").GetComponent<Button>().onClick.AddListener(ChangeToBlue);
        ColorChangeMenu.transform.Find("green").GetComponent<Button>().onClick.AddListener(ChangeToGreen);
        ColorChangeMenu.transform.Find("Yellow").GetComponent<Button>().onClick.AddListener(ChangeToYellow);
    }

    public static void ChangeToRed()
    {
        CurrentCard.Color = "red";
        Debug.Log(CurrentCard.Color);
        GameManager.EndTurn();
        Destroy(GameObject.FindGameObjectWithTag("ColorSelect"));
 
    }
    public static void ChangeToBlue()
    {
        CurrentCard.Color = "blue";
        Debug.Log(CurrentCard.Color);
        GameManager.EndTurn();
        Destroy(GameObject.FindGameObjectWithTag("ColorSelect"));
    }
    public static void ChangeToGreen()
    {
        CurrentCard.Color = "green";
        Debug.Log(CurrentCard.Color);
        GameManager.EndTurn();
        Destroy(GameObject.FindGameObjectWithTag("ColorSelect"));
    }
    public static void ChangeToYellow()
    {
        CurrentCard.Color = "yellow";
        Debug.Log(CurrentCard.Color);
        GameManager.EndTurn();
        Destroy(GameObject.FindGameObjectWithTag("ColorSelect"));
    }

}