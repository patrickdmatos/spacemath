using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	
	//variaveis para controle de level;
	
		public int vidas; 		//variavel de controle da vida;
		public Text TextVidas; 		//Objeto de UI de saida, onde atualiza o valor na tela;
		public int moedas;
		public Text TextMoedas;
		
		public int nivelconcluido = 0;
		
	
		int nportal = 0; 	//n° do portal que ele esta colidindo para viajar;
		bool estanoportal = false; 	//true quando Player colidir com algum portal;
		bool teleporting = false;		//true quando apertado a tecla para viajar;
		public GameObject mensagemViagem;  //Objeto UI, Para confirmar viagem;
		
		bool estavivo = true;
		bool ivuneravel = false; 
		public GameObject ultimoCheckpoint;
		
		string nomecenaAtual;
		
		public GameObject painelTransic;
		private Animator transicoes;

		
	//Variaveis para os controles do personagem;
			
										//Componentes do Objeto Player chamados;
		private Rigidbody2D body;
		private SpriteRenderer sprite;
		private Animator anim;
											
		public float speed = 10f; 			//Força de velocidade do eixo X;
		public float jumpForce = 200f; 		//Força de pulo eixo Y;
		
		public Transform groundCheck;	//Objeto que fica nos pés do player, usando a função LineCast do Unit para ver se esta no chão; 
		public LayerMask whatIsGround;	//Variavel Para indicar os Objetos considerados como Chão;
		bool isJumping = false; 	//verifica se esta no ar Para nao haver Pulo Infinito;
		bool isOnFloor = false;		//Verifica se esta no chão Para poder realizar um pulo;
		
		
		//Variaveis para o Audio;
		public AudioSource son_pegandomoedas;
		public AudioSource son_pulando;
		public AudioSource son_caminhando;
		public AudioSource son_morrendo;
		
		void Awake()
		{
			nomecenaAtual = SceneManager.GetActiveScene().name;
		}
		
	
    // Start é chamada no Primeito Frame do Jogo;    Nativa do unity;
    void Start()
		    {
    				if(PlayerPrefs.HasKey(nomecenaAtual + "X") && PlayerPrefs.HasKey(nomecenaAtual + "Y"))
    	   			{
    	   				transform.position = new Vector2(PlayerPrefs.GetFloat (nomecenaAtual + "X"), PlayerPrefs.GetFloat (nomecenaAtual + "Y"));
    	   			}
    				
    				if(PlayerPrefs.HasKey("VidasP1") && PlayerPrefs.HasKey("MoedasP1") && PlayerPrefs.HasKey("Nivel")) {
    					vidas = PlayerPrefs.GetInt("VidasP1");
    					moedas = PlayerPrefs.GetInt("MoedasP1");
    					nivelconcluido = PlayerPrefs.GetInt("Nivel");
    				}
		    	body = GetComponent <Rigidbody2D> ();
		    	sprite = GetComponent <SpriteRenderer> ();
		    	anim = GetComponent <Animator> ();
		    	transicoes = painelTransic.GetComponent <Animator>();
		    	transicoes.Play("StartScene");
		    }

    // Update é chamada a cada Frame do Jogo, Ou seja tudo que acontece aqui é em tempo quase real;
    		//Utilizada Para Inputs, e Logica em Geral;  Nativa do Unity;  Depende do n° de fps;
    void Update()
		    {		
		    	
		    	isOnFloor = Physics2D.Linecast (transform.position, groundCheck.position, whatIsGround);
		    	if (Input.GetButtonDown ("Jump") && isOnFloor == true) {
		    	    isJumping = true;
		    	    son_pulando.Play();
		    	}
		    	PlayerAnimation();
		    	TextMoedas.text = moedas.ToString();
		    	TextVidas.text = vidas.ToString();
		    	
		    	if (Input.GetButtonDown ("Submit"))
		    	{	
		    		teleporting = true;
		    	}
		    	
		    	if (Input.GetButtonUp ("Submit"))
		    	{
		    		teleporting = false;
		    	} 	
		    	
		    	teleporte();
		    }
    
    void PlayerAnimation() 
	    	{
		    	if (estavivo == false){ 
		    		anim.Play("dye");
		    	} else {
					    	if (body.velocity.x == 0 && body.velocity.y == 0 && isOnFloor == true) {
					    		anim.Play ("idle");
					    	} else if (body.velocity.x != 0 && isOnFloor == true) {
					    		anim.Play("walk");
					    		
					    	} else if (body.velocity.y != 0 && isOnFloor == false) {
					    		anim.Play("jump");
					    	}
		   				}
	    	}
    
     void teleporte() 
		    {
		    	
		    	if (teleporting == true && estanoportal == true)
			    	{
		    		SalvarLoca();
		    		SalvarInformacoes();
		    		    		
			    		if (nportal == 0) { UnityEngine.SceneManagement.SceneManager.LoadScene("fase0Portais"); }
			    		if (nportal == 1) { UnityEngine.SceneManagement.SceneManager.LoadScene("fase1"); }
			    		if (nportal == 2 && nivelconcluido >=2) { UnityEngine.SceneManagement.SceneManager.LoadScene("fase2"); }
			    		if (nportal == 3 && nivelconcluido >=3) { UnityEngine.SceneManagement.SceneManager.LoadScene("fase3"); }
			    		if (nportal == 4 && nivelconcluido >=4) { UnityEngine.SceneManagement.SceneManager.LoadScene("fase4"); }
			    		if (nportal == 5 && nivelconcluido >=5) { UnityEngine.SceneManagement.SceneManager.LoadScene("fase5"); }
			    		if (nportal == 6 && nivelconcluido >=6) { UnityEngine.SceneManagement.SceneManager.LoadScene("fase6"); }
			    		if (nportal == 7 && nivelconcluido >=7) { UnityEngine.SceneManagement.SceneManager.LoadScene("fase7"); }
			    		if (nportal == 8 && nivelconcluido >=8) { UnityEngine.SceneManagement.SceneManager.LoadScene("fase8"); }
			    	}
			}
    
    void flip() 
		    {
		    	sprite.flipX = !sprite.flipX;
		    }
    
    void FixedUpdate() 
		    {
		    	
		    	if(estavivo == true)
		    	{
			    	float move = Input.GetAxis("Horizontal");
			    	body.velocity = new Vector2 (move * speed, body.velocity.y);
			    	if ((move > 0 && sprite.flipX == true) || (move < 0 && sprite.flipX == false)) {
			    		flip();
					
			    	}
			    	
			    	if (isJumping) {
			    		body.AddForce(new Vector2 (0f, jumpForce));
			    		isJumping = false;	
			    	}
		    	}
		    }
    
    void OnTriggerEnter2D(Collider2D collision2D) 
		    {
		    	
		    	Debug.Log("Colidiu c a tag "+collision2D.gameObject.tag);
		    	if (collision2D.gameObject.CompareTag("Moedas")) {
		    		Destroy(collision2D.gameObject);
		    		Debug.Log("pegou uma moeda");
		    		son_pegandomoedas.Play();
		    		moedas++;
		    	} 
		    	
		    	if (collision2D.gameObject.CompareTag("Armadilhas")) {
		    		Debug.Log("perdeu uma vida e voltou pro spawn");
		    		if (estavivo == true && ivuneravel == false) {
		    			Invoke("respawn", 1.5f);
		    			son_morrendo.Play();
		    			vidas--;
		    			estavivo = false;
		    			ivuneravel = true;
		    		
		    		if(vidas <= 0) {
		    				GameOver();
		    			UnityEngine.SceneManagement.SceneManager.LoadScene("fase0Portais");
		    		}}
		    	}
		    		
		    	
		    	if (collision2D.gameObject.CompareTag("CheckPoint")) {
		    		ultimoCheckpoint = collision2D.gameObject;
		    	}
		    	
		    	if (collision2D.gameObject.CompareTag("Baus")) {
		    		Debug.Log("Abriu a pergunta de matematica");
		    		
		    	}
		    	
		    	if (collision2D.gameObject.CompareTag("Portais")) 
		    	{
		    		Debug.Log("Aperte f para entrar");
		    		estanoportal = true;
		    		
		    			if (collision2D.gameObject.name == ("Portal0")) { nportal = 0; }
			    		if (collision2D.gameObject.name == ("Portal1")) { nportal = 1; }
			    		if (collision2D.gameObject.name == ("Portal2")) { nportal = 2; }
			    		if (collision2D.gameObject.name == ("Portal3")) { nportal = 3; }
			    		if (collision2D.gameObject.name == ("Portal4")) { nportal = 4; }
			    		if (collision2D.gameObject.name == ("Portal5")) { nportal = 5; }
			    		if (collision2D.gameObject.name == ("Portal6")) { nportal = 6; }
			    		if (collision2D.gameObject.name == ("Portal7")) { nportal = 7; }
			    		if (collision2D.gameObject.name == ("Portal8")) { nportal = 8; }
			    		
			    		if(nivelconcluido >= nportal || nportal - 1 == nivelconcluido ){
		    				mensagemViagem.SetActive(true);
			    		}
		    	
		    	}
		    }
    
    void respawn()
		    {
		    	transform.position = ultimoCheckpoint.transform.position;
		    	estavivo = true;
		    	ivuneravel = false;
		    	
		    }
    void SalvarLoca()
    {
    	PlayerPrefs.SetFloat (nomecenaAtual + "X", transform.position.x);
    	PlayerPrefs.SetFloat (nomecenaAtual + "Y", transform.position.y);
    }
    
    void SalvarInformacoes()
    {
    	PlayerPrefs.SetInt ("VidasP1", vidas);
    	PlayerPrefs.SetInt ("MoedasP1", moedas);
    	PlayerPrefs.SetInt ("Nivel", nivelconcluido);
    	
    }
    
    void GameOver(){
    	PlayerPrefs.DeleteAll();
    	
    }
    
    void OnTriggerExit2D(Collider2D saiu)
		    {
		    	if (saiu.gameObject.CompareTag("Portais")) {
		    		estanoportal = false;
		    		mensagemViagem.SetActive(false);
		    		Debug.Log("saiu do portal");
		    	}
		    }
	public void OnCollisionEnter2D(Collision2D collision){
		if(collision.transform.tag == "PlataformasAndantes"){
			transform.parent = collision.transform;	
		}
	}

	public void OnCollisionExit2D(Collision2D collision){
		if(collision.transform.tag == "PlataformasAndantes"){
			transform.parent = null;	
		}
	}		
    
	}
