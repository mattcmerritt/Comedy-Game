using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PerformanceScreen : MonoBehaviour
{
    [SerializeField] GameObject AudioManager;
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
    [SerializeField] private int PerformancesWithKing;

    private bool Started;

    private void Start()
    {
        PerformancesWithKing = 0;
    }

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
            if(PerformancesWithKing >= 3)
            {
                KingManager km = FindObjectOfType<KingManager>();
                km.GenerateNewKing();
                SetKingPreferences(km.GetPreferences());
                PerformancesWithKing = 0;
                Debug.Log("A new king has been generated!");
            }
            else
            {
                PerformancesWithKing += 1;
            }
            Started = true;
            StartCoroutine(PlayPerformance());
        }
    }

    public void SetKingPreferences(List<HumorStat> newReqs)
    {
        RequiredHumor = newReqs;
    }

    public IEnumerator PlayPerformance()
    {
        // show character 1
        ActiveJester = JesterInventory.Instance.GetJester(0);
        ActiveItem = JesterInventory.Instance.GetJestersItem(0);
        CurrentlyPerformingCharacter.LoadJester(ActiveJester,1 );
        yield return StartCoroutine(JesterEnter());
        yield return StartCoroutine(JesterPerform());
        yield return StartCoroutine(JesterExit());

        // show character 2
        ActiveJester = JesterInventory.Instance.GetJester(1);
        ActiveItem = JesterInventory.Instance.GetJestersItem(1);
        CurrentlyPerformingCharacter.LoadJester(ActiveJester, 1);
        yield return StartCoroutine(JesterEnter());
        yield return StartCoroutine(JesterPerform());
        yield return StartCoroutine(JesterExit());

        // show character 3
        ActiveJester = JesterInventory.Instance.GetJester(2);
        ActiveItem = JesterInventory.Instance.GetJestersItem(2);
        CurrentlyPerformingCharacter.LoadJester(ActiveJester, 1);
        yield return StartCoroutine(JesterEnter());
        yield return StartCoroutine(JesterPerform());
        yield return StartCoroutine(JesterExit());

        // feedback
        JesterInventory.Instance.EnablePerformanceUI();
        bool success = OverallScore > 0;
        yield return StartCoroutine(JesterInventory.Instance.ShowFeedback(0, PerformanceScores[0], success));
        yield return StartCoroutine(JesterInventory.Instance.ShowFeedback(1, PerformanceScores[1], success));
        yield return StartCoroutine(JesterInventory.Instance.ShowFeedback(2, PerformanceScores[2], success));

        //play crowd reaction audio
        if (success)
        {
            AudioClip crowd = AudioManager.GetComponent<AudioManager>().GetCrowdClip(1);
            AudioManager.GetComponent<AudioSource>().PlayOneShot(crowd);
        }
        else
        {
            AudioClip crowd = AudioManager.GetComponent<AudioManager>().GetCrowdClip(2);
            AudioManager.GetComponent<AudioSource>().PlayOneShot(crowd);
        }
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

        //audio clip
        AudioClip kingClip = null;

        if (currentScore > 0)
        {
            KingReaction.sprite = PositiveReaction;
            kingClip = AudioManager.GetComponent<AudioManager>().GetKingClip(0);
        }
        else if (currentScore < 0)
        {
            KingReaction.sprite = NegativeReaction;
            kingClip = AudioManager.GetComponent<AudioManager>().GetKingClip(2);
        }
        else
        {
            KingReaction.sprite = NeutralReaction;
            kingClip = AudioManager.GetComponent<AudioManager>().GetKingClip(1);
        }

        //play sound reaction
        if (kingClip != null)
        {
            AudioManager.GetComponent<AudioSource>().PlayOneShot(kingClip);
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
