using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] public Vector3 endPosition = new Vector3(0, 10, 0);  // 终点
    [SerializeField] public float moveSpeed = 1.0f;  // 移动速度
    [SerializeField] public float pauseTime = 1.0f;  // 到达终点后的停留时间
    [SerializeField] public bool movingWith = false;

    private float timer = 0.0f;  // 计时器
    private bool movingToTarget = true;  // 是否在向终点移动
    private Vector3 originalPosition;
    private Rigidbody2D rigidbody2D;
    private Vector2 lastSpeed;

    private Vector3 direction;

    public Vector3 GetDir() { return direction; }


    private void Start()
    {
        // 开始时在起点
        originalPosition = transform.position;
        lastSpeed = Vector3.zero;
        rigidbody2D = null;
    }

    private void Update()
    {
        Vector3 targetPosition;

        if (movingToTarget)
        {
            // 向终点移动
            targetPosition = endPosition + originalPosition;
        }
        else
        {
            // 向起点移动
            targetPosition = originalPosition;
        }

        // 沿移动方向移动
        direction = (targetPosition - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // 如果到达终点或起点，则暂停一段时间
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            timer += Time.deltaTime;

            if (timer >= pauseTime)
            {
                // 反转方向并重置计时器
                movingToTarget = !movingToTarget;
                timer = 0.0f;
            }
        }
        if(movingWith && rigidbody2D != null)
        {
            rigidbody2D.velocity -= lastSpeed;
            rigidbody2D.velocity += moveSpeed * new Vector2(direction.x, direction.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (movingWith)
            rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(movingWith && rigidbody2D != null)
        {
            rigidbody2D.velocity -= lastSpeed;
            rigidbody2D = null;
        }
    }
}
