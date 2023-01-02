using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class item_manager : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("生成するもの")]
        private GameObject item;
        // Update is called once per frame
        void Update()
        {
            if(gameflag_manager.itemgenerator==true&&gameflag_manager.item_bool==true)
            {
                //Debug.Log("生成しました");
                gameflag_manager.item_bool=false;
                StartCoroutine("delaygenerator");
            }
        }
        IEnumerator delaygenerator()
        {
            yield return new WaitForSeconds(2.0f);
            float x=Random.Range(-25f,28f);
            float y=Random.Range(12f,16f);
            float z=Random.Range(-30f,32f);
            Instantiate(item.gameObject,new Vector3(x,y,z),transform.rotation);
        }
    }
