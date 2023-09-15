using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Transform Latest_Checkpoint_value;

    void Update()
    {
        Latest_Checkpoint_value.Transform = Checkpoints.Latest_Checkpoint.Transform;
    }
}
