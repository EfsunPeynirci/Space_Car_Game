using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject StartMenuPanel;
    public GameObject FailMenuPanel;
    public GameObject spaceShipGo;
    public GameObject enemySpawnerGo;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI highScoreText;

    int score = 0;

    private int highScore;
    private SpaceShipController spaceShipScript;
    private EnemySpawnerController enemySpawnerScript;
    public static GameManager instance;

    //instance değişkeni, Singleton deseni kullanılarak GameManager sınıfının yalnızca bir örneğinin olmasını sağlar.
    //Singleton deseni, belirli bir sınıfın yalnızca bir kez oluşturulmasını ve bu örneğin her yerden erişilebilmesini sağlar.
    //bir odada bir tane patron sandalyesi var ve bu sandalyeye sadece bir kişi oturabilir.
    //instance, bu sandalyeye oturan kişiyi temsil eder. Eğer odaya bir kişi girip oturmak isterse, instance kontrol edilir.
    //Eger instance yazılmazsa su gibi cagirirdik. Ama biz burada tek bir ornek olusmasini saglamis olduk
    //GameManager gameManager1 = new GameManager();
    //GameManager gameManager2 = new GameManager();
    //Iki tane GameManager olusmus olurdu

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        spaceShipScript = spaceShipGo.GetComponent<SpaceShipController>();
        enemySpawnerScript = enemySpawnerGo.GetComponent<EnemySpawnerController>();
        GetHighScore();
    }

    void Update()
    {
        
    }

    public void ShowFailMenu()
    {
        FailMenuPanel.SetActive(true);
        spaceShipScript.StopSpaceShip();
        enemySpawnerScript.StopCreatingEnemyShip();
    }

    public void StartButtonTapped()
    {
        StartMenuPanel.SetActive(false);
        spaceShipScript.StartSpaceShip();
        enemySpawnerScript.StartCreatingEnemyShip();
    }

    public void RestartButtonTapped()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SpaceShipGotShoot()
    {
        ShowFailMenu();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "SCORE : " + score.ToString();

        if(score > highScore)
        {
            PlayerPrefs.SetInt("keyHighScore", score);
        }
    }

    private void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("keyHighScore", 0);
        highScoreText.text = "KEY HIGH SCORE : " + highScore.ToString();
    }
}
