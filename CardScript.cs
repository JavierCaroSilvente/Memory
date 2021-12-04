using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CardScript : MonoBehaviour
{
    public Sprite spriteBack;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteBack;

        gameObject.transform.position = new Vector3(-1, 3, 0);
    }

}
