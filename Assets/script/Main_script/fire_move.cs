using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_move : MonoBehaviour
{
    public GameObject player;//向くキャラ
    static public float speed=20f;

    // Update is called once per frame
    void Update()
    {
        var aim = this.player.transform.position - this.gameObject.transform.position;
        transform.position+=transform.TransformDirection(aim*Time.deltaTime);
        Destroy(this.gameObject,10.0f);
    }
}
