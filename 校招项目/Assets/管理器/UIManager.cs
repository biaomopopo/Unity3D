using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class UIManager : MonoBehaviour
{
    //静态字段区
    static int score_number = 0;

    //非静态字段区
    Text score_text;

    //数据结构区
    List<PortalGateway> portalGateways = new List<PortalGateway>();

    private UIManager()
    {

    }

    private static UIManager instance = new UIManager();
    //单例模式
    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void Integral_Edition(int number)
    {
        if(score_text == null)
        {
            score_text = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        }

        score_number += number;
        
        score_text.text = score_number.ToString();
    }

    public void DestoryGameObject(GameObject gameObject)
    {
        Debug.Log("物品的名字：" + gameObject.tag);

        Destroy(gameObject);
    }
   
    public void RegistPortalGateway(PortalGateway portalGateway)
    {
        if (!instance.portalGateways.Contains(portalGateway))
            instance.portalGateways.Add(portalGateway);
    }

    //2，每个传送门的代码的Start部分调用，将自身注册（也就是加入进List）。

    public PortalGateway FindSameGate(PortalGateway portalGateway)
    {

        foreach (PortalGateway portalGateway1 in instance.portalGateways)
        {
            if (portalGateway1 != portalGateway)
            {
                if (portalGateway1.kindofGate == portalGateway.kindofGate)
                    return portalGateway1;
            }
        }
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
