using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity;
    public Joystick joystick;
    public Animator playerAnimator;
    private float currentVelocity;
    private float smoothTime = 0.05f;
    public Rigidbody playerRb;
    public int currentHP, currentStamina;
    public int totalHP, totalStamina; 
    public Collider weaponCollider;
    private bool isDefending = false, isAttacking = false, isPicking = false;
    private float dmgCD = 0.6f, dmgTimer;
    private GameObject newLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = totalHP;
        currentStamina = totalStamina;
        joystick = GameObject.FindGameObjectWithTag("GameController").GetComponent<Joystick>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        if(isDefending)
        {
            currentStamina--;
        }
        else
        {
            if (currentStamina < totalStamina)
                currentStamina++;
        }
    }

    private void FixedUpdate()
    {
            Movement();
    }
    private void Movement()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        Vector3 movementVector = new Vector3(horizontal, transform.position.y, vertical);
        float targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
        if (currentHP > 0 && !isDefending && !isAttacking && !isPicking)
        {
            playerRb.MovePosition(transform.position + movementVector * velocity * Time.deltaTime);
            if (horizontal == 0 && vertical == 0)
            {
                playerAnimator.SetBool("Running", false);
            }
            else
            {
                playerAnimator.SetBool("Running", true);
                transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
            }
            movementVector = Vector3.zero;
        }
    }

    public void AttackReset()
    {
        playerAnimator.SetInteger("Attack", 0);
    }

    public void DisableCollider()
    {
        weaponCollider.enabled = false;
    }

    public void EnableCollider()
    {
        weaponCollider.enabled = true;
    }

    public void GetHurt(int damage)
    {
        if(!isDefending && dmgTimer < Time.time)
        {
            currentHP -= damage;
            dmgTimer = Time.time + dmgCD;
        }
    }

    private void Death()
    {
        if (currentHP <= 0)
        {
            playerAnimator.SetTrigger("Dead");
            newLevel.SetActive(true);
            this.enabled = false;
        }
        
    }
    
    public int ReturnHP()
    {
        return currentHP;
    }

    public int ReturnStamina()
    {
        return currentStamina;
    }

    public void SetDefending(bool state)
    {
        isDefending = state;
    }

    public void Recover(string type, int amount)
    {
        if(type == "HP")
        {
            currentHP += amount;
        }
        else
        {
            currentStamina += amount;
        }
    }

    public void SetAttacking(int state)
    {
        if (state == 0)
            isAttacking = false;
        else
            isAttacking = true;
    }

    public void SetPicking(int state)
    {
        if (state == 0)
            isAttacking = false;
        else
            isAttacking = true;
    }

}
