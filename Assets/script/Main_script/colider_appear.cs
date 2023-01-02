using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class colider_appear : MonoBehaviour
    {
        [SerializeField] private GameObject[] colider;
        public float time;
        [SerializeField] private float span;
        public static bool col_feed_bool=true;
        public Material origin_color;
        // Start is called before the first frame update


        // Update is called once per frame
        void Update()
        {
            //三番目の足場が呼ばれた全部trueにする
            if(Titan_jump.third_obj==true)
            {
                for(int i=0 ; i<colider.Length; i++)
                {
                    colider[i].SetActive(true); 
                }
                Titan_jump.third_obj=false;
            }
            time+=Time.deltaTime;

            if(time>span && col_feed_bool==true)
            {
                col_feed_bool=false;
                floor_appear(0,5);
                floor_appear(6,11);
                floor_appear(12,16);
                floor_appear(17,21);
                floor_appear(22,26);
                floor_appear(27,31);
                floor_appear(32,36);
                floor_appear(37,41);
                floor_appear(42,46);
                floor_appear(47,51);
                floor_appear(52,56);
                floor_appear(57,61);
                floor_appear(62,66);
                floor_appear(67,71);
                floor_appear(72,76);
                floor_appear(77,81);
                floor_appear(82,86);
                floor_appear(87,91);
                floor_appear(91,93);
            }
            if(time>span)
            {
                time=0.0f;
            }

        }
        //足場を消したりつけたりする関数
        private void floor_appear(int st_len, int ed_len)
        {
        int INDEX= Random.Range(st_len,ed_len);
        StartCoroutine(floor_handle(INDEX));
        }
        
        IEnumerator floor_handle(int INDEX)//消す処理と戻すコルーチン
        {
            
            colider[INDEX].gameObject.GetComponent<Renderer>().material.color=Color.red;
            yield return new WaitForSeconds(0.5f);
            colider[INDEX].SetActive(false);
            yield return new WaitForSeconds(1.0f);
            colider[INDEX].SetActive(true);
            colider[INDEX].gameObject.GetComponent<Renderer>().material.color=origin_color.color;
            col_feed_bool=true;
            time=0.0f;

        }
    }
