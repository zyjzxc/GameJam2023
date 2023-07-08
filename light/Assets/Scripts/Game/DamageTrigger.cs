using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{

    HazardRespawn hazardRespawn;

    private void Awake()
    {
        hazardRespawn = FindObjectOfType<HazardRespawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            hazardRespawn.Respawn();
        }
    }
}
