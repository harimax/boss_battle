using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class tutorial_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var button=GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
        SceneManager.LoadScene("tutorial");
        });
    }


}
