
using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private CharacterData data;
    private CharacterController2D control;
    // Start is called before the first frame update
    private GameManager gameManager;
    void Start()
    {
        data = FindObjectOfType<CharacterData>();
        control = FindObjectOfType<CharacterController2D>();
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
        control.PlayResumeInputAnimator("GetLightSpot");
        StartCoroutine(Resume());
        data.AddScore();
        Destroy(gameObject);
    }

    IEnumerator Resume()
    {
        yield return new WaitForSeconds(3f);
        gameManager.SetEnableInput(true);
    }
}
