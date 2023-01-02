using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getFloor : MonoBehaviour
{
    private GameObject newobj;
    void OnCollisionEnter(Collision  collision) 
    { 
            if (  collision.gameObject.tag == "MoveFloor") {
                Debug.Log("乗った");
                newobj = new GameObject();
                gameObject.transform.rotation=Quaternion.Euler(0f,0f,0f);
                newobj.transform.parent = collision.gameObject.transform;
                transform.parent = newobj.transform;
            }

    }

    void OnCollisionExit(Collision collision)
    {
            if (transform.parent != null && collision.gameObject.tag == "MoveFloor")
            {
                Debug.Log("降りた");
                transform.parent = null;
                Destroy(newobj);
            }
    }
}
