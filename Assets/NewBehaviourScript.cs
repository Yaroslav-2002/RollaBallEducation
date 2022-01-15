using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float dirz;
    public float speed = 3f;

    bool moveingRight = true;
    

    // Update is called once per frame
    void Update()
    {
       if(transform.position.z < 30f)
        {
            moveingRight = false;

        }
        else if(transform.position.z > 40f)
        {
            moveingRight = true;

        }

        if (moveingRight)
        {
            transform.position = new Vector3(0, 5, transform.position.z - speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(0, 5, transform.position.z + speed * Time.deltaTime);
        }
    }


}
