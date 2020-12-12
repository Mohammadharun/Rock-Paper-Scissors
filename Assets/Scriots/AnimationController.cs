using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator playerChoiceHandler;
    [SerializeField]
    private Animator choiceAnimation;

    public void ResetAnimations()
    {
        playerChoiceHandler.Play("ShowHandler");
        choiceAnimation.Play("RemoveChoices");
    }

    
    public void PlayerMadeChoice()
    {
        playerChoiceHandler.Play("RemoveHandler");
        choiceAnimation.Play("Show Choices");
    }
}
