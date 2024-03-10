using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    CurrentPosition currentPosition;
    RayControl rayControl;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = FindObjectOfType<CurrentPosition>();
        rayControl = FindObjectOfType<RayControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rayControl.ReadState();

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 50.0f, 1<<6))
            {
                GameObject face = hit.collider.gameObject;
                List<List<GameObject>> sides = new List<List<GameObject>>()
                {
                    currentPosition.up,
                    currentPosition.down,
                    currentPosition.left,
                    currentPosition.right,
                    currentPosition.front,
                    currentPosition.back
                };
                foreach (List < GameObject > side in sides)
                {
                    if (side.Contains(face))
                    {
                        currentPosition.SideChosen(side);
                    }
                }
            }
        }
    }
}
