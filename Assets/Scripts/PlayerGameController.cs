using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGameController : MonoBehaviour
{
    public List<GameObject> StackList = new List<GameObject>();
    public Transform spawnPoint;
    public bool isCube = true;
    public int score;
    public float moveSpeed;

    public static PlayerGameController instance;
    private void Awake() => instance = this;


    private void Update()
    {
        transform.parent.transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            other.gameObject.transform.parent = transform.parent.GetChild(0).transform;


            Debug.Log(other.gameObject.name);
            //other.gameObject.transform.AddComponent<Rigidbody>();


            StackList.Add(other.gameObject);
            StackList[StackList.Count - 1].transform.position += new Vector3(0, 0, StackList.Count * .5f);
            score++;

            if (StackList.Count == 1)
            {
                StackList[0].gameObject.GetComponent<SmoothDamp>().SetLeadTransform(transform);
            }
            else if (StackList.Count > 1)
            {
                StackList[StackList.Count - 1].gameObject.GetComponent<SmoothDamp>().SetLeadTransform(StackList[(StackList.Count - 2)].transform);
            }

            #region
            /* BENÝM DENEMEM (Sonuca Ulasilamadi)
            score++;
            Cubes.Add(other.gameObject);
            other.gameObject.transform.SetParent(transform);
            spawnPoint.position = new Vector3 (spawnPoint.position.x,spawnPoint.position.y, Cubes[Cubes.Count - 1].transform.position.z);
            //other.gameObject.transform.position = spawnPoint.position + new Vector3(0, 0, 0.5f);
            */
            #endregion
        }
        if (other.gameObject.CompareTag("Gate") && score > 0)
        {
            if (isCube)
            {
                for (int i = 0; i < StackList.Count; i++)
                {
                    StackList[i].gameObject. GetComponent<MeshRenderer>().enabled = false;
                    isCube = false;
                }

            }
            else
            {
                for (int i = 0; i < StackList.Count; i++)
                {
                    StackList[i].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    isCube = true;
                }
            }
        }

        if (other.gameObject.CompareTag("Obstacle") && score > 0)
        {
            score--;
            Debug.Log("Obstacle Girildi");
            Destroy(StackList[StackList.Count - 1].gameObject);
            StackList.RemoveAt(StackList.Count - 1);
            //StartCoroutine(CubeRemover());
        }
    }


    IEnumerator CubeRemover()
    {
        yield return new WaitForSeconds(1f);

    }
    public void AddCubeToList()
    {

    }
}
