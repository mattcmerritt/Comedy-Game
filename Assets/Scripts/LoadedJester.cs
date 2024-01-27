using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadedJester : MonoBehaviour
{
    [SerializeField] private Jester ActiveJester;
    [SerializeField] private SpriteRenderer SpriteComponent;

    // possibly will need this for animating the current jester
    // [SerializeField] private Animator Animator;

    private void Awake()
    {
        if (ActiveJester != null)
        {
            UpdateVisual();
        }
    }

    public void LoadJester(Jester jester)
    {
        ActiveJester = jester;

        UpdateVisual();
    }

    private void UpdateVisual()
    {
        // TODO: remove this check, all jesters should have sprites
        if (ActiveJester.IdleSprite != null)
        {
            SpriteComponent.sprite = ActiveJester.IdleSprite;
        }
    }
}
