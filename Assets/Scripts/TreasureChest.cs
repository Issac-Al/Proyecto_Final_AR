using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public List<GameObject> loot;
    public Transform imageTarget;
    public bool looted = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !looted)
        {
            Instantiate(loot[Random.Range(0, loot.Count)], transform.position, Quaternion.identity, transform);
            looted = true;
        }
    }
}
