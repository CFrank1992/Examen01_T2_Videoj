using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    private int Score = 0;

    private int totalBronzeCoins = 0;

    private int totalSilverCoins = 0;

    private int totalGoldCoins = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScore()
    {
        return this.Score;
    }

    public int GetBronzeCoinsScore()
    {
        return this.totalBronzeCoins;
    }

    public int GetSilverCoinsScore()
    {
        return this.totalSilverCoins;
    }

    public int GetGoldCoinsScore()
    {
        return this.totalGoldCoins;
    }

    public void PlusScore(int score)
    {
        this.Score += score;
    }

    public void bronzeCoinScore(int bronze)
    {
        this.totalBronzeCoins += bronze;
    }

    public void silverCoinScore(int silver)
    {
        this.totalSilverCoins += silver;
    }

    public void goldCoinScore(int gold)
    {
        this.totalGoldCoins += gold;
    }
}
