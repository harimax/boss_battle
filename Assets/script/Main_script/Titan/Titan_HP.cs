using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Titan_HP : MonoBehaviour
{
    public static int maxHp = 5;
    public static int currentHp;
    public static float update_num=0f; //ダメージが減るごとにスピードが上がる。
    //Sliderを入れる
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
         //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);
    }

    // Update is called once per frame
    void Update()
    {
        //最大HPにおける現在のHPをSliderに反映。
        //int同士の割り算は小数点以下は0になるので、
        //(float)をつけてfloatの変数として振舞わせる。
        slider.value = (float)currentHp / (float)maxHp; ;
        //Debug.Log("slider.value : " + slider.value);
    }
}