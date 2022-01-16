using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    // new organizzzzzzational structure
    // Item has mono
    // Dictionary<string name, [quantity and description]>
    // when item is gathered, copies data into inventory dictionary

    
    private Dictionary<string, string> inventoryDescr = new Dictionary<string, string>();
    private Dictionary<string, int> inventoryQuantity = new Dictionary<string, int>();
    private Dictionary<string, Sprite> images = new Dictionary<string, Sprite>();


    // Start is called before the first frame update
    void Start()
    {
        // add starting items if any
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inventoryQuantity);
    }

    public void addItem(Item item)
    {
        if(inventoryDescr.ContainsKey(item.getName()))
        {
            inventoryQuantity[item.getName()] += item.getQuantity();
        }
        else
        {
            inventoryDescr[item.getName()] = item.getDescription();
            inventoryQuantity[item.getName()] = item.getQuantity();
            images[item.getName()] = item.gameObject.GetComponent<SpriteRenderer>().sprite;
            this.gameObject.GetComponent<InventoryUI>().addItemToInventory(item.getName(), item.getQuantity(), images[item.getName()]);
        }

    }

    public void removeItem(string name, int num)
    {
        if(inventoryDescr.ContainsKey(name))
        {
            if(num >= inventoryQuantity[name])
            {
                inventoryDescr.Remove(name);
                inventoryQuantity.Remove(name);
            }
            else
            {
                inventoryQuantity[name] = inventoryQuantity[name] - num;
            }
        }
    }



    // Add function to check if player has enough ingredients to craft something
    public bool hasEnough(List<string> ingredientNames, List<int> ingredientQuant)
    {
        // if lists are of different size: scuffed solution
        if (ingredientNames.Count != ingredientQuant.Count)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < ingredientNames.Count; i++)
            {
                if (inventoryDescr.ContainsKey(ingredientNames[i]))
                {
                    // if too many ingredients are required
                    if (ingredientQuant[i] > inventoryQuantity[ingredientNames[i]])
                    {
                        return false;
                    }
                }
                // if ingredient is not in inventory return false
                else
                {
                    return false;
                }
            }
            return true;
        }
    }

    public Dictionary<string, int> getInventoryQuantity()
    {
        return inventoryQuantity;
    }


    public Dictionary<string, string> getDescriptions()
    {
        return inventoryDescr;
    }



}
