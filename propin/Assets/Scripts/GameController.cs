using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject TopPanel;
    public HealthBar EnemyHealthBar;
    public TextMeshProUGUI EnemyNameText;
    private PlayerController Player;
    public static GameController Instance
    {
        get;
        private set;
    }

    public void EnemyHover(GameObject enemy)
    {
        TopPanel.SetActive(true);
        EnemyHealthBar.Source = enemy.GetComponent<Health>();
        EnemyNameText.text = enemy.name;
    }

    public void EnemyRightClick(GameObject enemy)
    {
        Player.Attack(enemy);
    }

    private void Start()
    {
        Instance = this;
        Player = PlayerController.Instance;
    }

    private void Update()
    {
        if (EnemyHealthBar.Source == null)
        {
            TopPanel.SetActive(false);
        }
    }
}
