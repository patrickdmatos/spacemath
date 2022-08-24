using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciaFase_0 : MonoBehaviour
{
    public GameObject jogador;
    private Player player;
    
    
    public GameObject LockPT2;
    public GameObject LockPT3;
    public GameObject LockPT4;
    public GameObject LockPT5;
    public GameObject LockPT6;
    public GameObject LockPT7;
    public GameObject LockPT8;
    
    public GameObject peca1;
    public GameObject peca2;
    public GameObject peca3;
    public GameObject peca4;
    public GameObject peca5;
    public GameObject peca6;
    
    public GameObject gasosa;
    public GameObject bateria;
    
    
	
    void Start()
    {
    	player = jogador.GetComponent <Player> ();
    	if (player.nivelconcluido == 1) {
    		LockPT2.SetActive(false);
    		peca1.SetActive(true);
    	}
    	if (player.nivelconcluido == 2) {
    		LockPT2.SetActive(false);
    		LockPT3.SetActive(false);
    		
    		peca1.SetActive(true);
    		peca2.SetActive(true);
    	}
    	if (player.nivelconcluido == 3) {
    		LockPT2.SetActive(false);
    		LockPT3.SetActive(false);
    		LockPT4.SetActive(false);
   		
    		peca1.SetActive(true);
    		peca2.SetActive(true);
    		peca3.SetActive(true);
    	}
    	if (player.nivelconcluido == 4) {
    		LockPT2.SetActive(false);
    		LockPT3.SetActive(false);
    		LockPT4.SetActive(false);
    		LockPT5.SetActive(false);
    		
    		peca1.SetActive(true);
    		peca2.SetActive(true);
    		peca3.SetActive(true);
    		peca4.SetActive(true);
    	}
    	if (player.nivelconcluido == 5) {
    		LockPT2.SetActive(false);
    		LockPT3.SetActive(false);
    		LockPT4.SetActive(false);
    		LockPT5.SetActive(false);
    		LockPT6.SetActive(false);
    		
    		peca1.SetActive(true);
    		peca2.SetActive(true);
    		peca3.SetActive(true);
    		peca4.SetActive(true);
    		peca5.SetActive(true);
    	}
    	if (player.nivelconcluido == 6) {
    		LockPT2.SetActive(false);
    		LockPT3.SetActive(false);
    		LockPT4.SetActive(false);
    		LockPT5.SetActive(false);
    		LockPT6.SetActive(false);
    		LockPT7.SetActive(false);
    		
    		peca1.SetActive(true);
    		peca2.SetActive(true);
    		peca3.SetActive(true);
    		peca4.SetActive(true);
    		peca5.SetActive(true);
    		peca6.SetActive(true);
    			
    	}
    	if (player.nivelconcluido == 7) {
    		LockPT2.SetActive(false);
    		LockPT3.SetActive(false);
    		LockPT4.SetActive(false);
    		LockPT5.SetActive(false);
    		LockPT6.SetActive(false);
    		LockPT7.SetActive(false);
    		LockPT8.SetActive(false);
    		
    		peca1.SetActive(true);
    		peca2.SetActive(true);
    		peca3.SetActive(true);
    		peca4.SetActive(true);
    		peca5.SetActive(true);
    		peca6.SetActive(true);
    		gasosa.SetActive(true);
    	}
    	if (player.nivelconcluido == 8) {
    		LockPT2.SetActive(false);
    		LockPT3.SetActive(false);
    		LockPT4.SetActive(false);
    		LockPT5.SetActive(false);
    		LockPT6.SetActive(false);
    		LockPT7.SetActive(false);
    		LockPT8.SetActive(false);
    		
    		peca1.SetActive(true);
    		peca2.SetActive(true);
    		peca3.SetActive(true);
    		peca4.SetActive(true);
    		peca5.SetActive(true);
    		peca6.SetActive(true);
    		gasosa.SetActive(true);
    		bateria.SetActive(true);
    	}
    	
    	
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
