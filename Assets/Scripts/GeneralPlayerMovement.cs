﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPlayerMovement : MonoBehaviour {

    public float speed = 10.0f;
    private Rigidbody2D rb;
    public bool right = true;

    // A variable for each character to enable and disable each power
    private ElfMovement c0Script;
    private KnightMovement c1Script;
    private MagicMovement c2Script;

    // A variable to change the color of the Player wen he changes the character
    private MeshRenderer render;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

        // The scripts of the other characters
        c0Script = GetComponent<ElfMovement>();
        c1Script = GetComponent<KnightMovement>();
        c2Script = GetComponent<MagicMovement>();

        // The component to switch the color for each character
        render = GetComponent<MeshRenderer>();
    }

    // Update for physics engine
    void FixedUpdate()
    {
        GeneralMovement();
        ChangeCharacter();
        SelectCharacter();
    }

    // General movement of the player
    void GeneralMovement()
    {
        float h = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * speed * h);
        if (h > 0)
            right = true;
        else
            right = false;
    }

    void ChangeCharacter()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.instance.CharacterManager();
        }
    }

    // Enable and disable the scripts of each character to select the powers
    void SelectCharacter()
    {
        switch (GameManager.instance.getCurrentCharacter())
        {
            case 0:
                render.material.color = Color.green;
                c2Script.enabled = false;
                c0Script.enabled = true;
                break;
            case 1:
                render.material.color = Color.blue;
                c0Script.enabled = false;
                c1Script.enabled = true;
                break;
            case 2:
                render.material.color = Color.red;
                c1Script.enabled = false;
                c2Script.enabled = true;
                break;
        }
    }
}
