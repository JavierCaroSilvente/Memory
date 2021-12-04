using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cartaPrefab;
    private List<GameObject> listaCartas = new List<GameObject>();

    public int filasX;
    public int columnasY;

    // Start is called before the first frame update
    void Start()
    {
        int initPosX = -6;
        int initPosY = 2;

        int cardsAmount = filasX * columnasY;
        int saltoDeFila = columnasY - 1;
        int distanceBetweenCardsY = -4;

        for (int i = 0; i < cardsAmount; i++)
        {
            GameObject newCartaPrefab = Instantiate(cartaPrefab, new Vector3(initPosX, initPosY, 0), Quaternion.identity);
            listaCartas.Add(newCartaPrefab);
            newCartaPrefab.name = "card" + i;

            initPosX += 3;

            if(i == saltoDeFila)
            {
                saltoDeFila += columnasY;
                initPosX = -6;
                initPosY += distanceBetweenCardsY;
            }
        }
    }
}
