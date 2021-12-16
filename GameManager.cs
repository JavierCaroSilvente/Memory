using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject cartaPrefab;
    private List<GameObject> listaCartas = new List<GameObject>();
    public List<Sprite> listSprite;

    public Text Text;

    int[] contador = { 0, 0, 0, 0, 0 };
    int[] types = { 7, 1, 0, 9, 6 };

    public int filasX;
    public int columnasY;

    private int totalCartasDescubiertas = 0;
    private int cartaDescubierta1 = 0;
    private int cartaDescubierta2 = 0;

    private int puntuacion = 0;

    // Start is called before the first frame update
    void Start()
    {
        Text.text = "Numero de parejas: " + puntuacion.ToString();

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
        Debug.Log(type);
        totalCartasDescubiertas++;

       if(totalCartasDescubiertas <= 2)
       {
            if (totalCartasDescubiertas == 1) 
            {
                cartaDescubierta1 = type;
            }

            if (totalCartasDescubiertas == 2)
            {
                cartaDescubierta2 = type;
            }
       }

        if (totalCartasDescubiertas == 2)
        {
            if(cartaDescubierta1 == cartaDescubierta2)
            {
                Debug.Log("Las cartas coinciden!");

                puntuacion++;
                Text.text = "Numero de parejas: " + puntuacion.ToString();

                for (int i = 0; i < listaCartas.Count; i++)
                {
                    if(listaCartas[i].GetComponent<CardScript>().type == type)
                    {
                        listaCartas[i].gameObject.SetActive(false);
                    }
                }

                totalCartasDescubiertas = 0;
            }
            else
            {
                Debug.Log("Las cartas NO coinciden!");
                for (int i = 0; i < listaCartas.Count; i++)
                {
                    listaCartas[i].GetComponent<BoxCollider2D>().enabled = false;
                    listaCartas[i].GetComponent<CardScript>().faceUp = false;
                }

                StartCoroutine(ResetCartas(type));
            }
        }
    }

    IEnumerator ResetCartas(int type)
    {
        yield return new WaitForSeconds(2);

        for (int i = 0; i < listaCartas.Count; i++)
        {
            listaCartas[i].GetComponent<SpriteRenderer>().sprite = listaCartas[i].GetComponent<CardScript>().spriteBack;
            listaCartas[i].GetComponent<BoxCollider2D>().enabled = true;
        }

        totalCartasDescubiertas = 0;
    }
}
