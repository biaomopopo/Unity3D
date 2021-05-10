using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class UIManager : MonoBehaviour
{
    //��̬�ֶ���
    static int score_number = 0;

    //�Ǿ�̬�ֶ���
    Text score_text;

    //���ݽṹ��
    List<PortalGateway> portalGateways = new List<PortalGateway>();

    private UIManager()
    {

    }

    private static UIManager instance = new UIManager();
    //����ģʽ
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
        Debug.Log("��Ʒ�����֣�" + gameObject.tag);

        Destroy(gameObject);
    }
   
    public void RegistPortalGateway(PortalGateway portalGateway)
    {
        if (!instance.portalGateways.Contains(portalGateway))
            instance.portalGateways.Add(portalGateway);
    }

    //2��ÿ�������ŵĴ����Start���ֵ��ã�������ע�ᣨҲ���Ǽ����List����

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
