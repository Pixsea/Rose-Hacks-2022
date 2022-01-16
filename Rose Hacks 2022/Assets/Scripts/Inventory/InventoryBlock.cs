using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryBlock : MonoBehaviour
{
    [SerializeField]
    private Text quantityText;

    [SerializeField]
    private GameObject image;

    public Text getQuantityText()
    {
        return quantityText;
    }

    public void setText(int num)
    {
        quantityText.text = num + "";
    }

    public void setSprite(Sprite newImage)
    {
        image.GetComponent<SpriteRenderer>().sprite = newImage;
    }
}
