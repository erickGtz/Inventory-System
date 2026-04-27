using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Camera mainCam;
    [SerializeField]
    private UI_InventoryItem item;

    public void Awake()
    {
        canvas = transform.root.GetComponent<Canvas>();
        mainCam = Camera.main;
        item = GetComponentInChildren<UI_InventoryItem>();
    }

    public void SetData(Sprite image, int quantity)
    {
        item.SetData(image, quantity);
    }

    public void Toggle(bool value)
    {
        Debug.Log($"Item toggled {value}");
        gameObject.SetActive(value);
    }

    void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            Input.mousePosition,
            canvas.worldCamera,
        out position);
        transform.position = canvas.transform.TransformPoint(position);
    }
}
