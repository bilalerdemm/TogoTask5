using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class SmoothDamp : MonoBehaviour
{
    public Transform currentLeadTransform;
    private float currentVel = 0.0f;
    private float smoothTime = 0.1f;
    void Update()
    {
        if (currentLeadTransform == null)
        {
            return;
        }
        else
        {
            transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, currentLeadTransform.position.x, 
                ref currentVel, smoothTime),transform.position.y, transform.position.z);
        }
    }

    public void SetLeadTransform(Transform leadTransform)
    {
        currentLeadTransform = leadTransform;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collect"))
        {
            Debug.Log("SmootDamp Trigger");
            PlayerGameController.instance.StackList.Add(collision.gameObject);
            PlayerGameController.instance.score++;
            PlayerGameController.instance.StackList[PlayerGameController.instance.StackList.Count - 1].transform.position += new Vector3(0, 0, PlayerGameController.instance.StackList.Count * .5f);
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            Debug.Log("SmootDamp Trigger");
            PlayerGameController.instance.StackList.Add(other.gameObject);
            PlayerGameController.instance.score++;
            PlayerGameController.instance.StackList[PlayerGameController.instance.StackList.Count - 1].transform.position += new Vector3(0, 0, PlayerGameController.instance.StackList.Count * .5f);
        }
    }
    */
}
