using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class move_mainstage : MonoBehaviour
{
    [SerializeField] private GameObject player; 
    [SerializeField] private GameObject move_point;
    private Rigidbody  rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=rb=player.gameObject.GetComponent<Rigidbody>(); 
        DG.Tweening.DOTween.SetTweensCapacity(tweenersCapacity:800, sequencesCapacity:200);
    }
    // Update is called once per frame
     public  void OnCollisionEnter(Collision collision)
     {
         if(collision.gameObject.tag=="Player")
         {
            rb.velocity=Vector3.zero;
            rb.isKinematic=true;
            Debug.Log("移動します");
            Vector3[] path={new Vector3(-40,49,-84),move_point.transform.position}; //移動処理
            player.transform.DOLocalPath(path,1.0f,PathType.CatmullRom);//1秒で移動させる
            StartCoroutine("delay");
         }
     }
       IEnumerator delay()
        {
            yield return new WaitForSeconds(2.0f);
            rb.isKinematic=false;
        }
     
}
