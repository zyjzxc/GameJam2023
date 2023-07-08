using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CrystalTrigger : MonoBehaviour
{
    private CharacterData data;
    bool inTrigger;
    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<CharacterData>();
        inTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            data.SetStopHealthSub(true);
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            data.SetStopHealthSub(false);
            inTrigger = false;
        }
    }

    private void OnDestroy()
    {
        if (inTrigger)
        {
            data.SetStopHealthSub(false);
        }
    }
}
