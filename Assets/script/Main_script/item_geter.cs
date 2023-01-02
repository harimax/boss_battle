using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    //プレイヤーにアタッチ
    [RequireComponent(typeof(AudioSource))]
    public class item_geter : MonoBehaviour
    {
        [SerializeField] private  Text item_counnter;
        public static int get_num=0; //取った枚数
        public static int how_many=2; //集める個数
        public static int hitpoint=0; //攻撃に当たった回数
        [SerializeField]private AudioSource main;
        [SerializeField]private GameObject damage_effect;
        [SerializeField] private AudioClip coins;
        [SerializeField] private AudioClip damage;
        private bool stop = false;
        Rigidbody rb;
        void Start()
        {
            rb=gameObject.GetComponent<Rigidbody>();
        }
        // Update is called once per frame
        void Update()
        {
            item_counnter.text="あと"+(how_many-get_num).ToString()+"枚いるよ";
            if (get_num>=how_many)
            {
                Debug.Log("規定数集めました");
                gameflag_manager.get_flag=true;
                gameflag_manager.itemgenerator=false;
                
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            //コイン消滅処理
            if(collision.gameObject.tag=="item")
            {
                //Debug.Log("コインを取りました");
                Destroy(collision.gameObject);
                get_num++;
                StartCoroutine(Titan_push.instance.hit_stop(0.015f));
                gameflag_manager.item_bool=true;
                main.PlayOneShot(coins);
            }
            //ダメージオブジェクトとの衝突
            if(collision.gameObject.tag=="object" && gameflag_manager.player_damage==false)
            {
                gameflag_manager.player_damage=true;
                var effects=Instantiate(damage_effect.gameObject,this.transform.position,this.transform.rotation);
                Destroy(effects,1.0f);
                StartCoroutine(Titan_push.instance.hit_stop(0.015f));
                Debug.Log("痛い");
                main.PlayOneShot(damage);
                hitpoint++;
                StartCoroutine("delay");//移動のコルーチン起動
            }
            //壁との激突
            if(collision.gameObject.tag=="dead_wall")
            {
                stop=true;
                rb.isKinematic=true;
                main.PlayOneShot(damage);
                StartCoroutine("restart");
            }
        }
        IEnumerator delay()
        {
            yield return new WaitForSeconds(1.0f);
            gameflag_manager.player_damage=false;
        }
        IEnumerator restart() 
        {   
            Time.timeScale = 0.1f;
            yield return new WaitForSecondsRealtime(1.0f);  
            transform.position=drop_manager.resporn;
            rb.isKinematic=false;
            stop=false;
            Time.timeScale=1.0f;
        }
    }
