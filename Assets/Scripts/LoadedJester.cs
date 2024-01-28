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
            UpdateVisual(0);
        }
    }

    public void LoadJester(Jester jester, int costume)
    {
        ActiveJester = jester;

        UpdateVisual(costume);
    }

    private void UpdateVisual(int costume)
    {
        if (costume == 0)
        {
            SpriteComponent.sprite = ActiveJester.IdleSprite;
        }
        else
        {
            SpriteComponent.sprite = ActiveJester.CostumeSprite;
        }
    }
}
