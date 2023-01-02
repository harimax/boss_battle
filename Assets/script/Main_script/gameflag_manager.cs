using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameflag_manager : MonoBehaviour
{
        public static bool stop=false;//敵の停止判断
        public static bool item_bool=true; //アイテムを表示するかいなか
        public static bool itemgenerator=true; //アイテム生成できるか
        public static bool get_flag=false; //一定数アイテムを取ったか
        public static bool damege=false; //ダメージを与えたか
        public static bool player_damage=false; //プレイヤーがダメージを受けたか
    }
