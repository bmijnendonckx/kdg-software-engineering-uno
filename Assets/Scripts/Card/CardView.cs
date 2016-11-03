using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public Sprite cardBack;
    public CardController controller;
    Transform previousParent;
    GameObject placeholder;
    int siblingIndex;

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
        transform.SetSiblingIndex(siblingIndex);
    }

    public virtual void OnPlay() {
        controller.OnPlay();
    }

    public void OnDrag(PointerEventData eventData) {
        if(IsDraggable) {
            this.transform.position = eventData.position;

            RaycastResult rr = eventData.pointerCurrentRaycast;
            //error when dragging outside of the screen, if statement
            if(rr.isValid && rr.gameObject.tag == "Card") {
                siblingIndex = rr.gameObject.transform.GetSiblingIndex();
                placeholder.transform.SetSiblingIndex(siblingIndex);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        if(IsDraggable) {
            IsBeingDragged = true;
            previousParent = transform.parent;
            siblingIndex = transform.GetSiblingIndex();

            placeholder = (GameObject)Instantiate(Resources.Load("Placeholder"));

            placeholder.transform.SetParent(previousParent);
            placeholder.transform.SetSiblingIndex(siblingIndex);
            transform.SetParent(transform.parent.parent);
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if(IsDraggable) {
            Destroy(placeholder);
            RaycastResult rr = eventData.pointerCurrentRaycast;
            if(rr.isValid && rr.gameObject.tag == "CurrentCard" && controller.CanBePlayed()) {
                CurrentCard.setCurrentCard(gameObject);
                GameManager.CheckVictoryCondition();
            } else
            ReturnCard();
        }
    }
}
