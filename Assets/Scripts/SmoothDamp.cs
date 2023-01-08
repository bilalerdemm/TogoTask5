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
    
}
