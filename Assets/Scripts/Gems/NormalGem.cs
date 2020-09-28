using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGem : Gem
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    public override void Death()
    {
        base.Death();
        FindObjectOfType<StageManager>().NormalGemsInLevel--;
    }
}
