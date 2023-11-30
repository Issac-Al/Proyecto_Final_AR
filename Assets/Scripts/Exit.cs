using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject GUI;
    private void Start()
    {
        GUI = GameObject.FindGameObjectWithTag("GUI");
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (GUI != null)
            {
                GUI = GameObject.FindGameObjectWithTag("GUI");
                GUI.GetComponent<GUI>().Show_HideExitButton(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GUI != null)
            {
                GUI = GameObject.FindGameObjectWithTag("GUI");
                GUI.GetComponent<GUI>().Show_HideExitButton(false);
            }
        }
    }
}
