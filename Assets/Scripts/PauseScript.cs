using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseScript : MonoBehaviour
{
	public GameObject btnPause;
	public GameObject pauseMenu;
	public GameObject som_Ligado;
	public GameObject som_Desligado;
	public GameObject msc_Ligado;
	public GameObject msc_Desligado;
	public AudioSource Musica;
	
	
	
	
	int somligado = 1;
	int mscligada = 1;
	
	public void Start(){
		if(PlayerPrefs.HasKey("Som") || PlayerPrefs.HasKey("Musica")){
			somligado = PlayerPrefs.GetInt("Som");
			mscligada = PlayerPrefs.GetInt("Musica");
			ManterVolume();
			
		}
	}
	
	public void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Pause();
		}
	}
	
	public void Pause()
	{
		if (Time.timeScale == 1) 
		{
			Time.timeScale = 0;
			btnPause.SetActive(false);
			pauseMenu.SetActive(true);
			
		} else {
		
			Time.timeScale = 1;
			btnPause.SetActive(true);
			pauseMenu.SetActive(false);
			
		}
	}
    
	public void VoltarpMenu() 
	{	
		PlayerPrefs.SetInt ("Som", somligado);
    	PlayerPrefs.SetInt ("Musica", mscligada);
		Time.timeScale = 1;
		SceneManager.LoadScene("Menu");
	}
	
	public void SairdoJogo()
	{
		Application.Quit();
	}
	
	public void som() {
		
		if (somligado == 1) {
			som_Ligado.SetActive(false);
			som_Desligado.SetActive(true);
			//Player.son_pegandomoedas.Stop();
			somligado = 0;
		} else { 
			som_Ligado.SetActive(true);
			som_Desligado.SetActive(false);
			GetComponent<AudioSource>().Play();
			somligado = 1;
			
		}
	}
	
	public void musica() {
		
		if (mscligada == 1) {
			msc_Ligado.SetActive(false);
			msc_Desligado.SetActive(true);
			Musica.Stop();
			mscligada = 0;
		} else	{
			msc_Ligado.SetActive(true);
			msc_Desligado.SetActive(false);
			Musica.Play();
			mscligada = 1;
		}
	
	}
	
	public void ManterVolume(){
		if (mscligada == 1) {
			msc_Ligado.SetActive(true);
			msc_Desligado.SetActive(false);
			GetComponent<AudioSource>().Play();
			mscligada = 1;
		} else	{
			msc_Ligado.SetActive(false);
			msc_Desligado.SetActive(true);
			GetComponent<AudioSource>().Stop();
			mscligada = 0;
		}
		
		if (somligado == 1) {
			som_Ligado.SetActive(true);
			som_Desligado.SetActive(false);
			GetComponent<AudioSource>().Play();
			somligado = 1;
		} else { 	
			som_Ligado.SetActive(false);
			som_Desligado.SetActive(true);
			GetComponent<AudioSource>().Stop();
			somligado = 0;
		}
	}
	
	
}
