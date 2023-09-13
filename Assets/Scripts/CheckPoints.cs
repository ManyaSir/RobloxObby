using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoints : MonoBehaviour
{
    // int IsDeath = 0;
    // int Checkpoint_value = 0;
    // int IsLaunch = 0;
    // int Lvl_progress = 0;
    // [SerializeField] Transform Player_tr;
    // [SerializeField] Rigidbody Player_Rg;
    // public GameObject Player;
    // public GameObject Spawn;
    // public GameObject Checkpoint_1;
    // public GameObject Checkpoint_2;
    // public GameObject Checkpoint_3;
    // public GameObject Checkpoint_4;
    // public GameObject Checkpoint_5;
    // public GameObject Checkpoint_6;
    // public GameObject Checkpoint_7;
    // public GameObject Checkpoint_8;
    // public GameObject Checkpoint_9;
    // public GameObject Checkpoint_10;
    // public GameObject Checkpoint_11;
    // public GameObject Checkpoint_12;
    // public GameObject Checkpoint_13;
    // public GameObject Checkpoint_14;
    // public GameObject Checkpoint_15;
    // public GameObject Checkpoint_16;
    // public GameObject Checkpoint_17;
    // public GameObject Checkpoint_18;
    // public GameObject Checkpoint_19;
    // public GameObject Checkpoint_20;
    // public GameObject Checkpoint_21;
    // public GameObject Checkpoint_22;
    // public GameObject Checkpoint_23;
    // public GameObject Checkpoint_24;
    // public GameObject Checkpoint_25;
    // public GameObject Checkpoint_26;
    // public GameObject Checkpoint_27;
    // public GameObject Checkpoint_28;
    // public GameObject Checkpoint_29;
    // public GameObject Checkpoint_30;
    // public GameObject Latest_Checkpoint_obj;
    // int Latest_Checkpoint;

    
    // void OnTriggerEnter(Collider other)
    // {
    //     if(this.CompareTag("Death_Ground") && other.CompareTag("Player"))
    //     {
    //         IsDeath = 1;
    //         PlayerPrefs.SetInt("saved value checkpoint", 1);
    //         PlayerPrefs.SetInt("IsLaunch", 1);
    //         PlayerPrefs.Save();
    //         Debug.Log("Susess!" + Checkpoint_value);
    //         SceneManager.LoadScene("Game");
    //     }
    //     if(this.CompareTag("CheckPoint1") && other.CompareTag("Player"))
    //     {
    //         PlayerPrefs.SetInt("Latest Checkpoint", 1);
    //         PlayerPrefs.SetInt("Lvl_Progress", 1);
    //         PlayerPrefs.Save();
    //         Lvl_progress = PlayerPrefs.GetInt("Lvl_Progress");
    //     }
    //     if(this.CompareTag("CheckPoint2") && other.CompareTag("Player"))
    //     {
    //         PlayerPrefs.SetInt("Latest Checkpoint", 2);
    //         PlayerPrefs.SetInt("Lvl_Progress", 2);
    //         PlayerPrefs.Save();
    //         Lvl_progress = PlayerPrefs.GetInt("Lvl_Progress");
    //     }
    //     if(this.CompareTag("CheckPoint3") && other.CompareTag("Player"))
    //     {
    //         PlayerPrefs.SetInt("Latest Checkpoint", 3);
    //         PlayerPrefs.Save();
    //         PlayerPrefs.SetInt("Lvl_Progress", 3);
    //         Lvl_progress = PlayerPrefs.GetInt("Lvl_Progress");

    //     }
    //     if(this.CompareTag("CheckPoint4") && other.CompareTag("Player"))
    //     {
    //         PlayerPrefs.SetInt("Latest Checkpoint", 4);
    //         PlayerPrefs.SetInt("Lvl_Progress", 4);
    //         PlayerPrefs.Save();
    //         Lvl_progress = PlayerPrefs.GetInt("Lvl_Progress");
    //     }
    //     if(this.CompareTag("CheckPoint5") && other.CompareTag("Player"))
    //     {
    //         PlayerPrefs.SetInt("Latest Checkpoint", 5);
    //         PlayerPrefs.SetInt("Lvl_Progress", 5);
    //         PlayerPrefs.Save();
    //         Lvl_progress = PlayerPrefs.GetInt("Lvl_Progress");
    //     }
    // }

    // void Start()
    // {
    //     if (PlayerPrefs.GetInt("Lvl_Progress") == 0)
    //     {
    //         Lvl_progress = 0;
    //     } else
    //     {
    //         Lvl_progress = PlayerPrefs.GetInt("Lvl_Progress");
    //     }
    //     IsDeath = 0;
    //     Debug.Log("Current lvl - " + PlayerPrefs.GetInt("Lvl_Progress"));   
    //     IsLaunch = PlayerPrefs.GetInt("IsLaunch");
    //     if (IsLaunch == 1)
    //     {
    //         Checkpoint_value = PlayerPrefs.GetInt("saved value checkpoint"); 
    //     } else
    //     {
    //         PlayerPrefs.SetInt("saved value checkpoint", 0);
    //         PlayerPrefs.Save();
    //         Checkpoint_value = PlayerPrefs.GetInt("saved value checkpoint"); 
    //     }

    // }

    // void Update()
    // {
    //     if (Checkpoint_value == 1 && IsDeath == 0)
    //     {
    //         Latest_Checkpoint = PlayerPrefs.GetInt("Latest Checkpoint");
    //         if (Latest_Checkpoint == 1)
    //         {
    //             Latest_Checkpoint_obj.transform.position = Checkpoint_1.transform.position;
    //             Player.transform.position = Latest_Checkpoint_obj.transform.position;
    //             Checkpoint_value = 0;

    //         }
    //         else if (Latest_Checkpoint == 2)
    //         {
    //             Latest_Checkpoint_obj.transform.position = Checkpoint_2.transform.position;
    //             Player.transform.position = Latest_Checkpoint_obj.transform.position;
    //             Checkpoint_value = 0;
    //         }
    //         else if (Latest_Checkpoint == 3)
    //         {
    //             Latest_Checkpoint_obj.transform.position = Checkpoint_3.transform.position;
    //             Player.transform.position = Latest_Checkpoint_obj.transform.position;
    //             Checkpoint_value = 0;
    //         }
    //         else if (Latest_Checkpoint == 4)
    //         {
    //             Latest_Checkpoint_obj.transform.position = Checkpoint_4.transform.position;
    //             Player.transform.position = Latest_Checkpoint_obj.transform.position;
    //             Checkpoint_value = 0;
    //         }
    //         else if (Latest_Checkpoint == 5)
    //         {
    //             Latest_Checkpoint_obj.transform.position = Checkpoint_5.transform.position;
    //             Player.transform.position = Latest_Checkpoint_obj.transform.position;
    //             Checkpoint_value = 0;
    //         }
    //         else
    //         {
    //             Latest_Checkpoint_obj.transform.position = Spawn.transform.position;
    //             Player.transform.position = Latest_Checkpoint_obj.transform.position;
    //             Checkpoint_value = 0;
    //         }
    //     }
    // }
    
}
