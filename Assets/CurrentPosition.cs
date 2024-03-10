using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Security.Permissions;
using UnityEngine;

public class CurrentPosition : MonoBehaviour
{
    public List<GameObject> front = new List<GameObject>();
    public List<GameObject> back = new List<GameObject>();
    public List<GameObject> up = new List<GameObject>();
    public List<GameObject> down = new List<GameObject>();
    public List<GameObject> right = new List<GameObject>();
    public List<GameObject> left = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SideChosen(List<GameObject> sides)
    {
        foreach (GameObject side in sides)
        {
            if (side != sides[4])
            {
                side.transform.parent.transform.parent = sides[4].transform.parent;
            }
        }
        sides[4].transform.parent.GetComponent<Move>().Rotate(sides);
    }

    public void Undo(List<GameObject> children, Transform cube)
    {
        foreach(GameObject child in children)
        {
            if (child!= children[4])
            {
                child.transform.parent.transform.parent = cube;
            }
        }
    }
}
