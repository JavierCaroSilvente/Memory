using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cartaPrefab;
    private List<GameObject> listaCartas = new List<GameObject>();
    public List<Sprite> listSprite;
    int[] contador = { 0, 0, 0, 0, 0 };
    int[] types = { 7, 1, 0, 9, 6 };

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

            bool encontrado = false;
            int posRandom = 0; 

            while (!encontrado)
            {
                posRandom = Random.Range(0, 5);

                if (contador[posRandom] < 2)
                {
                    contador[posRandom] += 1;
                    encontrado = true;
                }
            }

            newCartaPrefab.GetComponent<CardScript>().spriteFront = listSprite[posRandom];
            newCartaPrefab.GetComponent<CardScript>().type = types[posRandom];

            initPosX += 3;

            if(i == saltoDeFila)
            {
                saltoDeFila += columnasY;
                initPosX = -6;
                initPosY += distanceBetweenCardsY;
            }
        }
    }

    public void ClickOnCard(int type)
    {
        Debug.Log("He hecho click on card " + type);
    }
}
