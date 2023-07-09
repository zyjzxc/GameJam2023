using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private CharacterData data;
    private CharacterController2D control;
    private HazardRespawn respawn;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<CharacterData>();
        control = FindObjectOfType<CharacterController2D>();
        respawn = FindObjectOfType<HazardRespawn>();
        gameManager = FindObjectOfType<GameManager>();
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
        control.PlayResumeInputAnimator("GameFinish");
        respawn.Respawn();
        Destroy(gameObject);
    }
}
