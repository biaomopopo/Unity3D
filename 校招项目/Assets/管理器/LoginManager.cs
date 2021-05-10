using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public GameObject Item;

    public GameObject packUI;

    public GameObject parent;

    private string path;

    public int length;

    private List<PlayerScore> scoreList = new List<PlayerScore>();
    private void Awake()
    {
        path = Application.dataPath + "/Resources/PlayerDataJson.txt";

        ReadJson();
    }

    public void newSerializable()
    {
        PlayerScore player = new PlayerScore("123", 80);

        FileInfo info = new FileInfo(path);

        StreamWriter streamWriter = info.CreateText();

        XmlSerializer xml = new XmlSerializer(typeof(PlayerScore));

        xml.Serialize(streamWriter, player);

        streamWriter.Close();

        FileStream fs = new FileStream(path, FileMode.Open);

        XmlSerializer xmlSer = new XmlSerializer(typeof(PlayerScore));

        PlayerScore readp1 = (PlayerScore)xmlSer.Deserialize(fs);

        Debug.Log(readp1.playerName + readp1.playerScore);
    }

    public void xmlScoreSerializer()
    {
        FileStream file = new FileStream(path, FileMode.Open);
       
    }

    //点击按钮展示
    public void scoreSort()
    {
        packUI.SetActive(true);

        if (scoreList == null)
        {
            ReadJson();
        }

        ScoreDataSort();

        WriteJson();

        initScoreScore();
    }

    //对数据进行排序
    public void ScoreDataSort()
    {
        scoreList.Sort();

        if(scoreList.Count > length)
        {
            for (int i = length -1; i < scoreList.Count; i++)
            {
                scoreList.RemoveAt(i);
            }
        }

    }

    //对数据进行写入
    public void WriteJson()
    {
        StreamWriter sw = new StreamWriter(path);

        for (int i = 0; i < scoreList.Count; i++)
        {
            sw.WriteLine(JsonUtility.ToJson(scoreList[i]));
        }

        sw.Close();
    }
    //读取Json数据
    public void ReadJson()
    {
        StreamReader sr = new StreamReader(path);

        string data;

        while ((data = sr.ReadLine()) != null)
        {
            scoreList.Add(JsonUtility.FromJson<PlayerScore>(data));
        }
        sr.Close();
    }

    //生成分数数据
    public void initScoreScore()
    {
        for (int i = 0; i < scoreList.Count; i++)
        {
            GameObject item = Instantiate(Item.gameObject);

            item.gameObject.SetActive(true);

            item.transform.SetParent(parent.transform);

            item.transform.Find("玩家排名").GetComponent<Text>().text = (i + 1).ToString();

            item.transform.Find("玩家名").GetComponent<Text>().text = scoreList[i].playerName;

            item.transform.Find("玩家分数").GetComponent<Text>().text = scoreList[i].playerScore.ToString();
        }
    }

    public void scoreSortClose()
    {
        packUI.SetActive(false);

        WriteJson();

        ScoreListClear();
    }

    public void ScoreListClear()
    {
        scoreList.Clear();
    }

    public void ScoreListAdd(PlayerScore score)
    {
        scoreList.Add(score);
    }
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
