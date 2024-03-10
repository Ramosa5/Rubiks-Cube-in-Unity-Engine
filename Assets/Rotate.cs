using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public GameObject RotatingObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            RotatingObject.transform.Rotate(0, 0, -1, Space.World);
        }

        if (Input.GetKey("down"))
        {
            RotatingObject.transform.Rotate(0, 0, 1, Space.World);
        }

        if (Input.GetKey("right"))
        {
            RotatingObject.transform.Rotate(0, -1, 0, Space.World);
        }

        if (Input.GetKey("left"))
        {
            RotatingObject.transform.Rotate(0, 1, 0, Space.World);
        }
    }
}
