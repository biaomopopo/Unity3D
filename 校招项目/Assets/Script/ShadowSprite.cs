using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    private Transform player; //��ȡ��ҵ�λ����Ϣ

    private SpriteRenderer playerSprite, thisSprite; //��ҵ���չʾ��ͼƬ����Ԥ�����Ӱ�������ĵ�ͼƬ

    [Header("���ʱ���������")]

    public float activeTime; //��Ӱ����ʱ��

    public float activeStart; //��Ӱ��ʼ��ʱ��

    [Header("��͸���ȿ���")]
    float alpha; //��Ӱ��͸����

    private Color color; //��Ӱ����ɫ

    public float alphaSet;//��͸��������

    public float alphaMultiplier;//��͸���ȳ˻�

    // Start is called before the first frame update
    private void OnEnable()
    {
        //��ȡ��ҵ�������Ϣ
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //��ȡ��ҵľ������
        playerSprite = player.GetComponent<SpriteRenderer>();

        //��ȡ����ľ������
        thisSprite = GetComponent<SpriteRenderer>();

        alpha = alphaSet;

        thisSprite.sprite = playerSprite.sprite;

        this.transform.position = player.position;

        this.transform.localScale = player.localScale;

        this.transform.rotation = player.rotation;

        activeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        alpha *= alphaMultiplier;

        color = new Color(1, 1, 1, alpha);

        thisSprite.color = color;

        if(Time.time > activeStart + activeTime)
        {
            ObjectPoolManager.instance.BackToPool(this.gameObject);
        }
    }
}
