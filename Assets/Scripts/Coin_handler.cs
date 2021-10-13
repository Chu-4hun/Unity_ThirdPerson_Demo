using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_handler : MonoBehaviour
{
    public ParticleSystem destroyParticle;
    private Player_ThirdPerson_Script playerScript;
    public int ScorePoint;

    public void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<Player_ThirdPerson_Script>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            playerScript.coins += ScorePoint;
            Debug.Log(ScorePoint + "Added");
            destroyParticle.transform.parent = null;
            destroyParticle.Play();
            Destroy(gameObject);
        }
    }
}