using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    [RequireComponent(typeof(AudioSource))]
    public class game_start : MonoBehaviour
    {
        [SerializeField]private AudioSource main;
        [SerializeField] private AudioClip win_sounds;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject manager;
        [SerializeField] private GameObject HP;
        [SerializeField] private GameObject item_counter;
        [SerializeField] private GameObject Titan;
        [SerializeField] private GameObject canvas;
        [SerializeField] private GameObject end_camera;
        [SerializeField] private GameObject Invector_camera;
        private  Rigidbody rb;
       [SerializeField] Text times;
       [SerializeField] GameObject rebutton;
        private float seconds;
        private float oldseconds;
        private bool startflag=false;
        private bool result_flag=false;

        // Start is called before the first frame update
        // Update is called once per frame
        void Start()
        {
            rb=player.gameObject.GetComponent<Rigidbody>();
        }
        void Update()
        {
            // Debug.Log(Titan_HP.currentHp);
            if(startflag==true)
            {
                seconds += Time.deltaTime;
                oldseconds = seconds;
            }
                //敵の体力が０になると
            if(Titan_HP.currentHp<=0)
            {
                startflag=false;
                manager.SetActive(false);
                Titan.SetActive(false);
                HP.SetActive(false);
                item_counter.SetActive(false);
                rb.isKinematic=true;
                end_camera.SetActive(true);
                Invector_camera.SetActive(false);
                HP.SetActive(false);
                if(!result_flag)
                {
                    StartCoroutine("result");//結果画面コルーチン起動
                    result_flag=true;
                }
            }
        }
        //ギミックを全て解放させる
        public  void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag=="Player")
            {
                startflag=true;
                manager.SetActive(true);
                Titan.SetActive(true);
                canvas.SetActive(true);
                transform.position= new Vector3(-50f,-100f,-40f);
            }
        }
        IEnumerator result() //ゲームクリア
        {
            yield return new WaitForSeconds(2.0f);
            main.PlayOneShot(win_sounds);
            times.text = ("クリアタイム"+((int)seconds/60).ToString("00") + ":" + ((int)seconds%60).ToString("00")+"\n"+
            "攻撃に当たった回数は"+item_geter.hitpoint.ToString() );
            rebutton.SetActive(true);
        }
    }
