using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public void OnDeath()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Health>().OnDeath += OnDeath;
        var clickable = GetComponent<Clickable>();
        clickable.RightClick.AddListener(GameController.Instance.EnemyRightClick);
        clickable.Enter.AddListener(GameController.Instance.EnemyHover);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
