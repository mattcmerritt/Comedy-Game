using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerformanceScroll : MonoBehaviour
{
    [SerializeField] private Jester Jester;
    [SerializeField] private Image JesterSprite;
    [SerializeField] private GameObject ExecutedText;
    [SerializeField] private Image ReactionIcon;
    [SerializeField] private Sprite PositiveSprite, NegativeSprite, NeutralSprite;
    [SerializeField] private Animator CardAnimator;

    private void OnDisable()
    {
        ResetScroll();
    }

    public void SetJester(Jester jester)
    {
        Jester = jester;
        SetScrollSprites(jester);
    }

    public Jester GetJester()
    {
        return Jester;
    }

    public bool CheckForJester()
    {
        return Jester != null;
    }

    public void SetScrollSprites(Jester jester)
    {
        if (jester == null)
        {
            JesterSprite.color = new Color(255, 255, 255, 0); // if the jester is null, make the sprite invisible
        }
        else
        {
            JesterSprite.sprite = jester.IdleSprite;
            JesterSprite.color = new Color(255, 255, 255, 255);
        }
    }

    public void MarkAsExecuted()
    {
        ExecutedText.SetActive(true);
    }

    public void ResetScroll()
    {
        ExecutedText.SetActive(false);
        ReactionIcon.gameObject.SetActive(false);
    }

    public void SetReactionSprite(int score)
    {
        if (score > 0)
        {
            ReactionIcon.sprite = PositiveSprite;
        }
        else if (score < 0)
        {
            ReactionIcon.sprite = NegativeSprite;
        }
        else
        {
            ReactionIcon.sprite = NeutralSprite;
        }
        ReactionIcon.gameObject.SetActive(true);
    }

    public void PlayHighlightAnimation()
    {
        CardAnimator.SetTrigger("Highlight");
    }
}
