using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETamigo : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent <Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D collision2D) {
    if (collision2D.gameObject.CompareTag("Player")) {
    		anim.Play("Et-tchauzin");
    	}
    }
    	
    void OnTriggerExit2D(Collider2D collision2D) {
    if (collision2D.gameObject.CompareTag("Player")) {
    		anim.Play("etidle");
    	} 	
    }
}
