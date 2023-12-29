using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public float moveSpeed = 2f;  // 升降梯移动的速度
    public float moveDistance = 5f;  // 升降梯移动的距离
    public float delayTime = 2f;  // 每次到达顶点或底部停留的时间

    private bool movingUp = true;  // 是否向上移动
    private Vector3 initialPosition;  // 初始位置
    private float initialDelayTime;  // 初始延迟时间

    private void Start()
    {
        initialPosition = transform.position;
        initialDelayTime = delayTime;
    }

    private void Update()
    {
        // 根据移动方向和速度更新升降梯的位置
        if (movingUp)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        // 判断是否到达顶点或底部，如果是则改变移动方向并延时停留
        if (movingUp && transform.position.y >= initialPosition.y + moveDistance)
        {
            movingUp = false;
            StartCoroutine(DelayRoutine());
        }
        else if (!movingUp && transform.position.y <= initialPosition.y)
        {
            movingUp = true;
            StartCoroutine(DelayRoutine());
        }
    }

    // 延时停留的协程
    private System.Collections.IEnumerator DelayRoutine()
    {
        // 停留一段时间后继续移动
        yield return new WaitForSeconds(delayTime);

        // 重置延迟时间和初始位置
        delayTime = initialDelayTime;
        transform.position = initialPosition;
    }
}
