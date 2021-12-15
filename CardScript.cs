using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CardScript : MonoBehaviour
{
    public Sprite spriteBack;
    public Sprite spriteFront;
    public int type;

    private GameManager gameManager;

    private bool faceUp;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        gameObject.GetComponent<SpriteRenderer>().sprite = spriteBack;
    }

    private void OnMouseDown()
    {
        faceUp = !faceUp;
       if (faceUp ? gameObject.GetComponent<SpriteRenderer>().sprite = spriteFront : gameObject.GetComponent<SpriteRenderer>().sprite = spriteBack) { };

        gameManager.ClickOnCard(type);
    }

   

}
