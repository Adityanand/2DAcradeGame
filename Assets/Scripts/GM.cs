using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public static GM instance;
    public CoinManager coinManager;
    public GameObject Player;
    private int i = -1;
    public int CurrentScore;
    public int Coin;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);
    }// Start is called before the first frame update
    void Start()
    {
        coinManager = CoinManager.instance;
        Coin = 0;
        CurrentScore = 0;
    }
    public void Update()
    {
        if (coinManager == null)
            coinManager = CoinManager.instance;
        if (CoinManager.instance == null)
            Debug.LogWarning("Coin Managaer not Exist in scene");
        if(Player==null)
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public void LateUpdate()
    {
        if (Player.activeSelf == false)
        {
            Coin=coinManager.CoinCollected;
            CurrentScore=coinManager.Iscore;
        }
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Score" + i++,CurrentScore);
        PlayerPrefs.Save();
    }
}
