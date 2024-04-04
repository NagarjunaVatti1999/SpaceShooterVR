using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource audioSource;
    [SerializeField] public SOAudioClips[] gamePlayAudios;
    void Start()
    {
        GameController.Instance.OnStateChanged += GameController_Intro;
        GameController.Instance.OnStateChanged += GameController_MainGame;
        GameController.Instance.OnStateChanged += GameController_GameOver;
        audioSource = GetComponent<AudioSource>();
    }

    private void GameController_GameOver(object sender, EventArgs e)
    {
        if(GameController.currentState == GameController.GameState.Waiting)
        {
            foreach(SOAudioClips so in gamePlayAudios)
            {
                if(so.audio_name == "Intro")
                {
                    audioSource.clip = so.clip;
                    audioSource.Play();
                }
            }
        }
    }

    private void GameController_MainGame(object sender, EventArgs e)
    {
        if(GameController.currentState == GameController.GameState.Playing)
        {
            foreach(SOAudioClips so in gamePlayAudios)
            {
                if(so.audio_name == "MainGame")
                {
                    audioSource.clip = so.clip;
                    audioSource.Play();
                }
            }
        }
    }

    private void GameController_Intro(object sender, EventArgs e)
    {
        if(GameController.currentState == GameController.GameState.GameOver)
        {
            foreach(SOAudioClips so in gamePlayAudios)
            {
                if(so.audio_name == "GameOver")
                {
                    audioSource.clip = so.clip;
                    audioSource.Play();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
