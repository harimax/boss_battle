using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_canon : MonoBehaviour
{
    [SerializeField] private GameObject[] fire_canon;
    private Vector3[] fire_canon_rote;
    private int rand_int;
    public bool fire_bool;
    public float fire_time;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        //体力が１つ減ればギミック追加
        if(Titan_HP.currentHp<=Titan_HP.maxHp-1) 
        {
            fire_bool=true;

        }
        //ギミック発動（１０秒おきに）
        if(fire_bool==true)
        {
            fire_time+=Time.deltaTime;
            if(fire_time > 10.0f- (Titan_HP.maxHp-Titan_HP.currentHp)*1.5 )
            {
                fire_canon[0].SetActive(true);
                fire_canon[0].transform.Rotate(0,-30f* Time.deltaTime,0);
            }
        }
        //特定の角度になるとリセット
        if(fire_canon[0].transform.localEulerAngles.y<260 && fire_canon[0].transform.localEulerAngles.y>250)
        {
            Debug.Log("消します");
            fire_canon[0].SetActive(false);
            fire_canon[0].transform.rotation=Quaternion.Euler( 0f, 90f, 0f);
            fire_time=0.0f;
        }
        //３分の１を切れば中央に火炎放射器
        if(Titan_HP.currentHp <=Titan_HP.maxHp/3)
        {
            fire_canon[1].SetActive(true);
        }
        if(Titan_HP.currentHp <=0)
        {
            fire_canon[1].SetActive(false);
            fire_canon[0].SetActive(false);
        }
    }
}
