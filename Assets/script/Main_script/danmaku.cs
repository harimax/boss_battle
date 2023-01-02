using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class danmaku : MonoBehaviour
    {
        public danmaku_move danmaku_move;
        public GameObject bullet;  //弾
        public Transform obj;  //ポジション
        public float time;
        [SerializeField] private float span=0.2f;
        public float rotdbool;

        // Update is called once per frame
        void Update()
        {
            gameObject.transform.Rotate(0,rotdbool,0);
            this.time+=Time.deltaTime;
            if(this.time>span)
            {
                Instantiate(bullet.gameObject,this.obj.transform.position,this.obj.transform.rotation);
            bullet.transform.position = obj.position ;
                time=0;
            }      
        }
    }
