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
    private SpriteRenderer child;

    private Color endColor = Color.white;
    private float startTime;
    private bool fading = false;
    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<CharacterData>();
        control = FindObjectOfType<CharacterController2D>();
        respawn = FindObjectOfType<HazardRespawn>();
        gameManager = FindObjectOfType<GameManager>();
        child = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hero Detector"))
        {
            control.TriggerInterationFunc += Interaction;
        }
    }

    private void Update()
    {
        if (fading)
        { 
            float timePassed = Time.time - startTime;
            float t = Mathf.Clamp01(timePassed / 4);
            child.color = Color.Lerp(child.color, endColor, t);
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
        startTime = Time.time;
        fading = true;
        //respawn.Respawn();
        //Destroy(gameObject);
    }
}
