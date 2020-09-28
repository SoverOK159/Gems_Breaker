using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject destroyParticle;

    [SerializeField] int speed;

    [SerializeField] float randomFactor = 0.2f;

    public int Speed
    {
        get { return speed; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Death Zone"))
        {
            Destroy(gameObject);
            Instantiate(destroyParticle, this.transform.position, Quaternion.identity);
        }
    }

    private void RandomiseBouncing()
    {
        Rigidbody2D rigidbody2D = this.GetComponent<Rigidbody2D>();
        Vector2 vector2 = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        rigidbody2D.velocity += vector2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RandomiseBouncing();
    }
}
