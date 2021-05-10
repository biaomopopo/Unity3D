using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    private Transform player; //获取玩家的位置信息

    private SpriteRenderer playerSprite, thisSprite; //玩家的所展示的图片，与预制体残影所产生的的图片

    [Header("冲刺时间参数控制")]

    public float activeTime; //残影存活的时间

    public float activeStart; //残影开始的时间

    [Header("不透明度控制")]
    float alpha; //残影的透明度

    private Color color; //残影的颜色

    public float alphaSet;//不透明度设置

    public float alphaMultiplier;//不透明度乘积

    // Start is called before the first frame update
    private void OnEnable()
    {
        //获取玩家的坐标信息
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //获取玩家的精灵组件
        playerSprite = player.GetComponent<SpriteRenderer>();

        //或取自身的精灵组件
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
