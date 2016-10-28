using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public Sprite cardBack;
    public CardController controller;

    public void Awake() {
        IsDraggable = false;

        if(gameObject.tag != "CurrentCard") {
            IsDraggable = true;
        }
    }

    public bool IsDraggable {
        get; set;
    }

    public bool IsBeingDragged {
        get; set;
    }

    public Sprite CardFace {
        get {
            return GetComponent<Image>().sprite;
        }
        set {
            Image image = GetComponent<Image>();
            image.sprite = value;
        }
    }

    public bool CanBePlayed () {
        return controller.CanBePlayed();
    }

    public void ReturnCard() {
        transform.SetParent(previousParent);
    }

    public virtual void OnPlay() {
        controller.OnPlay();
    }

    public void OnDrag(PointerEventData eventData) {
        if(IsDraggable) {
            this.transform.position = eventData.position;
        }
    }

    Transform previousParent;

    public void OnBeginDrag(PointerEventData eventData) {
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        if(IsDraggable) {
            IsBeingDragged = true;
            previousParent = transform.parent;
            transform.SetParent(transform.parent.parent);
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if(IsDraggable) {
            RaycastResult rr = eventData.pointerCurrentRaycast;
            if(rr.gameObject.tag == "CurrentCard") {
                CurrentCard.setCurrentCard(gameObject);
                rr.gameObject.GetComponent<CurrentCard>().onChangeCard();
                Debug.Log(CurrentCard.currentCard());
            } else
            ReturnCard();
        }
    }
}
