using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_InventoryDescription : MonoBehaviour
{
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private TMP_Text itemTitleTxt;
    [SerializeField]
    private TMP_Text itemDescriptionTxt;

    public void Awake()
    {
        ResetDescription();
    }

    public void ResetDescription()
    {
        this.itemImage.gameObject.SetActive(false);
        this.itemTitleTxt.text = "";
        this.itemDescriptionTxt.text = "";
    }

    public void SetDescription(Sprite sprite, string title, string description)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        this.itemTitleTxt.text = title;
        this.itemDescriptionTxt.text = description;
    }

}
