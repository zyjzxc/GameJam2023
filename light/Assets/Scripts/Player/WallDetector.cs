﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    CharacterController2D character;

    private void Awake()
    {
        character = FindObjectOfType<CharacterController2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            character.SetIsSliding(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            character.SetIsSliding(false);
        }
    }
}