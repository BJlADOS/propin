using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebombAbility : Ability
{
    public float DamagePerSecond;
    public float LifeTime;
    private GameObject FirepoolPrefab;
    public override void Use()
    {
        var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0;
        var fire = Instantiate(FirepoolPrefab);
        fire.transform.position = target;
        fire.GetComponent<FirePool>().DamagePerSecond = DamagePerSecond;
        fire.GetComponent<FirePool>().LifeTime = LifeTime;
    }

    private void Awake()
    {
        FirepoolPrefab = Resources.Load<GameObject>("Prefabs/Fire");
    }
}
