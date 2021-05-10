using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerScore :System.IComparable
{
    public string playerName;

    public int playerScore;

    PlayerScore()
    {

    }

    public PlayerScore(string name, int score)
    {
        this.playerName = name;

        this.playerScore = score;
    }
    public int CompareTo(object obj)
    {
        PlayerScore score = (PlayerScore)obj;

        if (score == null)
        {
            return 0;
        }

        int value = score.playerScore - this.playerScore;

        return value;
    }
}
