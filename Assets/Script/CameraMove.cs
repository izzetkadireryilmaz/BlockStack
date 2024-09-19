using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{  
    // Update is called once per frame
    void Update()
    {
        if (!ScoreGame.text.gameObject.activeSelf)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y + 0.0003f,transform.position.z);
        }
        
    }
}
