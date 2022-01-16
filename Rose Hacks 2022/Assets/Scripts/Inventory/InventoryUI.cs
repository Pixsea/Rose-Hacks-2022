using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // Clear list after adding object or removing object
    // Do this by making function calls in PlayerInventory Script

    public GameObject inventoryBlockPrefab;
    private GameObject startingObject;

    //private List<int> itemCounts = new List<int>();

    private List<string> itemNames = new List<string>();
    public List<GameObject> inventoryBlocks = new List<GameObject>();

    [SerializeField]
    private float margin = 1f;

    // Start is called before the first frame update
    void Start()
    {
        startingObject = GameObject.Find("StartingBlock");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            GameObject newBlock = Instantiate(inventoryBlock, new Vector3(startingObject.transform.position.x + (margin*inventoryBlocks.Count) , startingObject.transform.position.y, startingObject.transform.position.z), Quaternion.identity);
            newBlock.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            newBlock.transform.position = new Vector3(startingObject.transform.position.x+(margin*inventoryBlocks.Count), startingObject.transform.position.y, startingObject.transform.position.z);
            inventoryBlocks.Add(newBlock);
            timeRemaining = 2f;
        }
        */
        
    }

    public void addItemToInventory(string name, int count, Sprite image)
    {
        GameObject newBlock = Instantiate(inventoryBlockPrefab, new Vector3(startingObject.transform.position.x + (margin * inventoryBlocks.Count), startingObject.transform.position.y, startingObject.transform.position.z), Quaternion.identity);
        newBlock.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        newBlock.transform.position = new Vector3(startingObject.transform.position.x + (margin * inventoryBlocks.Count), startingObject.transform.position.y, startingObject.transform.position.z);
        inventoryBlocks.Add(newBlock);
        itemNames.Add(name);
        newBlock.GetComponent<InventoryBlock>().setText(count);
        newBlock.GetComponent<InventoryBlock>().setSprite(image);
    }

    public void updateValue(string name, int count)
    {
        for (int i = 0; i < itemNames.Count; i++)
        {
            if (itemNames[i] == name)
            {
                inventoryBlocks[i].GetComponent<InventoryBlock>().setText(count);

            }
        }
    }
}
