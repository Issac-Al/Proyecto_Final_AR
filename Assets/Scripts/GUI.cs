using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUI : MonoBehaviour
{
    public Slider HPBar, StaminaBar;
    private int currentHP, currentStamina;
    private int totalHP = 120, totalStamina = 1400;
    private GameObject player;
    public int HpPotions, StaminaPotions;
    public TMP_Text textHP, textStam;
    public GameObject button;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            HPBar.value = totalHP;
        }
        else
        {
            currentHP = player.GetComponent<PlayerMovement>().ReturnHP();
            currentStamina = player.GetComponent<PlayerMovement>().ReturnStamina();
            HPBar.value = ((float)currentHP / (float)totalHP);
            StaminaBar.value = ((float)currentStamina / (float)totalStamina);
            textHP.text = "HP POTION X" + player.GetComponent<PlayerInventory>().ReturnPotionHP().ToString();
            textStam.text = "STAMINA POTION X" + player.GetComponent<PlayerInventory>().ReturnPotionStamina().ToString();
            //Debug.Log("HPBar: " + (float)currentHP);
            //Debug.Log("TOTAL HP: " + (float)totalHP);
        }
        
    }

    public void Show_HideExitButton(bool state)
    {
        button.SetActive(state);
    }

}
