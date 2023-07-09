
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private CharacterData data;
    private CharacterController2D control;
    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<CharacterData>();
        control = FindObjectOfType<CharacterController2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            control.TriggerInterationFunc += Interaction;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            control.TriggerInterationFunc -= Interaction;
        }
    }

    public void Interaction()
    {
        control.TriggerInterationFunc -= Interaction;
        control.PlayResumeInputAnimator("GetLightSpot");
        data.AddScore();
        Destroy(gameObject);
    }
}
