using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{  
    public MoveBehaviour movebehaviour;   
    public Check_Points check_points;    
    public ThirdPersonOrbitCamBasic thirdpersonorbitcambasic; 
    [SerializeField] public GameObject FinishObj;    
    [SerializeField] private GameObject Player;
    [SerializeField] public Rigidbody rb;
    [SerializeField] public GameObject Mesh;
    [SerializeField] public GameObject DanceMan1;
    [SerializeField] public GameObject DanceMan2;
    void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player"))
        {
            thirdpersonorbitcambasic.PauseDataSave();
            Cursor.lockState = CursorLockMode.None;
            check_points.Camera.transform.position = thirdpersonorbitcambasic.CameraPosition;
            check_points.Camera.transform.rotation = thirdpersonorbitcambasic.CameraRotation;
            movebehaviour.enabled = false;
            check_points.Camera.SetActive(true);
            thirdpersonorbitcambasic.FPL_Camera.SetActive(false);
            FinishObj.SetActive(true);
            DanceMan1.SetActive(true);
            DanceMan2.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            Mesh.SetActive(false);
            Debug.Log("Да-да-да-да-да");
        }
    }
}
