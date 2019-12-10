using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropp " + gameObject.name);

        CardDraggable cardDraggable = eventData.pointerDrag.GetComponent<CardDraggable>();
        if(cardDraggable!=null)
        {
            cardDraggable.parentToReturnTo = this.transform;
        }


        // DropZone 올렸을 때 카드 사용, 일단 타겟 미지정
        // 플레이어 턴에만 사용 가능
        if (BattleManager.Instance.currentTurn == Team.Player)
        {
            cardDraggable.gameObject.GetComponent<CardDisplay>().UseCard();
        }
    }
}
