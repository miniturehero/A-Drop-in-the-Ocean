using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    [Range(0, 1)]
    public float chancePercent;

    public GameObject[] characters;
    public GameObject player;

    public Text loseText;

    void Start()
    {
        loseText.text = "";
        characters = GameObject.FindGameObjectsWithTag("Characters");
        int playerNumber = Random.Range(0, characters.Length);
        player = characters[playerNumber];

        characters[playerNumber].GetComponent<randomness>().isPlayer = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Destroy(hit.collider.gameObject);
                //characters[i] = null;

                if(hit.collider.gameObject == player)
                {
                    print("You Lose!");

                    lose();
                }
            }
        }
    }

    void lose()
    {
        loseText.text = "You Lose!";
    }

    void win()
    {

    }
}
