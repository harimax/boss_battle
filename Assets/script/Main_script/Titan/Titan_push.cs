using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

    public class Titan_push : MonoBehaviour
    {
        [SerializeField]private AudioSource main;
        [SerializeField] private AudioClip push_sound;
        private static Rigidbody Titan_rb;
        private  Rigidbody player_rb;
        private  Animator titan_anime;
        public bool Colision_Judge = true; // フラグ

        public static Titan_push instance;
   
             public void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            player_rb=gameObject.GetComponent<Rigidbody>();
        }
        //ぶつけてダメージ与えるとギミックが元にもどる。
        public  void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag=="Titan" && Colision_Judge==true)
            {
                main.PlayOneShot(push_sound);
                Titan_HP.currentHp--;
                Titan_HP.update_num=+5.0f; //5だけ加速
                item_geter.how_many=item_geter.how_many+1;//攻撃を決めるごとに集める枚数＋1
                gameflag_manager.damege=true;
                Titan_rb=collision.gameObject.GetComponent<Rigidbody>();
                titan_anime=collision.gameObject.GetComponent<Animator>();
                Vector3 derection=transform.position;
                derection=derection-new Vector3(0,2,0);
                
                if(Titan_HP.currentHp>0 ||  SceneManager.GetActiveScene().name == "tutorial")
                {
                    StartCoroutine(hit_stop(0.05f));//ヒットストップ
                }

                Titan_rb.isKinematic=false;
                derection.Normalize();
                titan_anime.SetTrigger("damage_triger");
                Titan_rb.AddForce(derection * 250f, ForceMode.Impulse);
                Titan_rb.AddForce(Vector3.up * -100f, ForceMode.Impulse);
                Titan_rb.useGravity = true;
                Colision_Judge=false;
                
                gameflag_manager.itemgenerator=true;
                StartCoroutine("back");//移動のコルーチン起動
            }
        }
            IEnumerator back()
            {
                yield return new WaitForSeconds(0.75f);
                player_rb.isKinematic=true;
                Vector3[] path={new Vector3(1.5f,120f,5.5f), drop_manager.resporn}; //移動処理
                transform.DOLocalPath(path,2.0f,PathType.CatmullRom);//２秒で移動させる
                yield return new WaitForSeconds(2.5f);
                player_rb.isKinematic=false;
                Colision_Judge=true;
                
            }
            //汎用化ヒットストップ
            public IEnumerator hit_stop(float hit_time)
            {
                Time.timeScale=0.1f;
                yield return new WaitForSeconds(hit_time); 
                Time.timeScale=1.0f;
            }
    }
