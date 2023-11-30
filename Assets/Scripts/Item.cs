using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private bool collected = false;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerAttack>().SetObjectColliding();
        if (collected)
        {
            if (gameObject.name == "LifePotion(Clone)")
                other.GetComponent<PlayerInventory>().AddObject("HP");
            else
                other.GetComponent<PlayerInventory>().AddObject("Stamina");
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerAttack>().RemoveObjectColliding();
            Destroy(gameObject);
        }
        Debug.Log(gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerAttack>().RemoveObjectColliding();
        //Debug.Log("Exit_On_Trigg");
    }

    public void ItemCollected()
    {
        collected = true;
    }
}
