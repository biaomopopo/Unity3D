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
    //对残影对象的使用
    public GameObject ExitPool()
    {
        //假如不够的话进行扩容
        if(objectPool.Count == 0)
        {
            Init();
        }
        GameObject output = objectPool.Dequeue();

        output.SetActive(true);

        return output;
    }

    //回收使用过的残影对象
    public void BackToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        objectPool.Enqueue(gameObject);
    }
}
