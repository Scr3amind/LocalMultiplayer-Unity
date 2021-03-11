using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HeartController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite fullHeart = null;
    [SerializeField] private Sprite emptyHeart = null;
    
    public void makeEmpty()
    {
        spriteRenderer.sprite = emptyHeart;
    }

    public void makeFull()
    {
        spriteRenderer.sprite = fullHeart;
    }
}
