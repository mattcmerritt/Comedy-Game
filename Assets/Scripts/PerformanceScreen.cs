using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PerformanceScreen : MonoBehaviour
{
    [SerializeField] private List<HumorStat> RequiredHumor;

    [SerializeField] private Jester ActiveJester;
    [SerializeField] private Item ActiveItem;
    [SerializeField] private LoadedJester CurrentlyPerformingCharacter;
    [SerializeField] private Animator CharacterAnimator, SpeechBubbleAnimator, KingReactionAnimator;
    [SerializeField] private SpriteRenderer KingReaction;
    [SerializeField] private Sprite PositiveReaction, NeutralReaction, NegativeReaction;
    [SerializeField] private TMP_Text SpeechContent;

    [SerializeField] private float EnterAnimationDuration, ReactAnimationDuration, ExitAnimationDuration, SpeechBubbleAppearDuration, SpeechBubbleDisappearDuration;

    [SerializeField] private List<int> PerformanceScores;
    [SerializeField] private int OverallScore;
    [SerializeField] private JokeCollection JokeCollection;

    private bool Started;

    private void OnEnable()
    {
        Started = false;
        PerformanceScores = new List<int>();
        OverallScore = 0;
    }

    private void Update()
    {
        if (!Started)
        {
            Started = true;
            StartCoroutine(PlayPerformance());
        }
    }

    public IEnumerator PlayPerformance()
    {
        // show character 1
        ActiveJester = JesterInventory.Instance.GetJester(0);
        ActiveItem = JesterInventory.Instance.GetJestersItem(0);
        CurrentlyPerformingCharacter.LoadJester(ActiveJester);
        yield return StartCoroutine(JesterEnter());
        yield return StartCoroutine(JesterPerform());
        yield return StartCoroutine(JesterExit());

        // show character 2
        ActiveJester = JesterInventory.Instance.GetJester(1);
        ActiveItem = JesterInventory.Instance.GetJestersItem(1);
        CurrentlyPerformingCharacter.LoadJester(ActiveJester);
        yield return StartCoroutine(JesterEnter());
        yield return StartCoroutine(JesterPerform());
        yield return StartCoroutine(JesterExit());

        // show character 3
        ActiveJester = JesterInventory.Instance.GetJester(2);
        ActiveItem = JesterInventory.Instance.GetJestersItem(2);
        CurrentlyPerformingCharacter.LoadJester(ActiveJester);
        yield return StartCoroutine(JesterEnter());
        yield return StartCoroutine(JesterPerform());
        yield return StartCoroutine(JesterExit());
    }

    public IEnumerator JesterEnter()
    {
        Debug.Log("Jester Enter");
        // have the character slide in
        CharacterAnimator.SetTrigger("Enter");
        yield return new WaitForSeconds(EnterAnimationDuration);
    }

    public IEnumerator JesterPerform()
    {
        Debug.Log("Jester Perform");
        // cause the speech bubble to appear
        SpeechBubbleAnimator.SetTrigger("Speak");
        // populate speech bubble based on humor type
        SpeechContent.text = JokeCollection.GetRandomJokeLine(ActiveJester.HumorStats[Random.Range(0, ActiveJester.HumorStats.Count)].Type);
        yield return new WaitForSeconds(SpeechBubbleAppearDuration);

        // cause the king to play the little animation based on if they were happy, neutral, or angry
        // need to swap the sprite, the animation will cause it to move and fade in and out
        int currentScore = 0;
        foreach (HumorStat humorRequirement in RequiredHumor)
        {
            foreach (HumorStat humor in ActiveJester.HumorStats)
            {
                if (humor.Type == humorRequirement.Type)
                {
                    currentScore += humorRequirement.Value;
                }
            }

            if (ActiveItem.name != "Nothing" && ActiveItem.HumorStat.Type == humorRequirement.Type)
            {
                currentScore += humorRequirement.Value;
            }
        }
        PerformanceScores.Add(currentScore);
        OverallScore += currentScore;

        if (currentScore > 0)
        {
            KingReaction.sprite = PositiveReaction;
        }
        else if (currentScore < 0)
        {
            KingReaction.sprite = NegativeReaction;
        }
        else
        {
            KingReaction.sprite = NeutralReaction;
        }

        KingReactionAnimator.SetTrigger("React");
        yield return new WaitForSeconds(ReactAnimationDuration);

        // have the speech bubble disappear
        SpeechBubbleAnimator.SetTrigger("StopSpeaking");
        yield return new WaitForSeconds(SpeechBubbleDisappearDuration);
    }

    public IEnumerator JesterExit()
    {
        Debug.Log("Jester Exit");
        // have the character slide out
        CharacterAnimator.SetTrigger("Exit");
        yield return new WaitForSeconds(ExitAnimationDuration);
    }
}