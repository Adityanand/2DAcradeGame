using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    GameObject GameManager;
    public void Next()
    {
        SceneManager.LoadScene("Loading Scene");
    }
    public void Quit()
    {
        Destroy(GameManager);
        Application.Quit();
    }
    public void Retry()
    {
        Destroy(GameManager);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GM"); 
    }
}
