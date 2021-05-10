using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    private Queue<GameObject> objectPool = new Queue<GameObject>();

    private GameObject[] shadow;

    public GameObject shadowPrefab;

    public int poolCount = 10;

    private void Awake()
    {
        instance = this;
    }

    public void Init()
    {
        for (int i = 0; i < poolCount; i++)
        {
            shadow[i] = Instantiate(shadowPrefab);

            shadow[i].GetComponent<Transform>().SetParent(this.GetComponent<Transform>());

            BackToPool(shadow[i]);
        }
    }

    void Start()
    {
        shadow = new GameObject[poolCount];

        Init();
    }
    //�Բ�Ӱ�����ʹ��
    public GameObject ExitPool()
    {
        //���粻���Ļ���������
        if(objectPool.Count == 0)
        {
            Init();
        }
        GameObject output = objectPool.Dequeue();

        output.SetActive(true);

        return output;
    }

    //����ʹ�ù��Ĳ�Ӱ����
    public void BackToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        objectPool.Enqueue(gameObject);
    }
}
