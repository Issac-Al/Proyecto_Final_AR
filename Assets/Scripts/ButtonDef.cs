using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyButton : Button
{
    private Animator playerAnimator;
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (playerAnimator == null)
            playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().ReturnStamina() > 0)
        {
            playerAnimator.SetBool("Blocking", true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SetDefending(true);
        }
        else
            playerAnimator.SetBool("Blocking", false);
        //show text
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        if (playerAnimator == null)
            playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerAnimator.SetBool("Blocking", false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SetDefending(false);
        //hide text
    }
}