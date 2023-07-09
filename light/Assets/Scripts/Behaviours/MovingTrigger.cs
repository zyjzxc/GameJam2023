using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    bool inTrigger;
    // Start is called before the first frame update
    Moving moving;
    void Start()
    {
        inTrigger = false;
        moving = GetComponent<Moving>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            inTrigger = false;
        }
    }
}
