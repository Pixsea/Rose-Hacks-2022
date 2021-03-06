using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craftables : MonoBehaviour
{

    public GameObject player;
    private PlayerInventory inventory;

    private AudioSource audio;
    [SerializeField]
    private AudioClip damageSound;
    [SerializeField]
    private AudioClip collectSound;

    public void Start()
    {
        player = gameObject;
        inventory = player.GetComponent<PlayerInventory>();
        audio = GameObject.Find("AudioSource").GetComponent<AudioSource>();

    }


    void Increasehappiness(float value)
    {
        player.GetComponent<PlayerStats>().ChangeHappiness(value);
        audio.PlayOneShot(collectSound, .2f);

    }


    public void craftSoup()
    {
        // check to see if player has enough ingredients to craft item
        if (inventory.hasEnough("Bowl", 1) && inventory.hasEnough("Berry",2))
        {
            // remove items required to craft
            player.GetComponent<PlayerInventory>().removeItem("Bowl",1);
            player.GetComponent<PlayerInventory>().removeItem("Berry", 2);

            // gain happiness
            Increasehappiness(.15f);
        }
        else
        {
            audio.PlayOneShot(damageSound, .2f);
        }
    }

    public void craftBananaBread()
    {
        // check to see if player has enough ingredients to craft item
        if (inventory.hasEnough("Banana",3) && inventory.hasEnough("Rice", 2))
        {
            // remove items required to craft
            player.GetComponent<PlayerInventory>().removeItem("Banana", 3);
            player.GetComponent<PlayerInventory>().removeItem("Rice", 2);

            // gain happiness
            Increasehappiness(.15f);
        }
        else
        {
            audio.PlayOneShot(damageSound, .2f);
        }
    }

    public void craftSpicySoup()
    {
        // check to see if player has enough ingredients to craft item
        if (inventory.hasEnough("Bowl",1) && inventory.hasEnough("Berry",2) && inventory.hasEnough("Pepper", 2) && inventory.hasEnough("Mushroom",2))
        {
            // remove items required to craft
            player.GetComponent<PlayerInventory>().removeItem("Bowl", 1);
            player.GetComponent<PlayerInventory>().removeItem("Berry", 2);
            player.GetComponent<PlayerInventory>().removeItem("Pepper", 2);
            player.GetComponent<PlayerInventory>().removeItem("Mushroom", 2);

            // gain happiness
            Increasehappiness(.15f);
        }
        else
        {
            audio.PlayOneShot(damageSound, .2f);
        }
    }

    public void craftRiceBread()
    {
        // check to see if player has enough ingredients to craft item
        if (inventory.hasEnough("Rice",3))
        {
            // remove items required to craft
            player.GetComponent<PlayerInventory>().removeItem("Rice", 3);

            // gain happiness
            Increasehappiness(.15f);
        }
        else
        {
            audio.PlayOneShot(damageSound, .2f);
        }
    }


    public void craftOmelet()
    {
        // check to see if player has enough ingredients to craft item
        if (inventory.hasEnough("Egg",3) && inventory.hasEnough("Pepper",1) && inventory.hasEnough("Milk", 1))
        {
            // remove items required to craft
            player.GetComponent<PlayerInventory>().removeItem("Egg", 3);
            player.GetComponent<PlayerInventory>().removeItem("Pepper", 1);
            player.GetComponent<PlayerInventory>().removeItem("Milk", 1);

            // gain happiness
            Increasehappiness(.15f);
        }
        else
        {
            audio.PlayOneShot(damageSound, .2f);
        }
    }

    public void craftBurger()
    {
        // check to see if player has enough ingredients to craft item
        if (inventory.hasEnough("Beef",1) && inventory.hasEnough("Mushroom",2) && inventory.hasEnough("Rice",2))
        {
            // remove items required to craft
            player.GetComponent<PlayerInventory>().removeItem("Beef", 1);
            player.GetComponent<PlayerInventory>().removeItem("Mushroom", 2);
            player.GetComponent<PlayerInventory>().removeItem("Rice", 2);

            // gain happiness
            Increasehappiness(.2f);
        }
        else
        {
            audio.PlayOneShot(damageSound, .2f);
        }
    }

    public void craftMeatPizza()
    {
        // check to see if player has enough ingredients to craft item
        if (inventory.hasEnough("Beef",2) && inventory.hasEnough("Rice", 2) && inventory.hasEnough("Mushroom", 2) && inventory.hasEnough("Pepper",2))
        {
            // remove items required to craft
            player.GetComponent<PlayerInventory>().removeItem("Beef", 2);
            player.GetComponent<PlayerInventory>().removeItem("Rice", 2);
            player.GetComponent<PlayerInventory>().removeItem("Mushroom", 2);
            player.GetComponent<PlayerInventory>().removeItem("Pepper", 2);

            // gain happiness
            Increasehappiness(.2f);
        }
        else
        {
            audio.PlayOneShot(damageSound, .2f);
        }
    }

    public void craftPepperJelly()
    {
        // check to see if player has enough ingredients to craft item
        if (inventory.hasEnough("Honey",2) && inventory.hasEnough("Berry",2) && inventory.hasEnough("Pepper",2))
        {
            // remove items required to craft
            player.GetComponent<PlayerInventory>().removeItem("Honey", 2);
            player.GetComponent<PlayerInventory>().removeItem("Berry", 2);
            player.GetComponent<PlayerInventory>().removeItem("Pepper", 2);


            // gain happiness
            Increasehappiness(.2f);
        }
        else
        {
            audio.PlayOneShot(damageSound, .2f);
        }
    }

    public void craftFrutiCake()
    {
        // check to see if player has enough ingredients to craft item
        if (inventory.hasEnough("Rice",2) && inventory.hasEnough("Egg",2) && inventory.hasEnough("Milk",2) && inventory.hasEnough("Honey",2) && inventory.hasEnough("Berry",2) && inventory.hasEnough("Banana",2))
        {
            // remove items required to craft
            player.GetComponent<PlayerInventory>().removeItem("Rice", 2);
            player.GetComponent<PlayerInventory>().removeItem("Egg", 2);
            player.GetComponent<PlayerInventory>().removeItem("Milk", 2);
            player.GetComponent<PlayerInventory>().removeItem("Honey", 2);
            player.GetComponent<PlayerInventory>().removeItem("Berry", 2);
            player.GetComponent<PlayerInventory>().removeItem("Banana", 2);

            // gain happiness
            Increasehappiness(.5f);
        }
        else
        {
            audio.PlayOneShot(damageSound, .2f);
        }
    }
}
