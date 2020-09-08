using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        var position = this.transform.position;
        position = new Vector3(position.x + horizontal, position.y, position.z + vertical);
        transform.position = position;
        // this.transform.Translate(horizontal, 0, vertical);
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
 
        if(Physics.Raycast(ray,out hit,100))
        {
            transform.LookAt(new Vector3(hit.point.x,transform.position.y,hit.point.z));
        }
    }
}
