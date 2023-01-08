using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableTrger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            other.gameObject.transform.parent = PlayerGameController.instance.parent;
            PlayerGameController.instance.StackList.Add(other.gameObject);
            //PlayerGameController.instance.StackList[PlayerGameController.instance.StackList.Count - 1].transform.position += new Vector3(0, 0, PlayerGameController.instance.StackList.Count * .5f);
            other.gameObject.tag = "Collected";
            PlayerGameController.instance.StackList[PlayerGameController.instance.StackList.Count - 1].AddComponent<CollectableTrger>();

            //if (PlayerGameController.instance.StackList.Count == 1)
            //{
            //    PlayerGameController.instance.StackList[0].GetComponent<SmoothDamp>().SetLeadTransform(transform);
            //}
            //else
            //{
            //    PlayerGameController.instance.StackList[0].GetComponent<SmoothDamp>().SetLeadTransform(PlayerGameController.instance.StackList[PlayerGameController.instance.StackList.Count - 2].transform);
            //}
        }
    }
}
