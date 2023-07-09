using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using TMPro;

public class TextTrigger : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string textInfo;
    public int clearTime = 5;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            text.text = textInfo;
        }
    }

    private void OnDestroy()
    {
        text.text = "";     
    }

}
