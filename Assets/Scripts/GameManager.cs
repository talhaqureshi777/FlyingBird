using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject obstaclePrefeb;
    public GameObject coinsPrefeb;
    public float timer = 0f;
    public bool isGameOver = false;
    public GameObject GameoverPanal;
    public GameObject PausePanal;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isGameOver = false; 
        GameoverPanal.SetActive(false);
        PausePanal.SetActive(false);
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if(timer <=0f)
        {
            if(isGameOver == false)
            {
                GameObject gm = Instantiate(obstaclePrefeb, new Vector3(5f, Random.Range(-3f, 0f), 0f),Quaternion.identity);
                Destroy(gm,5f);
                GameObject coinTemp = Instantiate(coinsPrefeb, new Vector3(3f, Random.Range(-3f, 3f), 0f), Quaternion.identity);
                Destroy(coinTemp, 5f);
                timer = 2f;
            }
        }
        else
        {
            timer = timer - Time.deltaTime;
        }
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseBtnClicked()
    {
        Time.timeScale = 0f;
        PausePanal.SetActive(true);
    }
    public void ResumeBtnClicked()
    {
        Time.timeScale = 1f;
        PausePanal.SetActive(false);
    }
}
