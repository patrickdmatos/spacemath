using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
	
	public GameObject som_Ligado;
	public GameObject som_Desligado;
	public GameObject msc_Ligado;
	public GameObject msc_Desligado;
	
	int somligado = 1;
	int mscligada = 1;
	
	public void Start(){
		if(PlayerPrefs.HasKey("Som") || PlayerPrefs.HasKey("Musica")){
			somligado = PlayerPrefs.GetInt("Som");
			mscligada = PlayerPrefs.GetInt("Musica");
			ManterVolume();
			
		}
	}
	public void IniciarJogo() 
	{
		PlayerPrefs.SetInt ("Som", somligado);
    	PlayerPrefs.SetInt ("Musica", mscligada);
		SceneManager.LoadScene("Cena-Começo");
		
	}
	
	public void SairdoJogo()
	{
		PlayerPrefs.DeleteAll();
		Application.Quit();
	}
	
	public void som() {
		
		if (somligado == 1) {
			som_Ligado.SetActive(false);
			som_Desligado.SetActive(true);
			GetComponent<AudioSource>().Stop();
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
			GetComponent<AudioSource>().Stop();
			mscligada = 0;
		} else	{
			msc_Ligado.SetActive(true);
			msc_Desligado.SetActive(false);
			GetComponent<AudioSource>().Play();
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
