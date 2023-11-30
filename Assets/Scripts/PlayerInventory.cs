using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Dictionary<string, int> items = new Dictionary<string, int>()
    {
        {"HP", 0},
        {"Stamina", 0}
    };

    public void AddObject(string name)
    {
        items[name]++;
    }

    public void UsePotion(string type)
    {
        Debug.Log(items[type]);
        if(type == "HP" && ReturnPotionHP() > 0)
        {
            gameObject.GetComponent<PlayerMovement>().Recover("HP", 20);
            items[type]--;
            Debug.Log(items[type]);
        }
        else
        {
            if (type == "Stamina" && items[type] > 0)
            { 
                gameObject.GetComponent<PlayerMovement>().Recover("Stamina", 15);
                items[type]--;
                Debug.Log(items[type]);
            }
        }
    }

    public int ReturnPotionHP()
    {
        return items["HP"];
    }

    public int ReturnPotionStamina()
    {
        return items["Stamina"];
    }

    // Start is called before the first frame updat
    
}
