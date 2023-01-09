using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGameController : MonoBehaviour
{
    public Animator playerAnim;
    public bool start = false;

    public List<GameObject> StackList = new List<GameObject>();
    public Transform spawnPoint;
    public bool isCube = true;
    public int score;
    public float moveSpeed;
    public Transform parent;
    public bool IsStop = false;
    public GameObject finish;
    public static PlayerGameController instance;
    private void Awake() => instance = this;


    private void Start()
    {
        InvokeRepeating("StackListUpdate", .05f, .05f);
    }

    private void Update()
    {
        if (!IsStop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                start = true;
            }
            if (start == true)
            {
                playerAnim.SetBool("isRunning", true);
                transform.parent.transform.position += Vector3.forward * Time.deltaTime * moveSpeed;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            AddCubeToList(other);
            score++;
            #region
            /* 
            //other.gameObject.transform.parent = transform.parent.GetChild(0).transform;
            
            //Debug.Log(other.gameObject.name);
           
            //StackList.Add(other.gameObject);
            //StackList[StackList.Count - 1].transform.position += new Vector3(0, 0, StackList.Count * .5f);
            

            //if (StackList.Count == 1)
            //{
            //    StackList[0].gameObject.GetComponent<SmoothDamp>().SetLeadTransform(transform);
            //}
            //else if (StackList.Count > 1)
            //{
            //    StackList[StackList.Count - 1].gameObject.GetComponent<SmoothDamp>().SetLeadTransform(StackList[(StackList.Count - 2)].transform);
            //}
             * 
             * BENÝM DENEMEM (Sonuca Ulasilamadi)
            score++;
            Cubes.Add(other.gameObject);
            other.gameObject.transform.SetParent(transform);
            spawnPoint.position = new Vector3 (spawnPoint.position.x,spawnPoint.position.y, Cubes[Cubes.Count - 1].transform.position.z);
            //other.gameObject.transform.position = spawnPoint.position + new Vector3(0, 0, 0.5f);

                    //if (other.gameObject.CompareTag("Obstacle") && score > 0)
        //{
        //    score--;
        //    Debug.Log("Obstacle Girildi");
        //    Destroy(StackList[StackList.Count - 1].gameObject);
        //    StackList.RemoveAt(StackList.Count - 1);
        //}
            */
            #endregion
        }

    }

    void StackListUpdate()
    {
        if (StackList.Count>0)
        {
            for (int i = 0; i < StackList.Count; i++)
            {
                if (i == 0)
                {
                    StackList[i].gameObject.GetComponent<SmoothDamp>().SetLeadTransform(transform);
                    StackList[i].gameObject.transform.position = transform.position + new Vector3(0, 0, 0.5f);
                    StackList[i].gameObject.transform.position = new Vector3(StackList[i].gameObject.transform.position.x,
                                                                             StackList[i].gameObject.transform.position.y + .28f,
                                                                             transform.position.z + 0.5f);
                }
                else
                {
                    StackList[i].gameObject.GetComponent<SmoothDamp>().SetLeadTransform(StackList[i - 1].transform);
                    StackList[i].gameObject.transform.position = new Vector3(StackList[i].gameObject.transform.position.x,
                                                                             StackList[i].gameObject.transform.position.y,
                                                                             StackList[i - 1].transform.position.z + 0.5f);

                }
            }
        }
       

    }

    public void AddCubeToList(Collider other)
    {
        #region
        /*
        other.gameObject.transform.parent = transform.parent.GetChild(0).transform;
        Debug.Log(other.gameObject.name);
        StackList.Add(other.gameObject);
        StackList[StackList.Count - 1].transform.position += new Vector3(0, 0, StackList.Count * .5f);
        */
        #endregion

        other.transform.parent = parent;
        StackList.Add(other.gameObject);
        other.tag = "Collected";
        StackList[StackList.Count - 1].gameObject.AddComponent<CollectableTrger>();



        //if (StackList.Count == 1)
        //{
        //    StackList[0].gameObject.GetComponent<SmoothDamp>().SetLeadTransform(transform);
        //    StackList[StackList.Count - 1].transform.position += new Vector3(0, 0, .5f);
        //}
        //else if (StackList.Count > 1)
        //{
        //    StackList[StackList.Count - 1].gameObject.GetComponent<SmoothDamp>().SetLeadTransform(StackList[(StackList.Count - 2)].transform);
        //    StackList[StackList.Count - 1].transform.position = StackList[StackList.Count - 2].transform.position + new Vector3(0, 0, .5f);
        //}

    }
}
