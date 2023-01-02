using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_col : MonoBehaviour
{       
    [SerializeField]private AudioSource main;
    [SerializeField]private GameObject damage_effect;
    [SerializeField] private AudioClip damage;
    void OnParticleCollision(GameObject collision)
        {
            if(collision.gameObject.tag=="Player"&& gameflag_manager.player_damage==false)
            {
                gameflag_manager.player_damage=true;
                var effects=Instantiate(damage_effect.gameObject,collision.transform.position,collision.transform.rotation);
                Destroy(effects,1.0f);
                StartCoroutine(Titan_push.instance.hit_stop(0.015f));
                Debug.Log("痛い");
                main.PlayOneShot(damage);
                item_geter.hitpoint++;
                StartCoroutine("delay");//移動のコルーチン起動
            }
        }
        
    IEnumerator delay()
        {
            yield return new WaitForSeconds(1.0f);
            gameflag_manager.player_damage=false;
        }
}
