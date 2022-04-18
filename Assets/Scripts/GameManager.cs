using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] BallControl ball;

    [SerializeField] Text scoreText;
    string scoreFormat;

    [SerializeField] GameObject winCanvas;
    [SerializeField] Text winnerNameText;


    [SerializeField] GameObject pauseCanvas;
    bool isPaused = false;

    bool gameIsOver = false;

    void Start()
    {
        ball.OnHit += HitControl;
        ball.OnRightScore += RightScoreControl;
        ball.OnLeftScore += LeftScoreControl;
        ScoreControl();
    }

    private void Update()
    {
        if (RightPlayer.rightPlayerScore >= Globals.scoreToWin || LeftPlayer.leftPlayerScore >= Globals.scoreToWin)
        {
            gameIsOver = true;
            Win();
        }

        if (!gameIsOver && !isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.SetActive(true);
            PauseBackground();
            isPaused = true;
        }
        else if (!gameIsOver && isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.SetActive(false);
            UnpauseBackground();
            isPaused = false;
        }
    }

    void ScoreControl()
    {
        scoreFormat = $"{LeftPlayer.leftPlayerScore}   {RightPlayer.rightPlayerScore}";

        scoreText.text = scoreFormat;
    }

    void RightScoreControl()
    {
        // TODO: Play Sound
        RightPlayer.rightPlayerScore++;
        ScoreControl();
    }

    void LeftScoreControl()
    {
        // TODO: Play Sound
        LeftPlayer.leftPlayerScore++;
        ScoreControl();
    }

    void HitControl()
    {
        // TODO: Play Other Sound
    }

    void Win()
    {
        if (LeftPlayer.leftPlayerScore > RightPlayer.rightPlayerScore)
        {
            if (Globals.gameMode == GameMode.Computer)
            {
                winnerNameText.text = "COMPUTER";
            }
            else if (Globals.gameMode == GameMode.Local)
            {
                winnerNameText.text = "LEFT PLAYER";
            }
        }
        else if (LeftPlayer.leftPlayerScore < RightPlayer.rightPlayerScore)
        {
            if (Globals.gameMode == GameMode.Computer)
            {
                winnerNameText.text = "YOU";
            }
            else if (Globals.gameMode == GameMode.Local)
            {
                winnerNameText.text = "RIGHT PLAYER";
            }
        }

        PauseBackground();
        winCanvas.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        gameIsOver = false;
        LeftPlayer.leftPlayerScore = 0;
        RightPlayer.rightPlayerScore = 0;
        scoreText.text = "0   0";
        ball.transform.position = Vector3.zero;
    }

    void PauseBackground()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    void UnpauseBackground()
    {
        Time.timeScale = 1;
        isPaused = false;
    }
}
