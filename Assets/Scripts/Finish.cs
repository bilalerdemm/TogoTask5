using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    public int score;
    public GameObject ýnputPanel, confetti;
    public Transform finalCubeSpawn;
    public GameObject cineCam;

    [SerializeField] private Vector3[] angles;
    [SerializeField] [Range(0f,10f)] private float lerpTime;
    [SerializeField] private float time;
    private float currentTime;
    private int angleIndex;

    public TextMeshProUGUI scoreText;
    public Animator textAnimator;
    public GameObject textObject;

    public GameObject winPanel;
    private void Update()
    {
        if (transform.childCount > 10)
        {
            cineCam.transform.rotation = Quaternion.Slerp(cineCam.transform.rotation, Quaternion.Euler(angles[angleIndex]), lerpTime * Time.deltaTime);
        }

        if (currentTime <= 0)
        {
            currentTime = time;
            angleIndex++;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
        if (angleIndex >= angles.Length)
        {
            angleIndex = 0;
        }
        if (transform.childCount > 3)
        {
            
            textObject.gameObject.SetActive(true);
            scoreText.text = "Score:" + score;
            textAnimator.SetBool("isBounce", true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            score += score;

            Debug.Log("aaa");
            confetti.SetActive(true);

            ýnputPanel.SetActive(false);
            PlayerGameController.instance.IsStop = true;
            PlayerGameController.instance.start = false;
            PlayerGameController.instance.playerAnim.SetBool("isRunning", false);

            winPanel.SetActive(true);
        }
        if (other.gameObject.CompareTag("Collected") && other.gameObject.GetComponent<MeshRenderer>().enabled == true)
        {
            Debug.Log("Finishe cube geldi");
            score += 5;
            //StartCoroutine(CubeScore());
            PlayerGameController.instance.StackList.Remove(other.gameObject);
            Destroy(other.gameObject.GetComponent<SmoothDamp>());
            other.gameObject.transform.parent = transform;
            other.gameObject.transform.position = finalCubeSpawn.position;
            finalCubeSpawn.transform.position = new Vector3(finalCubeSpawn.transform.position.x, finalCubeSpawn.transform.position.y +.5f, finalCubeSpawn.transform.position.z);

        }
        else if (other.gameObject.CompareTag("Collected") && other.gameObject.GetComponent<MeshRenderer>().enabled == false)
        {
            Debug.Log("Finishe sphire geldi");
            score += 10;
            //StartCoroutine(SphireScore());
            PlayerGameController.instance.StackList.Remove(other.gameObject);
            Destroy(other.gameObject.GetComponent<SmoothDamp>());
            other.gameObject.transform.parent = transform;
            other.gameObject.transform.position = finalCubeSpawn.position;
            finalCubeSpawn.transform.position = new Vector3(finalCubeSpawn.transform.position.x, finalCubeSpawn.transform.position.y + .5f, finalCubeSpawn.transform.position.z);

        }
    }
    IEnumerator CubeScore(){
        yield return new WaitForSeconds(3);
        score += 5;
    }
    IEnumerator SphireScore()
    {
        yield return new WaitForSeconds(3);
        score += 10;
    }
}
