using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameChoices
{
    NONE,
    ROCK,
    PAPER,
    SCISSORS
}

public class GameplayManager : MonoBehaviour
{
    [SerializeField]
    private Sprite rock_Sprite, paper_Sprite, scissor_Sprite;

    [SerializeField]
    private Image player_Image, opponent_Image;

    [SerializeField]
    private Text infoText;


    private GameChoices playerChoice = GameChoices.NONE, opponentChoice = GameChoices.NONE;

    private AnimationController animationController;

    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
    }

    public void SetChocies(GameChoices gameChoices)
    {
        switch(gameChoices)
        {
            case GameChoices.ROCK:
                player_Image.sprite = rock_Sprite;

                playerChoice = GameChoices.ROCK;

                break;
            case GameChoices.PAPER:
                player_Image.sprite = paper_Sprite;
                playerChoice = GameChoices.PAPER;
                break;
            case GameChoices.SCISSORS:
                player_Image.sprite = scissor_Sprite;
                playerChoice = GameChoices.SCISSORS;
                break;
        }

        SetOpponentChocie();
        DetermineWinner();
    }

    void SetOpponentChocie()
    {
        int rnd = Random.Range(0, 3);

        switch(rnd)
        {
            case 0:
                opponent_Image.sprite = rock_Sprite;
                opponentChoice = GameChoices.ROCK;
                break;
            case 1:
                opponent_Image.sprite = paper_Sprite;
                opponentChoice = GameChoices.PAPER;
                break;
            case 2:
                opponent_Image.sprite = scissor_Sprite;
                opponentChoice = GameChoices.SCISSORS;
                break;
        }
    }

    void DetermineWinner()
    {
        if(playerChoice == opponentChoice)
        {
            infoText.text = "DRAW";
            StartCoroutine(DisplayWinnerAndRestart());
        }

        if(playerChoice == GameChoices.PAPER && opponentChoice == GameChoices.ROCK)
        {
            infoText.text = "WIN";
            StartCoroutine(DisplayWinnerAndRestart());
            return;
        }
        if(playerChoice == GameChoices.ROCK && opponentChoice == GameChoices.SCISSORS)
        {
            infoText.text = "WIN";
            StartCoroutine(DisplayWinnerAndRestart());
            return;
        }
        if(playerChoice == GameChoices.SCISSORS && opponentChoice == GameChoices.PAPER)
        {
            infoText.text = "WIN";
            StartCoroutine(DisplayWinnerAndRestart());
            return;
        }
        if (opponentChoice == GameChoices.PAPER && playerChoice == GameChoices.ROCK)
        {
            infoText.text = "LOSE";
            StartCoroutine(DisplayWinnerAndRestart());
        }
        if (opponentChoice == GameChoices.ROCK && playerChoice == GameChoices.SCISSORS)
        {
            infoText.text = "LOSE";
            StartCoroutine(DisplayWinnerAndRestart());
            return;
        }
        if (opponentChoice == GameChoices.SCISSORS && playerChoice == GameChoices.PAPER)
        {
            infoText.text = "LOSE";
            StartCoroutine(DisplayWinnerAndRestart());
            return;
        }
    }

    IEnumerator DisplayWinnerAndRestart()
    {
        yield return new WaitForSeconds(1.5f);
        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        infoText.gameObject.SetActive(false);

        animationController.ResetAnimations();
    }


}
