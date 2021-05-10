using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform target;

    private Vector3 offset;

    private void Start()
    {
        if (target == null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;//�ҵ����
            offset = target.position - transform.position;//��ʼ��ƫ����
        }
    }
    private void FixedUpdate()
    {
        transform.position = target.position - offset;
    }
}
