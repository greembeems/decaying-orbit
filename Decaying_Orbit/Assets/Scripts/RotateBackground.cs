using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBackground : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    // Length of floor - wall thickness
    [SerializeField]
    float levelLength;
    [SerializeField]
    float rotationPerStep;
    float rotation;
    float lastRotation;


    // Start is called before the first frame update
    void Start()
    {
        rotationPerStep = 360 / levelLength;
        rotation = gameObject.transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerTransform.position.x);
        rotation = -rotationPerStep * playerTransform.position.x;

        gameObject.transform.eulerAngles = new Vector3(0, 0, rotation);

        Debug.Log(rotation);
    }
}
