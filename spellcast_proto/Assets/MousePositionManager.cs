using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionManager : MonoBehaviour
{
    [SerializeField] private LayerMask Ground;
    public Texture2D cursor;

    private Vector3 mouseVec;

    private void Start()
    {
        // var cursorOffset = new Vector2(cursor.width/2, cursor.height/2);
        // Cursor.SetCursor(cursor, cursorOffset, CursorMode.Auto);
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, Ground))
        {
            mouseVec = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(mouseVec);
        }

        // var position = transform.position;
        // if (position.y != 0)
        // {
        //     position = new Vector3(position.x, 0, position.z);
        //     transform.position = position;
        // }
        
    }

    public Vector3 GetMousePos()
    {
        return mouseVec;
    }
}