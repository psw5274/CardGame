using System;
using UnityEngine;

public class TargetingArrow : MonoBehaviour
{
    public GameObject effectTarget;
    public GameObject targetType;

    public Action onTargetSelected;

    public GameObject selectedCard { get; protected set; }
    public GameObject selectedPlayer { get; protected set; }

    public Material material;

    public Texture2D headTexture;

    public Texture2D targetTexture;

    protected LineRenderer lineRenderer;
    protected GameObject head;
    protected GameObject target;
    protected Vector2 uvAnimationRate = new Vector2(-1.5f, 0.0f);
    protected Vector2 uvOffset = Vector2.zero;

    protected bool startedDrag;
    protected Vector3 initialPos;

    protected GameObject boardCreature;

    protected virtual void Update()
    {
        if (startedDrag)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdateLength(mousePos);
        }
    }

    protected virtual void LateUpdate()
    {
        if (startedDrag)
        {
            uvOffset += (uvAnimationRate * Time.deltaTime);
            lineRenderer.material.SetTextureOffset("_MainTex", uvOffset);
        }
    }

    public void Begin(Vector2 pos)
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.41f;
        lineRenderer.endWidth = 0.41f;
        lineRenderer.material = material;
        lineRenderer.sortingLayerName = "HandCards";

        startedDrag = true;
        initialPos = pos;

        lineRenderer.SetPosition(0, initialPos);
        var rect = new Rect(0, 0, headTexture.width, headTexture.height);
        var arrowHead = Sprite.Create(headTexture, rect, new Vector2(0.5f, 0.5f));
        head = new GameObject();
        head.transform.parent = gameObject.transform;
        var sprite = head.AddComponent<SpriteRenderer>();
        sprite.sprite = arrowHead;
        sprite.sortingLayerName = "HandCards";
        head.transform.position = lineRenderer.GetPosition(0);
        var collider = head.AddComponent<BoxCollider2D>();
        collider.transform.position = lineRenderer.GetPosition(0);
        collider.size.Set(sprite.size.x, sprite.size.y);
        var rb = head.AddComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    public void UpdateLength(Vector2 pos)
    {
        var arrowStart = Camera.main.WorldToScreenPoint(lineRenderer.GetPosition(0));
        var arrowEnd = Camera.main.WorldToScreenPoint(lineRenderer.GetPosition(1));
        var arrowLen = Vector3.Distance(arrowStart, arrowEnd);
        lineRenderer.material.mainTextureScale = new Vector2(arrowLen / material.mainTexture.width, 1.0f);
        lineRenderer.SetPosition(1, pos);
        head.transform.position = lineRenderer.GetPosition(1);
        var angle = Mathf.Atan2(arrowEnd.y - arrowStart.y, arrowEnd.x - arrowStart.x) * 180 / Mathf.PI;
        head.transform.localRotation = Quaternion.Euler(0, 0, angle + 180);
    }

    public virtual void OnCardSelected(GameObject creature)
    {
    }

    public virtual void OnCardUnselected(GameObject creature)
    {
    }

    public virtual void OnPlayerSelected(GameObject player)
    {
    }

    public virtual void OnPlayerUnselected(GameObject player)
    {
    }

    protected void CreateTarget(Vector2 pos)
    {
        Destroy(target);
        var rect = new Rect(0, 0, targetTexture.width, targetTexture.height);
        var targetSprite = Sprite.Create(targetTexture, rect, new Vector2(0.5f, 0.5f));
        target = new GameObject();
        target.transform.parent = gameObject.transform;
        var sprite = target.AddComponent<SpriteRenderer>();
        sprite.sprite = targetSprite;
        sprite.sortingLayerName = "HandCards";
        target.transform.position = pos;
        target.transform.localScale = new Vector2(1.5f, 1.5f);
    }
}