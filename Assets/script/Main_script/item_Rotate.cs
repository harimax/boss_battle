using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_Rotate : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,35f* Time.deltaTime,0);
    }
}
