﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    [Range(0, 1)]
    public float chancePercent;

    public GameObject characters;
    public GameObject player;

    public Vector3 center;
    public Vector3 size;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnCharacters()
    {
        //Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
