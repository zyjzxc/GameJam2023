using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    public float duration = 2.0f;       // 渐变时间
    public SpriteRenderer sprite;       // 定义要渐变的 sprite renderer

    //private Color startColor = Color.red;
    private Color endColor = Color.white;
    private float startTime;

    private void Start()
    {
        // 获取开始时间
        startTime = Time.time;
    }

    private void Update()
    {
        // 根据时间更新颜色
        float timePassed = Time.time - startTime;
        float t = Mathf.Clamp01(timePassed / duration);
        sprite.color = Color.Lerp(sprite.color, endColor, t);
    }
}
