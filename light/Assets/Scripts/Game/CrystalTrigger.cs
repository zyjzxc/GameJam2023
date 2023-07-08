using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CrystalTrigger : MonoBehaviour
{
    private CharacterData data;
    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<CharacterData>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            data.SetStopHealthSub(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            data.SetStopHealthSub(false);
        }
    }
}
