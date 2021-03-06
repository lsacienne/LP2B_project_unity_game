using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Script : MonoBehaviour
{


    public Player_Script ref_player;
    protected AudioSource wallBreaker;

    public AudioClip[] glass_sounds;

    protected int wallRigidity = 3;

    void Start()
    {
        wallBreaker = gameObject.AddComponent<AudioSource>();
        wallBreaker.volume = 0.2f;
        wallBreaker.clip = glass_sounds[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* If the catchboy enter in the invisible wall, it produce a sound of broken glass and reduce the durability of the wall */
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "CatchBoy"){
            if(wallRigidity > 1){
                wallRigidity--;
                wallBreaker.Play();
            } else if(wallRigidity == 1){
                wallBreaker.clip = glass_sounds[1];
                wallRigidity--;
                wallBreaker.Play();
                ref_player.EnlargeBorders();
            }
        }
    }
}
