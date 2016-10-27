using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public Sprite cardBack;
    private Image image;
    public CardController controller;

    public void Awake() {

    }

    public bool IsDraggable {
        get; set;
    }

    public bool IsBeingDragged {
        get; set;
    }

    public Sprite GetImage {
        get {
            return image.sprite;
        }
        set {
            image.sprite = value;
        }
    }

    public bool CanBePlayed () {
        return controller.CanBePlayed();
    }

    public void ReturnCard() {
        
    }

    public virtual void OnPlay() {
        controller.OnPlay();
    }

    public void OnDrag(PointerEventData eventData) {

    }

    public void OnBeginDrag(PointerEventData eventData) {
    }

    public void OnEndDrag(PointerEventData eventData) {
    }
}
