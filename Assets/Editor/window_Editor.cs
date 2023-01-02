using System.Collections;
using System.Collections.Generic;
using UnityEditor; // エディタ拡張関連はUnityEditor名前空間に定義されているのでusingしておく。
using UnityEngine;

// エディタに独自のウィンドウを作成する
public class window_Editor : EditorWindow
{
   // メニューのWindowにEditorExという項目を追加。
  [MenuItem("Window/EditorEx")]
  static void Open()
  {
        // メニューのWindow/EditorExを選択するとOpen()が呼ばれる。
        // 表示させたいウィンドウは基本的にGetWindow()で表示＆取得する
    EditorWindow.GetWindow<window_Editor>("EditorEX"); //タイトル名を"EditorEx"に指定（後からでも変えられるけど）
  }
    // Windowのクライアント領域のGUI処理を記述
  void OnGUI()
  {
    // 試しにラベルを表示
    EditorGUILayout.LabelField( "\n 敵の停止判断:"+gameflag_manager.stop.ToString()+"\n");
    EditorGUILayout.LabelField( "\n アイテムを表示するかいなか:"+gameflag_manager.item_bool.ToString()+"\n");
    EditorGUILayout.LabelField( "\n アイテム生成できるか:"+gameflag_manager.itemgenerator.ToString()+"\n");
    EditorGUILayout.LabelField( "\n ダメージを与えたか:"+gameflag_manager.damege.ToString()+"\n");
    EditorGUILayout.LabelField( "\n 一定数アイテムを取ったか:"+gameflag_manager.get_flag.ToString()+"\n");
    EditorGUILayout.LabelField( "\n プレイヤーがダメージを受けたか:"+gameflag_manager.player_damage.ToString()+"\n");
  }

  void Update()
    {
        Repaint();
    }
}

