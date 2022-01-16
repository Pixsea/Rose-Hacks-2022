using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int quantity = 0;
    [SerializeField]
    private string description;


    private int limit = 1000;

    /*
    public Item(string name, int quantity, int limit)
    {
        this.name = name;
        this.quantity = quantity;
        this.limit = limit;
    }
    */

    // Getters
    public string getName()
    {
        return name;
    }

    
    public int getQuantity()
    {
        return quantity;
    }

    public string getDescription()
    {
        return description;
    }


    // Functionality
    public void addItems(int num)
    {
        // add limit later if necessary
        if((quantity + num) >= limit)
        {
            quantity = limit;
        }
        else
        {
            quantity = quantity + num;
        }
    }

    public void removeItems(int num)
    {
        if(quantity >= num)
        {
            quantity = quantity - num;
        }
        else
        {
            quantity = 0;
        }
    }

}
