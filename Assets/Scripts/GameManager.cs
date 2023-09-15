using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector3 Latest_Checkpoint_value;
    public static bool isStartGame = true;

    void Update()
    {
        if(Check_Points.isChanged == true)
        {
            //Latest_Checkpoint_value.transform.position = Check_Points.Latest_Checkpoint.transform.position;
            Latest_Checkpoint_value = Check_Points.Latest_Checkpoint.transform.position;
        }
    }
}