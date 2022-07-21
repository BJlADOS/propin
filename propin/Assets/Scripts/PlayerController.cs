using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    //public float PullForce;
    //public float MoveSpeed;
    public AudioSource AttackSound;
    public AudioSource FinalAttackSound;
    public TextMeshProUGUI InteractionPrompt;
    public float MeleeRadius;
    public float MeleeDamage;
    public float MeleeCooldown;
    Rigidbody2D Body;
    Vector2 InputDelta;
    List<Interactive> InteractiveObjectsInRange = new List<Interactive>();
    Inventory Inventory;
    Health Health;
    float MeleeCooldownTimeLeft = 0;
    public static PlayerController Instance
    {
        get;
        private set;
    }
    public void TestDamage()
    {
        Health.TakeDamage(25);
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        Instance = this;
    }

    public void Attack(GameObject enemy)
    {
        if ((enemy.transform.position - transform.position).magnitude <= MeleeRadius)
        {
            if (MeleeCooldownTimeLeft <= 0)
            {

                if (enemy.GetComponent<Health>().TakeDamage(MeleeDamage) <= 0)
                {
                    FinalAttackSound.Play();
                }
                else
                {
                    AttackSound.Play();
                }
                MeleeCooldownTimeLeft = MeleeCooldown;
            }
        }
    }

    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Inventory = GetComponent<Inventory>();
        Health = GetComponent<Health>();
        Health.OnDeath += OnDeath;
        Inventory.Add(Resources.Load<ItemMetaData>("Items/Medkit").CreateItem(2));
        Inventory.Add(Resources.Load<ItemMetaData>("Items/Pistol").CreateItem(1));
    }

    void Update()
    {
        InputDelta.x = Input.GetAxisRaw("Horizontal");
        InputDelta.y = Input.GetAxisRaw("Vertical");
        var closest = GetClosestInteractiveObject();
        if (closest != null)
        {
            InteractionPrompt.text = $"F - {closest.Prompt}";
            if (Input.GetKeyDown(KeyCode.F))
            {
                closest.Interact(gameObject);
            }
        }
        else
        {
            InteractionPrompt.text = "";
        }
        if (MeleeCooldownTimeLeft > 0)
        {
            MeleeCooldownTimeLeft -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<Ability>().Use();
        }
    }

    void FixedUpdate()
    {
        //Body.velocity = InputDelta.normalized * MoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Interactive>(out var interactiveObject))
        {
            InteractiveObjectsInRange.Add(interactiveObject);
            interactiveObject.Approach(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Interactive>(out var interactive))
        {
            for (var i = InteractiveObjectsInRange.Count - 1; i >= 0; i--)
            {
                var obj = InteractiveObjectsInRange[i];
                if (obj.GetInstanceID() == interactive.GetInstanceID())
                {
                    InteractiveObjectsInRange.RemoveAt(i);
                    obj.Leave(gameObject);
                    break;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.tag == "Draggable")
        //{
        //    if (Input.GetKey(KeyCode.Space))
        //    {
        //        var direction = transform.position - collision.transform.position;
        //        direction.Normalize();
        //        collision.attachedRigidbody.AddForce(direction * PullForce * Time.deltaTime);
        //    }
        //}
    }

    private Interactive GetClosestInteractiveObject()
    {
        var min = float.MaxValue;
        Interactive closestObject = null;
        foreach (var obj in InteractiveObjectsInRange)
        {
            var distance = Vector3.Distance(obj.transform.position, transform.position);
            if (distance < min)
            {
                min = distance;
                closestObject = obj;
            }
        }
        return closestObject;
    }
}
