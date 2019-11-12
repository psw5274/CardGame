using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private Vector3 originalPosition;
    private Vector3 originalMousePosition;

    public Transform parentToReturnTo = null;


    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        // 드래그 위치 보정
        originalPosition = this.transform.position;
        originalMousePosition = Input.mousePosition;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 드래그 위치 보정
        Vector3 newPosition = Input.mousePosition - originalMousePosition;
        this.transform.position = originalPosition + newPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
