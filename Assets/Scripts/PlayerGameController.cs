using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameController : MonoBehaviour
{
    public List<GameObject> Cubes = new List<GameObject>();
    public Transform spawnPoint;
    public bool isCube = true;
    public int score;

    public static PlayerGameController instance;
    private void Awake() => instance = this;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            score++;
            Cubes.Add(other.gameObject);
            other.gameObject.transform.SetParent(transform);
            spawnPoint.position = new Vector3 (spawnPoint.position.x,spawnPoint.position.y, Cubes[Cubes.Count - 1].transform.position.z);
            //other.gameObject.transform.position = spawnPoint.position + new Vector3(0, 0, 0.5f);
        }
        if (other.gameObject.CompareTag("Gate") && score > 0)
        {
            if (isCube)
            {
                for (int i = 0; i < Cubes.Count; i++)
                {
                    Cubes[i].gameObject. GetComponent<MeshRenderer>().enabled = false;
                    isCube = false;
                }

            }
            else
            {
                for (int i = 0; i < Cubes.Count; i++)
                {
                    Cubes[i].gameObject.GetComponent<MeshRenderer>().enabled = true;
                    isCube = true;
                }
            }
        }

        if (other.gameObject.CompareTag("Obstacle") && score > 0)
        {
            score--;
            Debug.Log("Obstacle Girildi");
            Destroy(Cubes[Cubes.Count - 1].gameObject);
            Cubes.RemoveAt(Cubes.Count - 1);
            //StartCoroutine(CubeRemover());
        }
    }


    IEnumerator CubeRemover()
    {
        yield return new WaitForSeconds(1f);

    }
}
