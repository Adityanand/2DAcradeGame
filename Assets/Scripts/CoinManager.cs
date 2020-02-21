using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    private GameObject Player;
    private float Position;
    private float height=-0.25f;
    private float spawnz=25.0f;
    private int CoinInst;
    private PlayerController playerMovement;
    private int HighScore;
    AudioSource Audio;
    GM GameManager;

    public int Iscore;
    public int CoinCollected;
    public Text Coin;
    public Text Score;
    public Text HighScoreUI;
    public Text HighScoreValue;
    public Text CurrentScore;
    //public AudioClip Clip;
    public GameObject Firework;
    ObjectPool objectPooler;

    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start ()
    {
        objectPooler = ObjectPool.instance;
        Player = GameObject.FindGameObjectWithTag("Player");
        playerMovement=Player.GetComponent<PlayerController>();
        GameManager = GM.instance;
        StartCoroutine(CoinSpawn());
        Audio = this.GetComponent<AudioSource>();
        Coin.text = "0" + GameManager.Coin;
        Score.text = "00" + GameManager.CurrentScore;
        CoinCollected = GameManager.Coin;
        Iscore = GameManager.CurrentScore;
    }
    
	private IEnumerator CoinSpawn()
    {
        yield return new WaitForSeconds(1);
        Position = Random.Range(Player.transform.position.y + .5f, Player.transform.position.y + 2f);
        //Position = (int)Position;
        CoinInst = Random.Range(3, 5);
        if (playerMovement.Grounded)
        {
            for (int i = 0; i < CoinInst; i++)
            {
                objectPooler.SpawnFromPool("Coin", new Vector3(spawnz, Position, height), Quaternion.Euler(90, 0, 0));
                spawnz += 1f;
            }

        }
        spawnz = Player.transform.position.x + 40;
        yield return new WaitForSeconds(4);
        StartCoroutine(CoinSpawn());
    }
    public void CoinCollect()
    {
        CoinCollected += 1;
        //Audio.clip = Clip;
        //Audio.Play();
        Coin.text ="0"+CoinCollected;
    }
    // Update is called once per frame
    void Update ()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", HighScore);
        Iscore = CoinCollected * 10;
         HighScoreValue.text = "0" + HighScore;
         Score.text = "0" + Iscore;
        CurrentScore.text = Score.text;
        if (HighScore < Iscore)
        {
            HighScore = Iscore;
            HighScoreValue.text = "0" + HighScore;
            if (Player.activeSelf == false||playerMovement.Dead==true)
            {
                Firework.SetActive(true);
                PlayerPrefs.SetInt("HighScore", HighScore);
                Debug.Log(HighScore);
            }
        }  
        HighScoreUI.text = HighScore.ToString();
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.Save();
    }
}
