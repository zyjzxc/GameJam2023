using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{
    private CharacterData data;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<CharacterData>();
        healthSlider.value = 1;
    }


    // Update is called once per frame
    void Update()
    {
        healthSlider.value = data.GetCurrentHealthRate();
    }
}
