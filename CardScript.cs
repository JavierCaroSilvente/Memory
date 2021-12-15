using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CardScript : MonoBehaviour
{
    public Sprite spriteBack;
    public Sprite spriteFront;

    private bool position;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteBack;
    }

    private void OnMouseDown()
    {
        position = !position;
        Debug.Log("He hecho clic en la carta " + name);
        if (position ? gameObject.GetComponent<SpriteRenderer>().sprite = spriteFront : gameObject.GetComponent<SpriteRenderer>().sprite = spriteBack) { };
       
    }

}
