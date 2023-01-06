using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameController : MonoBehaviour
{
    public List<GameObject> Moneys;
    public Transform spawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            Moneys.Add(other.gameObject);
            other.gameObject.transform.SetParent(transform);
            other.gameObject.transform.position = spawnPoint.position + new Vector3(0, 0, 1) * Moneys.Count; 
        }
    }
}
