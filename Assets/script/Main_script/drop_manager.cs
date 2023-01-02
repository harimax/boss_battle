using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class drop_manager : MonoBehaviour
{
    public GameObject player;
    public GameObject text;
    public static Vector3 resporn;
    Rigidbody rb;
    CapsuleCollider player_col;
    AudioSource ban;
    bool soundchecker=false;
    public bool dropflag=false;

    // Start is called before the first frame update
    void Start()
    {
        ban=GetComponent<AudioSource>();
        rb=player.gameObject.GetComponent<Rigidbody>();
        resporn=rb.position;
        player_col=player.GetComponent<CapsuleCollider>();
        Debug.Log(resporn);
    }
    ///////////////////////////updata関数///////////////////////////////////////
    void Update()
    {
        // Debug.Log(dropflag);
        if(Input.GetKeyDown(KeyCode.Z))
        {
            // Debug.Log("Zが押されました");
        }
        if (dropflag==false && Input.GetKeyDown(KeyCode.Z) )//再開
        {
            // Debug.Log("硬直を解除します");
            Time.timeScale=1.0f;
            rb.isKinematic=false; 
            text.GetComponent<Text>().text = "";
        }
    }

////////////////////////FixedUpdate/////////////////////////////////////////
  void FixedUpdate()
    {
         if (player.transform.position.y < -10|| player.transform.position.y>1000)  //特定座標にて発生
        {
            dropflag=!dropflag;
            if(!soundchecker)  //音の発生
            {
                Debug.Log(dropflag);
                soundchecker=true;
                ban.Play();
                Debug.Log("鳴った");
            }
        if(dropflag==true)
            {
            rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
            player_col.isTrigger=true; //カプセルコライダーのトリガーオン
            rb.isKinematic=true;    //動きを止める。
            soundchecker=false;  //音を止める。
            rb.velocity=Vector3.zero; //物理速度を止める。
            rb.position=resporn; //所定の位置に移動させる
            // Debug.Log(rb.position);
            rb.velocity=Vector3.zero; //物理速度を止める。
            StartCoroutine("startload");//ロードのコルーチン起動
            dropflag=!dropflag;
            // Debug.Log(dropflag);
             }
        }
      
    }
//////////////////////////////////////////////////////////////////////////////

    void PrintGameover()
    {    
        text.GetComponent<Text>().text = "Zで再スタート";
    }
    void Restart()  //リジッドボディを元に戻してリスポーン
    {
        soundchecker=false;
        rb.velocity=Vector3.zero;
        player_col.isTrigger=false;
        //rb.isKinematic=false;
       
    }
    IEnumerator rigidDelay() //音とリジットの遅延
    {
        //3秒停止
        yield return new WaitForSeconds(0.5f);
        soundchecker=false;
        //count++;//落ちた回数とカウント
    }
    IEnumerator startload()
    {
        //秒停止
        yield return new WaitForSecondsRealtime(0.1f);
        Restart(); //リスタート処理
        if(rb.position==resporn)
        {
            PrintGameover(); //ゲームオーバーのテロップを書く
            Time.timeScale=0.0f;
        }

 
    }
}
