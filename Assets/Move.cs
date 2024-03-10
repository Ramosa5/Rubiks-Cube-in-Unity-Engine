using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Move : MonoBehaviour
{
    private List<GameObject> chosenSide;
    private Vector3 mouseRef;
    private Vector3 rotation;
    private bool dragging = false;
    private bool shouldCut = false;
    private Quaternion destination;
    private RayControl rayControl;
    private CurrentPosition currentPosition;


    // Start is called before the first frame update
    void Start()
    {
        rayControl = FindObjectOfType<RayControl>();
        currentPosition = FindObjectOfType<CurrentPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            Spin(chosenSide);
            if (Input.GetMouseButtonUp(0))
            {
                dragging = false;
                SetCut();
            }
        }
        if (shouldCut)
        {
            Cut();
        }
    }

    private void Spin(List<GameObject> side)
    {
        rotation = Vector3.zero;

        Vector3 move = (Input.mousePosition - mouseRef);

        if (side == currentPosition.front)
        {
            rotation.x = (move.x + move.y) * -0.5f;
        }
        if (side == currentPosition.back)
        {
            rotation.x = (move.x + move.y) * -0.5f;
        }
        if (side == currentPosition.up)
        {
            rotation.y = (move.x + move.y) * 0.5f;
        }
        if (side == currentPosition.down)
        {
            rotation.y = (move.x + move.y) * 0.5f;
        }
        if (side == currentPosition.right)
        {
            rotation.z = (move.x + move.y) * 0.5f;
        }
        if (side == currentPosition.left)
        {
            rotation.z = (move.x + move.y) * -0.5f;
        }

        transform.Rotate(rotation, Space.Self);

        mouseRef = Input.mousePosition;
    }

    public void Rotate(List<GameObject> side)
    {
        chosenSide = side;
        mouseRef = Input.mousePosition;
        dragging = true;
    }

    public void SetCut()
    {
        Vector3 buf = transform.localEulerAngles;
        buf.x = Mathf.Round(buf.x / 90) * 90;
        buf.y = Mathf.Round(buf.y / 90) * 90;
        buf.z = Mathf.Round(buf.z / 90) * 90;

        destination.eulerAngles = buf;
        shouldCut = true;
    }
    private void Cut()
    {
        dragging = false;
        var step = 500.0f * Time.deltaTime;
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, destination, step);
        if (Quaternion.Angle(transform.localRotation, destination) <= 1)
        {
            transform.localRotation = destination;
            currentPosition.Undo(chosenSide, transform.parent);
            rayControl.ReadState();
            shouldCut = false;
        }

    }
}
