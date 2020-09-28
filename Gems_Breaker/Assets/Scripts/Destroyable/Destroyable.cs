using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyParticle;

    public void Explos()
    {
        Instantiate(destroyParticle, transform.position, transform.rotation);
    }
}
