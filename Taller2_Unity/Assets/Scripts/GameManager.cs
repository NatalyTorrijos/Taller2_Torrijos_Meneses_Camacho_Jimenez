using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text coinText;
    public TMP_Text poisonText;

    public static GameManager Instance;

    private float globalTime;
    public int scoreCoin;
    public int scorePoison;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    if (scene.name == "GameOver")
    //    {
    //        // Buscar los textos específicos de la escena final
    //        //TMP_Text finalApple = GameObject.Find("FinalAppleText")?.GetComponent<TextMeshProUGUI>();
    //        //TMP_Text finalBanana = GameObject.Find("FinalBananaText")?.GetComponent<TextMeshProUGUI>();
    //        //TMP_Text finalTotal = GameObject.Find("FinalTotalText")?.GetComponent<TextMeshProUGUI>();
    //        //TMP_Text finalTime = GameObject.Find("FinalTimeText")?.GetComponent<TextMeshProUGUI>();

    //        if (finalApple != null) finalApple.text = scoreCoin.ToString();
    //        if (finalBanana != null) finalBanana.text = scorePoison.ToString();
    //        if (finalTotal != null) finalTotal.text = (scoreCoin + scorePoison).ToString();
    //        if (finalTime != null)
    //        {
    //            finalTime.text = Timer.FormatTime(GlobalTime);
    //        }

    //        Time.timeScale = 0f; // congelar el juego en la escena final
    //    }
    //    else
    //    {
    //        // Escenas normales → HUD
    //        coinText = GameObject.Find("CoinText")?.GetComponent<TextMeshProUGUI>();
    //        poisonText = GameObject.Find("PoisonText")?.GetComponent<TextMeshProUGUI>();
    //        UpdateScoreUI();
    //    }
    //}

    void Start()
    {
        globalTime = 0;
        UpdateScoreUI();
    }


    public void TotalTime(float timeScene)
    {
        globalTime += timeScene;
    }

    public void TotalCoin(int Coin)
    {
        scoreCoin += Coin;
        UpdateScoreUI();
    }

    public void TotalPoison(int Poison)
    {
        scorePoison += Poison;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (coinText != null)
        {
            coinText.text = scoreCoin.ToString();
        }

        if (poisonText != null)
        {
            poisonText.text = scorePoison.ToString();
        }
    }

    public float GlobalTime { get => globalTime; set => globalTime = value; }

}