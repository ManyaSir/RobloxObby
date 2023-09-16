using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;


public class Death_Ground : MonoBehaviour
{
    // Vector3 StringToVector3(string input)
    // {
    //     string[] values = input.Split(',', '(', ')');
    //     float x = float.Parse(values[1].Trim(), CultureInfo.InvariantCulture.NumberFormat);
    //     float y = float.Parse(values[2].Trim(), CultureInfo.InvariantCulture.NumberFormat);
    //     float z = float.Parse(values[3].Trim(), CultureInfo.InvariantCulture.NumberFormat);
    //     return new Vector3(x, y, z);
    // }
    
    // void OnTriggerEnter(Collider other) 
    // {
    //     if(this.CompareTag("Death_Ground") && other.CompareTag("Player"))
    //     {
    //         GameManager.Latest_Checkpoint_pos = PlayerPrefs.GetString("StringLatest_Checkpoint");  
            
    //         Debug.Log(PlayerPrefs.GetString("StringLatest_Checkpoint"));
            
    //         GameManager.Latest_Checkpoint_ToVector3 = StringToVector3(GameManager.Latest_Checkpoint_pos);  
                
            
    //         Check_Points.Latest_Checkpoint_count.transform.position = GameManager.Latest_Checkpoint_ToVector3;  
                
            
    //         Check_Points.Latest_Checkpoint.transform.position = Check_Points.Latest_Checkpoint_count.transform.position;  
                
            
    //         Check_Points.Player.transform.position = Check_Points.Latest_Checkpoint.transform.position;  
    //         Debug.Log("Success");
    //     }
    // }
}
