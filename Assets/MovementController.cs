using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    bool hasMoved;
    public string upKeyStr;
    public string donwKeyStr;
    public float upDist = 0.1f;
    public float downDist = -0.1f;

    // Update is called once per frame
    void Update()
    {
         Move();
    }

    // Update is called once per frame
    void Move()
    {      
        if (Input.GetKeyDown(upKeyStr))
        {
            transform.position += new Vector3(0.0f, upDist);
        }else if(Input.GetKeyDown(donwKeyStr)){
            transform.position += new Vector3(0.0f, downDist);
        }
    }
}
