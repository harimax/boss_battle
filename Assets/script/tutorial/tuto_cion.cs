using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tuto_cion : MonoBehaviour
{
    [SerializeField] private  Text item_counnter;
    [SerializeField] private AudioClip coins;
    [SerializeField]private AudioSource main;
    [SerializeField] private GameObject next_stage;
    public static int get_num=0; //取った枚数
    public static int how_many=1; //集める個数
    // Start is called before the first frame update
    void Start()
    {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        item_counnter.text="あと"+(how_many-get_num).ToString()+"枚いるよ";
        if (get_num>=how_many)
        {
            Debug.Log("規定数集めました");
            next_stage.SetActive(true);
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
        }
}
