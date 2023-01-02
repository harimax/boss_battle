using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Titan
    {
    public class Titan_back : MonoBehaviour
    {
        public   GameObject Titan;
        private static Rigidbody rb;
        // Start is called before the first frame update
        void Start()
        {
           rb=Titan.gameObject.GetComponent<Rigidbody>(); 
        }

        // Update is called once per frame
        void Update()
        {
            if (gameflag_manager.damege==true)
            {
                StartCoroutine("delay");
            }
        }
        //定位置に戻ってくるコルーチン
        IEnumerator delay()
        {
            yield return new WaitForSeconds(3.0f);
            gameflag_manager.damege=false; 
            yield return new WaitForSeconds(1.0f);
            rb.useGravity =false;
            rb.isKinematic=true;
            Titan.transform.eulerAngles=new Vector3(0f,180f,0f);
            Titan.transform.position=Titan_jump.start;
            gameflag_manager.stop=false;
        }
    }
}
