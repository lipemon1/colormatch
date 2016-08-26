using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutoManager : MonoBehaviour {

	public int telaAtual;
	public Animator tutorialAnim;
	public GameObject bgm;
	public Button esquerda;
	public Button direita;

	void Awake(){
		bgm = GameObject.Find ("BGM");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MudarTelaDireita(){
		telaAtual++;
		tutorialAnim.SetInteger ("TelaAtiva", telaAtual);
	}

	public void MudarTelaEsquerda(){
		telaAtual--;
		tutorialAnim.SetInteger ("TelaAtiva", telaAtual);
	}

	public void DesabilitarDirecionais(){
		direita.interactable = false;
		esquerda.interactable = false;
		StartCoroutine (HabilitarDirecionais ());
	}

	IEnumerator HabilitarDirecionais()
	{
		yield return new WaitForSeconds(1.0F);
		direita.interactable = true;
		esquerda.interactable = true;
	}

	public void IrParaMenu(){
		tutorialAnim.SetTrigger ("SairTutorial");
		StartCoroutine (IrMenu ());
	}

	IEnumerator IrMenu()
	{
		yield return new WaitForSeconds(1.5F);
		Destroy (bgm);
		//Application.LoadLevel("menu");
		
		//int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene ("menu");
	}
}
