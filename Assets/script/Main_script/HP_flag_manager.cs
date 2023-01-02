using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class HP_flag_manager : MonoBehaviour
    {
        [SerializeField] private GameObject second_Danmaku;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if(Titan_HP.currentHp<=Titan_HP.maxHp/2)
            {
                danmaku_move1.danmaku_up=true;
                second_Danmaku.GetComponent<danmaku>().enabled = true;
            }
        }
    }
