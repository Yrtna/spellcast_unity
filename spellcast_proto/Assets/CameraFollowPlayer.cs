using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerTransform;

    public int posYOffset = 15;

    public int posZOffset = -10;

    public int rotXOffset = 55;
    
    // Update is called once per frame
    private void LateUpdate()
    {
        var position = playerTransform.position;
        transform.position = new Vector3(position.x, position.y + posYOffset, position.z + posZOffset);
    }
}
