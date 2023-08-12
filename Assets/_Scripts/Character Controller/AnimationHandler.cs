using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private List<AnimationPlayer> animationPlayers = new List<AnimationPlayer>();

    public void PlayAnimation(PlayerAnimationTag animationTag)
    {
        foreach (var animation in animationPlayers)
        {
            if (animation.GetTag() == animationTag)
            {
                animator.Play(animation.GetHashedName(), 0, 0.2f);
            }
        }
    }

    public void PlayAnimation(string animationTag)
    {
        foreach (var animation in animationPlayers)
        {
            if (animation.GetName().Equals(animationTag))
            {
                animator.Play(animation.GetHashedName(), 0, 0.2f);
            }
        }
    }

    public void MoveAnimationHandler(bool isJumping, Vector2 direction, SpriteRenderer spriteRenderer)
    {
        if (direction.sqrMagnitude > 0)
        {
            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            if (isJumping == false)
            {
                PlayAnimation(PlayerAnimationTag.Walk);
            }
        }
        else
        {
            if (isJumping == false)
                PlayAnimation(PlayerAnimationTag.Idle);
        }
    }
}

[System.Serializable]
public class AnimationPlayer
{
    [SerializeField]
    private PlayerAnimationTag tag;

    [SerializeField]
    private string animationName;

    public PlayerAnimationTag GetTag()
    {
        return tag;
    }

    public string GetName()
    {
        return animationName;
    }

    public int GetHashedName()
    {
        return Animator.StringToHash(animationName);
    }
}

public enum PlayerAnimationTag
{
    Idle,
    Walk,
    Jump
}