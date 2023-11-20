using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    private bool IsDown = true;

    

    void Update()
    {
        if(IsDown)
        {
            this.transform.position -= new Vector3(0, speed, 0);
            if(this.transform.position.y <= 1f)
            {
                IsDown = false;
                Debug.Log("всёвсёсвсёвсвёвсвпфвып" + this.transform.position.y);
            }
        } else if (!IsDown)
        {
            this.transform.position += new Vector3(0, speed, 0);
            if(this.transform.position.y >= 4.478f)
            {
                IsDown = true;
                Debug.Log("всёвсёсвсёвсвёвсвпфвып" + this.transform.position.y);
            }
        }
        
    }
}

