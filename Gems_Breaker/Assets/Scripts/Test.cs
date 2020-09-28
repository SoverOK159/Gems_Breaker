using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] float radius = 3;

    private void Update()
    {
        Explosion();
    }

    void Explosion()
    {
        Collider2D [] col = Physics2D.OverlapCircleAll(transform.position,radius);

        foreach (Collider2D icoll in col)
        {
            Destroy(icoll.gameObject);
        }
    }
}
