using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilboardScript : MonoBehaviour
{
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRotation = mainCamera.transform.eulerAngles;
        newRotation.x = 60;
        newRotation.z = 0;
        transform.eulerAngles = newRotation;
    }
}
