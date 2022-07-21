using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public IsometricCharacterRenderer IsometricRenderer;
    public AIPath AiPath;
    public float AttackCooldown;
    public float AttackRange;
    public float AttackDamage;
    private float AttackCooldownTimeLeft = 0;
    private PlayerController Player;
    public void OnDeath()
    {
        var animator = IsometricRenderer.GetComponent<Animator>();
        AiPath.enabled = false;
        enabled = false;
        animator.Play("Death");
        Destroy(gameObject, 1.2f);
    }

    private void Awake()
    {
        IsometricRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        AiPath = GetComponent<AIPath>();
    }

    void Start()
    {
        Player = PlayerController.Instance;
        GetComponent<Health>().OnDeath += OnDeath;
        var clickable = GetComponent<Clickable>();
        clickable.RightClick.AddListener(GameController.Instance.EnemyRightClick);
        clickable.Enter.AddListener(GameController.Instance.EnemyHover);
    }

    void Update()
    {
        var path = new List<Vector3>();
        AiPath.GetRemainingPath(path, out var stale);
        var direction = (PlayerController.Instance.transform.position - transform.position);
        if (path.Count > 1)
        {
            var next = path[1];
            direction = (next - transform.position);
        }
        IsometricRenderer.SetDirection(direction);
        if (AttackCooldownTimeLeft <= 0)
        {
            if ((Player.transform.position - transform.position).magnitude < AttackRange)
            {
                Player.GetComponent<Health>().TakeDamage(AttackDamage);
                AttackCooldownTimeLeft = AttackCooldown;
            }
        }
        else
        {
            AttackCooldownTimeLeft -= Time.deltaTime;
        }
    }
}
