using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame after FixedUpdate (Update -> FixedUpdate -> LateUpdate)
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        // get difference position between lookAt (object) and camera
        float deltaX = lookAt.position.x - transform.position.x;
        // this is to check if we're inside the bounds on the X axis
        if (deltaX > boundX || deltaX < -boundX)
        {
            // check if object on the right / left
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        // get difference position between lookAt (object) and camera
        float deltaY = lookAt.position.y - transform.position.y;
        // this is to check if we're inside the bounds on the Y axis
        if (deltaY > boundY || deltaY < -boundY)
        {
            // check if object on the right / left
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
