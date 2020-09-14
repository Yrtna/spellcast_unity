using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
            return;
        DisableGameobject();
        Invoke(nameof(EnableGameobject), 3.0f);
    }

    private void DisableGameobject()
    {
        gameObject.SetActive(false);
    }

    private void EnableGameobject()
    {
        gameObject.SetActive(true);
    }
}
