using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode jump;
    [SerializeField] KeyCode restart;
    [SerializeField] KeyCode previous;
    [SerializeField] KeyCode next;
    [SerializeField] Vector3 MoveVector1;
    [SerializeField] Vector3 MoveVector2;
    private void FixedUpdate()
    {   if (Input.GetKey(up)){GetComponent<Rigidbody>().velocity += MoveVector1;}
        if (Input.GetKey(down)){GetComponent<Rigidbody>().velocity -= MoveVector1;}
        if (Input.GetKey(right)){GetComponent<Rigidbody>().velocity += MoveVector2;}
        if (Input.GetKey(left)){GetComponent<Rigidbody>().velocity -= MoveVector2;}
    //  if(Input.GetKey(jump)){GetComponent<Rigidbody>().velocity += MoveVectorJump;}
    //     if (Input.GetKey(restart)){SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);}
    //     if (Input.GetKey(previous)){SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);}
    //     if (Input.GetKey(next)){SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);}
    // }
    // void OnTriggerEnter(Collider other){
    //     if(this.CompareTag("Player") && other.CompareTag("Finish")){
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //     if (Input.GetKey(previous)){SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);}
    //     if (Input.GetKey(next)){SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);}
    //     }
    }
}
