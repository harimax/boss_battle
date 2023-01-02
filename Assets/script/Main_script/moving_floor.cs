using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_floor : MonoBehaviour
{
    [SerializeField] private float counter;
    [SerializeField] private float  move_x=0.05f;
    [SerializeField] private float  move_y=0.05f;
    [SerializeField] private float  move_z=0.05f;
    [SerializeField] private bool x_dis=false;
    [SerializeField] private bool y_dis=false;
    [SerializeField] private bool z_dis=false;
    [SerializeField] private float  counter_max;
   

     void Start()
     {
        counter=0;
       if(x_dis==true)  move_x*=-1;
       if(y_dis==true)  move_y*=-1;
       if(z_dis==true)  move_z*=-1;
     }
    // Update is called once per frame
    void Update()
    {
        Vector3  pos=new Vector3(move_x*Time.deltaTime,move_y*Time.deltaTime,move_z*Time.deltaTime);
        transform.Translate(pos);
        counter+=Time.deltaTime;

        if(counter>counter_max)
        {
            counter=0;
            move_x*=-1;
            move_y*=-1;
            move_z*=-1;
        }
    }
}
