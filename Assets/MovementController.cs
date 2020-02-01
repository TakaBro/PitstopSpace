using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    bool hasMoved;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0.0f, 0.1f);
        }else if(Input.GetKeyDown(KeyCode.DownArrow)){
            transform.position += new Vector3(0.0f, -0.1f);
        }

        /*Debug.Log(Input.GetAxis("Vertical"));

        if(Input.GetAxis("Vertical") == 0)
        {
            hasMoved = false;
        }
        else if(Input.GetAxis("Vertical") != 0 && !hasMoved)
        {
            hasMoved = true;

            Move();
        }*/
    }

    // Update is called once per frame
    void Move()
    {
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position += new Vector3(0.0f, -0.1f);
        }else {
            transform.position += new Vector3(0.0f, 0.1f);
        }
    }
}
