using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomness : MonoBehaviour
{

    public GameObject leftArm, rightArm, character;

    private Renderer leftArmMat, rightArmMat, characterMat;

    public float chance;
    public bool isPlayer = false;

    public gameManager GM;

    public float moveSpeed = 2;

    private void Awake()
    {
        character = gameObject;

        GM = FindObjectOfType<gameManager>();
        
        leftArmMat = leftArm.GetComponent<Renderer>();
        rightArmMat = rightArm.GetComponent<Renderer>();
        characterMat = character.GetComponent<Renderer>();

        leftArmMat.material.color = Color.green;
        rightArmMat.material.color = Color.green;

        randomise();

        if(isPlayer == true)
        {
            chance = 0;
        }

        if(isPlayer == false)
        {
            chance = GM.chancePercent;
        }
    }

    public void randomise()
    {
        if (isPlayer == false)
        {
            chance = Random.value;
            print("Randomised");

            return;
        }
    }

    void Update()
    {
        if (chance > GM.chancePercent)
        {
            posLeftArmCheck();
            posRightArmCheck();
            moveAxis();
        }

        if (chance <= GM.chancePercent)
        {
            negLeftArmCheck();
            negRightArmCheck();
            moveReverseAxis();
        }
    }

    private void moveAxis()
    {
        var moveLeftRightAmount = Input.GetAxis("moveLeftRight");
        var moveUpDownAmount = Input.GetAxis("moveUpDown");

        transform.position = transform.position + new Vector3(moveLeftRightAmount * moveSpeed * Time.deltaTime, moveUpDownAmount * moveSpeed * Time.deltaTime);

        //randomise();
    }

    private void moveReverseAxis()
    {
        var moveLeftRightAmount = Input.GetAxis("moveLeftRight");
        var moveUpDownAmount = Input.GetAxis("moveUpDown");

        transform.position = transform.position - new Vector3(moveLeftRightAmount * moveSpeed * Time.deltaTime, moveUpDownAmount * moveSpeed * Time.deltaTime);

        //randomise();
    }

    private void move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate = transform.position.x + moveSpeed * Time.deltaTime);
        }
    }

    private void posLeftArmCheck()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            leftArmMat.material.color = Color.red;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            leftArmMat.material.color = Color.green;
            randomise();
        }
    }

    private void posRightArmCheck()
    {
        if (Input.GetKey(KeyCode.E))
        {
            rightArmMat.material.color = Color.red;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            rightArmMat.material.color = Color.green;
            randomise();
        }
    }

    private void negLeftArmCheck()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rightArmMat.material.color = Color.red;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            rightArmMat.material.color = Color.green;
            randomise();
        }
    }

    private void negRightArmCheck()
    {
        if (Input.GetKey(KeyCode.E))
        {
            leftArmMat.material.color = Color.red;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            leftArmMat.material.color = Color.green;
            randomise();
        }
    }
}
