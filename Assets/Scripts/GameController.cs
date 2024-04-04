using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    public event EventHandler OnStateChanged;

    public static GameController Instance{get; private set;}
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] Image timerImage;
    [SerializeField] float gameTime;
    private float sliderFillAmount = 1f;
    [Header("Game Over Screen")]
    [SerializeField] GameObject gameOver;
    [Header("Show High Score")]
    [SerializeField] TextMeshProUGUI highScoreText;
    private int highScore;
    

    private int playerScore = 0;

    public enum GameState{
        Waiting,
        Playing,
        GameOver
    }
    
    bool flag = false;

    public static GameState currentState;
    private void Awake() {
        Instance = this;
        currentState = GameState.Waiting;

        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //to avoid race conditions with GameAudio
        if(currentState == GameState.Waiting && flag == false)
        {
            OnStateChanged?.Invoke(this, EventArgs.Empty);
            flag = true;
        } 
        if(currentState == GameState.Playing)
        {
            AdjustTimer();
        }
    }
    void AdjustTimer()
    {
        timerImage.fillAmount = sliderFillAmount - (Time.deltaTime/gameTime);
        sliderFillAmount =timerImage.fillAmount;

        if(sliderFillAmount <=0)
        {
            CheckGameOver();
        }
    }
    void CheckGameOver()
    {
        currentState = GameState.GameOver;

        OnStateChanged?.Invoke(this, EventArgs.Empty);

        gameOver.SetActive(true);  //enabling reset canvas so that user can restart by shooting target
        if(playerScore > PlayerPrefs.GetInt("HighScore"))
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = highScore.ToString();
        }

    }
    public void ResetGame()
    {
        currentState = GameState.Waiting;

        OnStateChanged?.Invoke(this, EventArgs.Empty);

        sliderFillAmount = 1f;
        timerImage.fillAmount = 1f;

        playerScore = 0;
        score.text = "0";

    }
    public void UpdatePlayerScore(int getScore)
    {
        playerScore += getScore;
        score.text = playerScore.ToString();
    }
    public void StartGame()
    {
        currentState = GameState.Playing;

        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }
}
