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

    //private int count = 0;

    public Text getQuantityText()
    {
        return quantityText;
    }

    public void setText(int num)
    {
        quantityText.text = num + "";
        //setCount(num);
    }

    public void setSprite(Sprite newImage)
    {
        image.GetComponent<SpriteRenderer>().sprite = newImage;
    }

    /*
    public int getCount()
    {
        return count;
    }

    public void setCount(int num)
    {
        count = num;
    }
    */
}
