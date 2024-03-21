using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{  
    public FirstPersonLook firstpersonlook;    
    public Check_Points check_points;    
    public JumpVersion2 jumpversion2Script;
    public FirstPersonMovement firstpersonmovementscript;
    [SerializeField] private GameObject FinishObj;    
    [SerializeField] private GameObject Player;
    [SerializeField] public Rigidbody rb;
    [SerializeField] private GameObject Mesh;
    void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player"))
        {
            firstpersonlook.PauseDataSave();
            Cursor.lockState = CursorLockMode.None;
            check_points.Camera.transform.position = firstpersonlook.CameraPosition;
            check_points.Camera.transform.rotation = firstpersonlook.CameraRotation;
            firstpersonmovementscript.enabled = false;
            jumpversion2Script.enabled = false;
            check_points.Camera.SetActive(true);
            firstpersonlook.FPL_Camera.SetActive(false);
            FinishObj.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            Mesh.SetActive(false);
            Debug.Log("Да-да-да-да-да");
        }
    }
}
