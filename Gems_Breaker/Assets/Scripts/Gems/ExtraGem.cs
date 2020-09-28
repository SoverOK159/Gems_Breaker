using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraGem : Gem
{
    [SerializeField] GameObject targetParticle;

    [SerializeField] Sprite[] gemSkin;

    public override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Target Particle") == null)
        {
            InstantiateTargetParticle();
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        gameObject.GetComponent<SpriteRenderer>().sprite = gemSkin[HitPoints];
    }

    private void InstantiateTargetParticle()
    {       
        GameObject targetPart = Instantiate(targetParticle, gameObject.transform.position, Quaternion.identity) as GameObject;
    }

    public override void Death()
    {
        base.Death();
        FindObjectOfType<StageManager>().ExtraGemsInLevel--;
    }

}
