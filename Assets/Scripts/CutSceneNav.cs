using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneNav : MonoBehaviour
{
    public GameObject cena1;
    public GameObject cena2;
    public GameObject cena3;
    public GameObject cena4;
    public GameObject cena5;
    public GameObject cena6;
    public GameObject cena7;
    public GameObject cena8;
    public GameObject cena9;
    public GameObject cena10;
    public GameObject cena11;
    public GameObject cena12;
    public GameObject cena13;
    public GameObject cena14;
    public GameObject cena15;
    public GameObject cena16;
    
    GameObject currentscene;
    public int ncena = 1;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	
    	
    	if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape)){
    		//Pula td
    		Pulo();
    	}
    	if(Input.GetKeyDown(KeyCode.A) && ncena > 1){
    		anterior();
    	}
    	if(Input.GetKeyDown(KeyCode.D)){
    		//prox cena
    		proximo();
    	}
    	
  
    	if (ncena == 1){ currentscene = cena1;}
    	if (ncena == 2){ currentscene = cena2;}
    	if (ncena == 3){ currentscene = cena3;}
    	if (ncena == 4){ currentscene = cena4;}
    	if (ncena == 5){ currentscene = cena5;}
    	if (ncena == 6){ currentscene = cena6;}
    	if (ncena == 7){ currentscene = cena7;}
    	if (ncena == 8){ currentscene = cena8;}
    	if (ncena == 9){ currentscene = cena9;}
    	if (ncena == 10){ currentscene = cena10;}
    	if (ncena == 11){ currentscene = cena11;}
    	if (ncena == 12){ currentscene = cena12;}
    	if (ncena == 13){ currentscene = cena13;}
    	if (ncena == 14){ currentscene = cena14;}
    	if (ncena == 15){ currentscene = cena15;}
    	if (ncena == 16){ currentscene = cena16;}
    	if (ncena == 17){ Pulo();}
    	
    	currentscene.SetActive(true);
    }
    
    public void Pulo(){
    	SceneManager.LoadScene("fase0Portais");
    }
    public void proximo(){
    	ncena++;
    }
    
    public void anterior(){
    	currentscene.SetActive(false);
    		ncena--;
    }
    
   
}
