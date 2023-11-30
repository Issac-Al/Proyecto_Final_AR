using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField]
    private int currentHP;
    public int totalHP;
    private Animator enemyAnimator;
    private bool chasing = false;
    public float speed;
    private Transform playerTransform;
    public float stoppingDistance;
    private GameObject player;
    public List<Collider> weaponCollider;
    public float attackCD;
    private float timer = 0;
    public float dmgCD = 0.35f;
    private float dmgTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = totalHP;
        enemyAnimator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (chasing && Mathf.Abs(Vector3.Distance(playerTransform.position, transform.position)) > stoppingDistance)
        {
            Debug.Log("Persiguiendo");
            enemyAnimator.SetBool("Chasing", true);
            enemyAnimator.SetBool("Attacking", false);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, step);
            transform.LookAt(playerTransform);
        }
        else
        {
            if (Mathf.Abs(Vector3.Distance(playerTransform.position, transform.position)) <= stoppingDistance && timer < Time.time)
            {
                Debug.Log("Atacando");
                enemyAnimator.SetBool("Chasing", false);
                enemyAnimator.SetBool("Attacking", true);
                timer = Time.time + attackCD;
                foreach (Collider weapon in weaponCollider)
                {
                    weapon.enabled = true;
                }
                transform.LookAt(playerTransform);
                Debug.Log("Primer timer" + timer);
                Debug.Log("Primer tiempo" + Time.time);
            }
        }

        Death();
         
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entre al trigger");
        if(other.gameObject.tag == ("Player"))
        {
            chasing = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Enemy"))
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }

    public void GetHurt(int damage)
    {
        if (dmgTimer < Time.time)
        {
            currentHP -= damage;
            dmgTimer = Time.time + dmgCD;
        }
    }

    private void Death()
    {
        if (currentHP <= 0)
        {
            enemyAnimator.SetBool("Alive", false);
            this.enabled = false;
        }
    }

    public void DisableColliders()
    {
        foreach(Collider weapon in weaponCollider)
        {
            weapon.enabled = false;
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void SetTimer()
    {
        timer = Time.time + attackCD;
        enemyAnimator.SetBool("Chasing", false);
        enemyAnimator.SetBool("Attacking", false);
        transform.LookAt(playerTransform);
    }

}
