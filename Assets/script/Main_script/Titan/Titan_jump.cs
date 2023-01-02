using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

    public class Titan_jump : MonoBehaviour
    {    
        private  Rigidbody rb;
        public   GameObject Titan;
        public Transform[] obj; //移動先配列
        public GameObject[] rootobj; //道のオブジェクト配列
        public int index;//移動先の番号
        public GameObject player;//向くキャラ
        public static Vector3 start;
        public float time;//時間
        public float flagtime;//フラグを起こす時間
        public static bool third_obj=false; //三番目のオブジェクトが表示されてるかいなか
        public int temp; //足場番号の保存用
        
        // Start is called before the first frame update
        void Start()
        {
            rb=Titan.GetComponent<Rigidbody>();
            start=Titan.transform.position;
            Debug.Log(start);
        }
        // Update is called once per frame
        void Update()
        { 
            if (gameflag_manager.damege==true)
            {
               rootobj[temp].SetActive(false); 
            }
            //動けるかつ
            if(gameflag_manager.stop==false && gameflag_manager.get_flag==true)
            {
               RotateFinC();
               index=Random.Range(0,3);
               time+=Time.deltaTime;
            }
            //時間を超えて、動きがあるなら
            if(time>flagtime && gameflag_manager.stop==false)
            {
                temp=index;
                gameflag_manager.get_flag=false;
                Vector3[] path={new Vector3(1.5f,120f,5.5f), obj[temp].transform.position}; //移動処理
                Titan.transform.DOLocalPath(path,1.0f,PathType.CatmullRom);//1秒で移動させる
                StartCoroutine("delayRotatestop");//コルーチン発動
                rootobj[temp].SetActive(true);
                
                //3つ目の足場が出たら
                if(rootobj[2].activeSelf==true)
                {
                    third_obj=true;
                }


                colider_appear.col_feed_bool=true;   
                time=0;
                item_geter.get_num=0;
            }  
        }
        void RotateFinC()//タイタンをプレイヤーの方向に向かせる
        {
            var aim = this.player.transform.position - this.Titan.transform.position;
            var look = Quaternion.LookRotation(aim, Vector3.up);
            this.Titan.transform.localRotation = look;
        }
        IEnumerator delayRotatestop()//1.0秒遅延で向きを固定させる。
        {
                yield return new WaitForSeconds(1.0f);
                gameflag_manager.stop=true;
                Debug.Log("向きを固定しました。");
                // rb.isKinematic=true;
                time=0; 
        }
    }
