using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public float moveSpeed = 2f;  // �������ƶ����ٶ�
    public float moveDistance = 5f;  // �������ƶ��ľ���
    public float delayTime = 2f;  // ÿ�ε��ﶥ���ײ�ͣ����ʱ��

    private bool movingUp = true;  // �Ƿ������ƶ�
    private Vector3 initialPosition;  // ��ʼλ��
    private float initialDelayTime;  // ��ʼ�ӳ�ʱ��

    private void Start()
    {
        initialPosition = transform.position;
        initialDelayTime = delayTime;
    }

    private void Update()
    {
        // �����ƶ�������ٶȸ��������ݵ�λ��
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
        // �ж��Ƿ񵽴ﶥ���ײ����������ı��ƶ�������ʱͣ��
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

    // ��ʱͣ����Э��
    private System.Collections.IEnumerator DelayRoutine()
    {
        // ͣ��һ��ʱ�������ƶ�
        yield return new WaitForSeconds(delayTime);

        // �����ӳ�ʱ��ͳ�ʼλ��
        delayTime = initialDelayTime;
        transform.position = initialPosition;
    }
}
