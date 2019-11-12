using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropp " + gameObject.name);

        CardDraggable d = eventData.pointerDrag.GetComponent<CardDraggable>();
        if(d!=null)
        {
            d.parentToReturnTo = this.transform;
        }
    }
}
