using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private CharacterData data;
    private bool triggerd;
    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<CharacterData>();
        triggerd = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector") && !triggerd)
        {
            triggerd = true;
            data.AddScore();
            Destroy(gameObject);
        }
    }
}
