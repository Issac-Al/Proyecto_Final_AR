using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject player;
    public Animator playerAnimator;
    int nextAttack = 0;
    private bool objectColliding = false;
    // Start is called before the first frame update
    // Update is called once per frame
    public void Attack()
    {
        if (playerAnimator == null)
            playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        if(!objectColliding)
            if (nextAttack == 0)
            {
                playerAnimator.SetInteger("Attack", 1);
                nextAttack = 1;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().EnableCollider();
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SetAttacking(1);
            }
            else
            {
                playerAnimator.SetInteger("Attack", 2);
                nextAttack = 0;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().EnableCollider();
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SetAttacking(1);

            }
        else
        {
            playerAnimator.SetTrigger("Pick");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SetPicking(1);
            GameObject.FindGameObjectWithTag("Item").GetComponent<Item>().ItemCollected();
        }
    }

    public void SetObjectColliding()
    {
        objectColliding = true;
    }

    public void RemoveObjectColliding()
    {
        objectColliding = false;
    }

}
