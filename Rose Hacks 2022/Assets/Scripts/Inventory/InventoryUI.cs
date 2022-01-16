using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // Clear list after adding object or removing object
    // Do this by making function calls in PlayerInventory Script

    public GameObject inventoryBlock;
    //public Sprite itemImage;

    public GameObject startingObject;

    //private List<string> items = new List<string>();
    //private List<int> itemCounts = new List<int>();

    public List<GameObject> inventoryBlocks = new List<GameObject>();

    public float timeRemaining = 5f;

    [SerializeField]
    private float margin = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        
    }

    public void addItemToInventory(string name, int count, Sprite image)
    {
        GameObject newBlock = Instantiate(inventoryBlock, new Vector3(startingObject.transform.position.x + (margin * inventoryBlocks.Count), startingObject.transform.position.y, startingObject.transform.position.z), Quaternion.identity);
        newBlock.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        newBlock.transform.position = new Vector3(startingObject.transform.position.x + (margin * inventoryBlocks.Count), startingObject.transform.position.y, startingObject.transform.position.z);
        inventoryBlocks.Add(newBlock);
        newBlock.GetComponent<InventoryBlock>().setText(count);
        newBlock.GetComponent<InventoryBlock>().setSprite(image);
    }
}
