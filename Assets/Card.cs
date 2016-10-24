using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public bool IsDraggable {
        get; set;
    }

    public bool IsBeingDragged {
        get; set;
    }

    public Image GetImage {
        get; set;
    }

    public virtual bool CanBePlayed () {
        return true;
    }

    public void ReturnCard() {

    }

    public virtual void CreateGameobject() {

    }

    public virtual void OnPlay() {

    }

    public void OnDrag(PointerEventData eventData) {

    }

    public void OnBeginDrag(PointerEventData eventData) {
    }

    public void OnEndDrag(PointerEventData eventData) {
    }
}
