using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

    public class danmaku_move1 : MonoBehaviour
    {
        public Transform[] ploe_obj; //移動先配列
        public GameObject danmaku;
        public float time;//時間
        public float flagtime;//フラグを起こす時間
        public int index;
        public static bool danmaku_up=false;
        private Vector3 up=new Vector3 (0f,0f,0f);
        // Start is called before the first frame update
        void Start()
        {
            this.index=Random.Range(0,5);
        }

        // Update is called once per frame
        void Update()
        {
            if(gameflag_manager.stop==true)
            {
                danmaku.SetActive(false);
            }
            else
            {
                danmaku.SetActive(true);
            }
            
            time+=Time.deltaTime;
            if(danmaku_up==true)
            {
                up=new Vector3(0f,0.2f,0f);
            }
            Vector3[] path={ ploe_obj[index].transform.position+up}; //移動処理
            danmaku.transform.DOLocalPath(path,0.4f,PathType.CatmullRom);//1秒で移動させる

            if(this.time>flagtime)//移動とインクリメントは時間処理
            {
                if(index<5)
                {
                index++;
                time=0;
                }
                if(index>=5)
                {
                index=0;
                time=0;
                }
            }
        }
    }
