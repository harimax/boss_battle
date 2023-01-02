using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Titan
{
    public class Titan_attack : MonoBehaviour
    {
        public GameObject expro_Ball_geretor;

        // Update is called once per frame
        void Update()
        {
            // Debug.Log(gameflag_manager.stop);
            if (gameflag_manager.stop==true)
            {
               expro_Ball_geretor.SetActive(true);
            }
            else
            {
                expro_Ball_geretor.SetActive(false);
            }
        }
    }
}
