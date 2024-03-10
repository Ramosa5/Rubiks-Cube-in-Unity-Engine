using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class RayControl : MonoBehaviour
{
    public Transform tWhite;
    public Transform tYellow;
    public Transform tRed;
    public Transform tOrange;
    public Transform tBlue;
    public Transform tGreen;

    public GameObject empty;

    private List<GameObject> frontRays = new List<GameObject>();
    private List<GameObject> backRays = new List<GameObject>();
    private List<GameObject> upRays = new List<GameObject>();
    private List<GameObject> downRays = new List<GameObject>();
    private List<GameObject> leftRays = new List<GameObject>();
    private List<GameObject> rightRays = new List<GameObject>();

    CurrentPosition currentPosition;

   

    // Start is called before the first frame update
    void Start()
    {
        SetRayTransforms();
        currentPosition = FindObjectOfType<CurrentPosition>();
        ReadState();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetRayTransforms()
    {
        upRays = BuildRays(tYellow, new Vector3(90, 90, 0));
        downRays = BuildRays(tWhite, new Vector3(270, 90, 0));
        leftRays = BuildRays(tRed, new Vector3(0, 180, 0));
        rightRays = BuildRays(tOrange, new Vector3(0, 0, 0));
        frontRays = BuildRays(tGreen, new Vector3(0, 90, 0));
        backRays = BuildRays(tBlue, new Vector3(0, 270, 0));
    }

    public List<GameObject> ReadFace(List<GameObject> rayStarts, Transform rayTransform)
    {
        List<GameObject> facesHit = new List<GameObject>();

        foreach (GameObject rayStart in rayStarts)
        {
            Vector3 ray = rayStart.transform.position;
            RaycastHit hit;

            if (Physics.Raycast(ray, rayTransform.forward, out hit, Mathf.Infinity, 1 << 6))
            {
                facesHit.Add(hit.collider.gameObject);
            }
        }
        return facesHit;
    }

    List<GameObject> BuildRays(Transform rayTransform, Vector3 direction)
    {
        int rayCount = 0;
        List<GameObject> rays = new List<GameObject>();

        for (int i = 1; i > -2; i--)
        {
            for (int j = -1; j < 2; j++)
            {
                Vector3 begin = new Vector3(rayTransform.localPosition.x + j, rayTransform.localPosition.y + i, rayTransform.localPosition.z);
                GameObject start = Instantiate(empty, begin, Quaternion.identity, rayTransform);
                start.name = rayCount.ToString();
                rays.Add(start);
                rayCount++;
            }

        }
        rayTransform.localRotation = Quaternion.Euler(direction);
        return rays;
    }

    public void ReadState()
    {
        currentPosition = FindObjectOfType<CurrentPosition>();

        currentPosition.up = ReadFace(upRays, tYellow);
        currentPosition.down = ReadFace(downRays, tWhite);
        currentPosition.left = ReadFace(leftRays, tRed);
        currentPosition.right = ReadFace(rightRays, tOrange);
        currentPosition.front = ReadFace(frontRays, tGreen);
        currentPosition.back = ReadFace(backRays, tBlue);

    }
}
