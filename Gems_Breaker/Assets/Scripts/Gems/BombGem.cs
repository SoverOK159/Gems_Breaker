using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGem : Gem
{
    [SerializeField] float explosionRadius;

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        Explosion();
    }

    void Explosion()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D icoll in col)
        {
           if(icoll.tag == "Destroyable") 
            {
                icoll.GetComponent<Destroyable>().Explos();
                Destroy(icoll.gameObject);
            }
        }
    }
    public override void Death()
    {
        base.Death();
        FindObjectOfType<StageManager>().NormalGemsInLevel--;
    }

}
