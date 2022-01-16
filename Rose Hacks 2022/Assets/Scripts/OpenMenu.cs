﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    [HideInInspector]
    public GameObject player;


    private void Start()
    {
        menu.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            menu.SetActive(true);
            player.gameObject.GetComponent<PlayerShooting>().inMenu = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            LeaveMenu();
        }
        if (Input.GetKeyDown("a"))
        {
            LeaveMenu();
        }
        if (Input.GetKeyDown("s"))
        {
            LeaveMenu();
        }
        if (Input.GetKeyDown("d"))
        {
            LeaveMenu();
        }
    }

    void LeaveMenu()
    {
        menu.SetActive(false);
        player.gameObject.GetComponent<PlayerShooting>().inMenu = false;
    }
}
