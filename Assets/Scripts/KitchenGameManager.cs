using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{
    public static KitchenGameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;
    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver
    }

    private State state;

    private float waitingToStartTimer = 1f;
    private float coundownToStartTimer = 3f;
    private float gamePlayingTimer = 10f;


    private void Awake()
    {
        Instance = this;
        SetState(State.WaitingToStart);
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if(waitingToStartTimer < 0f)
                {
                    SetState(State.CountdownToStart);
                }
                break;
            case State.CountdownToStart:
                coundownToStartTimer -= Time.deltaTime;
                if (coundownToStartTimer < 0f)
                {
                    SetState(State.GamePlaying);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f)
                {
                    SetState(State.GameOver);
                }
                break;
            case State.GameOver:
                break;
        }

    }

    private void SetState(State state)
    {
        if(this.state != state)
        {
            this.state = state;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }


    }


    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public bool IsCountdownToStartActive()
    {
        return state == State.CountdownToStart;
    }

    public float GetCountdownToStartTimer()
    {
        return coundownToStartTimer;
    }
}
