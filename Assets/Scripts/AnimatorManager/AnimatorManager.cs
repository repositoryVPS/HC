using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup> animators;

    public enum AnimationType 
    {
        RUN,
        IDLE,
        DEATH
    }

    public void Play(AnimationType type)
    {
        foreach (var animation in animators)
        {
            if(animation.type == type)
            {
                animator.SetTrigger(animation.trigger   );
                break;
            }
        }
    }
}
[System.Serializable]
public class AnimatorSetup 
{
    public AnimatorManager.AnimationType type;
    public string trigger;
}
