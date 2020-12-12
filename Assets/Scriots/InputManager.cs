using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private AnimationController animationController;
    private GameplayManager gameplayManager;

    private string playerChoice;

    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
        gameplayManager = GetComponent<GameplayManager>();
    }

    public void GetChoice()
    {
        string ChoiceName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        GameChoices selectedChoice = GameChoices.NONE;

        switch(ChoiceName)
        {
            case "Rock":
                selectedChoice = GameChoices.ROCK;
                break;
            case "Paper":
                selectedChoice = GameChoices.PAPER;
                break;
            case "Scissor":
                selectedChoice = GameChoices.SCISSORS;
                break;
        }

        gameplayManager.SetChocies(selectedChoice);
        animationController.PlayerMadeChoice();
    }
}
