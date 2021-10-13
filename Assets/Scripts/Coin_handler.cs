using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_handler : MonoBehaviour
{
    public ParticleSystem destroyParticle;
    public int ScorePoint;
    private void OnTriggerEnter(Collider other)
    {
        destroyParticle.transform.parent = null;
        destroyParticle.Play();
        Destroy(gameObject);
    }
}
