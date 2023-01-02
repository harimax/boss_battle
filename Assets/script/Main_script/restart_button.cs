using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class restart_button : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var button=GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
        SceneManager.LoadScene("home");
        item_geter.how_many=2;
        });
    }

}
