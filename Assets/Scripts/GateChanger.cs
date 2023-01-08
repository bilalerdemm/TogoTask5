using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GateChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collected"))
        {
            if (other.gameObject.GetComponent<MeshRenderer>().enabled == false)
            {
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
