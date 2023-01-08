using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ObstacleManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collected"))
        {
            PlayerGameController.instance.score--;
            Debug.Log("Obstacle Girildi");
            Destroy(PlayerGameController.instance.StackList[PlayerGameController.instance.StackList.Count - 1].gameObject);
            PlayerGameController.instance.StackList.RemoveAt(PlayerGameController.instance.StackList.Count - 1);
        }
    }
}
