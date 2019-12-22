using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition;
    private Vector3 originalMousePosition;

    public Transform parentToReturnTo = null;

    public GameObject targetMarkerPrefab;

    public GameObject marker;
    public Character target = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!gameObject.GetComponent<CardDisplay>().isHighlighting)
            return;

        marker = Instantiate(targetMarkerPrefab, transform);

        originalPosition = this.transform.position;
        originalMousePosition = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {

        Vector3 newPosition = Input.mousePosition - originalMousePosition;
        marker.transform.position = originalPosition + newPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (SetTarget())
        {
            gameObject.transform.GetComponent<CardDisplay>().UseCard(target);
        }
        GameObject.Destroy(marker);
    }

    public bool SetTarget()
    {
        Debug.Log("RAY!");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider != null &&
                hit.collider.gameObject.GetComponent<Character>() != null)
            {
                target = hit.collider.gameObject.GetComponent<Character>();
                Debug.Log("Hit! " + hit.transform.name);

                return true;
            }
        }
        return false;
    }
}
