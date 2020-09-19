using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootAutoRotate : MonoBehaviour
{
    public float RotationSpeed = 100;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
    }
}