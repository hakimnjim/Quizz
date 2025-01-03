using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject manager = new GameObject("GameManager");
                _instance = manager.AddComponent<GameManager>();
                DontDestroyOnLoad(manager);
            }
            return _instance;
        }
    }

    public Func<ScreenType, Transform, ScreenUIController> OnSpawnScreen;
    public Action<ScreenType, Transform> OnDestroyScreenController;
    public Action<string> OnValidateResponce;
    private Quiz quiz;

    private int playerScore;
    public int PlayerScore => playerScore;

    private int quizIndex = 0;
    public int QuizIndex => quizIndex;

    private AudioSource bgMusicSource;
    private AudioSource responseAudioSource;

    private AudioClip bgMusicClip;
    private AudioClip correctAnswerClip;
    private AudioClip wrongAnswerClip;
    private float musicVolume;
    public float MusicVolume => musicVolume;
    private float vfxVolume;
    public float VfxVolume => vfxVolume;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
        InitializeAudioSources();
        LoadAudioClipsFromResources();
        LoadQuizFromResources();
        PlayBackgroundMusic();
        
    }

    private void Start()
    {
        LoadGameSetting();
        UpdateMusicVolume(musicVolume);
        UpdateVfxVolume(vfxVolume);
    }

    private void LoadGameSetting()
    {
        if (PlayerPrefs.HasKey("vfxVolume"))
        {
            vfxVolume = PlayerPrefs.GetFloat("vfxVolume");
        }
        else
        {
            vfxVolume = 0.5f;
            PlayerPrefs.SetFloat("vfxVolume", vfxVolume);
        }

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {
            musicVolume = 0.5f;
            PlayerPrefs.SetFloat("musicVolume", musicVolume);
        }
    }
    
    public void UpdateVfxVolume(float volume)
    {
        vfxVolume = volume;
        PlayerPrefs.SetFloat("vfxVolume", vfxVolume);
        responseAudioSource.volume = vfxVolume;
    }

    public void UpdateMusicVolume(float volume)
    {
        musicVolume = volume;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        bgMusicSource.volume = musicVolume;
    }

    private void InitializeAudioSources()
    {
        bgMusicSource = gameObject.AddComponent<AudioSource>();
        responseAudioSource = gameObject.AddComponent<AudioSource>();

        bgMusicSource.loop = true; // Loop background music
    }

    private void LoadAudioClipsFromResources()
    {
        bgMusicClip = Resources.Load<AudioClip>("Audio/BGMusic");
        correctAnswerClip = Resources.Load<AudioClip>("Audio/CorrectAnswer");
        wrongAnswerClip = Resources.Load<AudioClip>("Audio/WrongAnswer");

        if (bgMusicClip == null || correctAnswerClip == null || wrongAnswerClip == null)
        {
            Debug.LogError("Failed to load one or more audio clips from Resources. Ensure the audio files are located in Resources/Audio.");
        }
    }

    private void PlayBackgroundMusic()
    {
        if (bgMusicClip != null)
        {
            bgMusicSource.clip = bgMusicClip;
            bgMusicSource.Play();
        }
    }

    private void PlayResponseAudio(bool isCorrect)
    {
        if (isCorrect && correctAnswerClip != null)
        {
            responseAudioSource.PlayOneShot(correctAnswerClip);
        }
        else if (!isCorrect && wrongAnswerClip != null)
        {
            responseAudioSource.PlayOneShot(wrongAnswerClip);
        }
    }

    private void LoadQuizFromResources()
    {
        quiz = Resources.Load<Quiz>("NewQuiz");

        if (quiz == null)
        {
            Debug.LogError("Failed to load Quiz from Resources! Ensure it is placed in a 'Resources' folder.");
        }
    }

    public Question GetQuestion()
    {
        Debug.Log(quiz.questions.Count);
        if (quizIndex > quiz.questions.Count - 1)
        {
            return null;
        }
        else
        {
            return quiz.questions[quizIndex];
        }
    }

    public bool CheckIndex()
    {
        if (quizIndex > quiz.questions.Count - 1)
        {
            return false;
        }
        return true;
    }

    public void CheckResponce(string responce)
    {
        int index = quiz.questions[quizIndex].responses.FindIndex(x => x.isCorrect == true);
        var correctResponce = quiz.questions[quizIndex].responses[index].responseText;
        if (OnValidateResponce != null)
        {
            OnValidateResponce(correctResponce);
        }

        if (correctResponce == responce)
        {
            AddScore(10);
            PlayResponseAudio(true);
        }
        else
        {
            PlayResponseAudio(false);
        }
        UpdateQuizzIndex();
    }

    private void UpdateQuizzIndex()
    {
        quizIndex++;
    }

    public void AddScore(int points)
    {
        playerScore += points;
        Debug.Log("Current Score: " + playerScore);
    }

    public void ResetGame()
    {
        playerScore = 0;
        quizIndex = 0;
    }
}
