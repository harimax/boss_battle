using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class fire_generator : MonoBehaviour
    {
        public GameObject GAN;
        public GameObject Balls;
        public GameObject player;//向くキャラ
        public GameObject Titan;//タイタン
        [SerializeField ]private float ballSpeed ;
        private Animator fire_throw;
        float  delaytime;
        // Start is called before the first frame update
        void Start()
        {
            //アニメーションと生成の同期
            delaytime=3.0f;
            fire_throw=Titan.gameObject.GetComponent<Animator>();
            transform.LookAt(player.transform);
            StartCoroutine("BallShot"); 
        }
        // Update is called once per frame
        void Update()
        {
        transform.LookAt(player.transform);
        //体力が半分になると１．５倍
        if(Titan_HP.currentHp<Titan_HP.maxHp/1.5)
        {
            delaytime=1.5f;
        }
        }
        IEnumerator BallShot()
        {
            while(true)
            {
                yield return new WaitForSeconds(delaytime);
                fire_throw.SetTrigger("throw_triger");
                var shot=Instantiate(Balls.gameObject,this.GAN.transform.position,this.GAN.transform.rotation);
                shot.GetComponent<Rigidbody>().velocity = transform.forward.normalized * ballSpeed;
                Destroy(shot,4.0f);
            }
        }
    }
