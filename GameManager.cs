using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cartaPrefab;
    public List<GameObject> listaCartas = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        int posX = -6;
        int posY = 3;

        for (int i = 0; i < 10; i++)
        {

            GameObject newCartaPrefab = Instantiate(cartaPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
            listaCartas.Add(newCartaPrefab);
            newCartaPrefab.name = "card" + i;
            
            posX += 3;

            if(i == 4)
            {
                posX = -6;
                posY = -2;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
