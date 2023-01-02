using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class danmaku_move : MonoBehaviour
    {
        [SerializeField] private float speed=60.0f;
        // Update is called once per frame
        void Update()
        {
            transform.position+=transform.TransformDirection(Vector3.forward*(speed+Titan_HP.update_num))*Time.deltaTime;
            Destroy(gameObject,4.0f);
        }
    }
