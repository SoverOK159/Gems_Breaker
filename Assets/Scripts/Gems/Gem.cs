using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{
    [SerializeField] GameObject hitParticle;

    [SerializeField] int hitPoints;
    [SerializeField] int scorePoints;
    [SerializeField] int hitCount;

    public virtual void Start()
    {
        
    }

    public int HitCount
    {
        get { return hitCount; }
    }

    public int HitPoints
    {
        get { return hitPoints; }
    }

    public int ScorePoint
    {
        get { return scorePoints; }
    }


    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        hitPoints--;
        hitCount++;
        Instantiate(hitParticle, this.transform.position, Quaternion.identity);
        if (hitPoints > 0)
        {
            return;
        }
        else
        {
            Death();
        }
    }

    public virtual void Death()
    {
        FindObjectOfType<ScoreManager>().AddScoreToPlayer(scorePoints);
        Destroy(gameObject);
    }
}
