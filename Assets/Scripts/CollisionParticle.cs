using UnityEngine;
using System.Collections.Generic;

public class CollisionParticle : MonoBehaviour
{

    public ParticleSystem Collide1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Collide1.Stop();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
            Collide1.Play();
            
            
    }
}
