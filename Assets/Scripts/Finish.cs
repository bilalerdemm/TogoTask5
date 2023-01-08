using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collected") && other.gameObject.GetComponent<MeshRenderer>().enabled == true)
        {
            Debug.Log("Finishe cube geldi");
        }
        else if (other.gameObject.CompareTag("Collected") && other.gameObject.GetComponent<MeshRenderer>().enabled == false)
        {
            Debug.Log("Finishe sphire geldi");
        }
    }
}
