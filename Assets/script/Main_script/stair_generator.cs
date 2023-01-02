using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stair_generator : MonoBehaviour
{
    public GameObject stair;
    public GameObject make_pos;
    [SerializeField]private float  delaytime;
    [SerializeField] private float change_time;
    // Start is called before the first frame update
    void Update()
    {
        change_time+=Time.deltaTime;
        if(change_time>delaytime)
        {
                var stairs=Instantiate(stair.gameObject,this.make_pos.transform.position,this.make_pos.transform.rotation);
                Destroy(stairs,15.0f);
                change_time=0.0f;
        }
        
    }
}
