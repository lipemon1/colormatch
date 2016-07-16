using UnityEngine;
using System.Collections;

public class TutoManager : MonoBehaviour {

	public int telaAtual;
	public Animator tutorialAnim;
	public GameObject bgm;

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

	public void IrParaMenu(){
		tutorialAnim.SetTrigger ("SairTutorial");
		StartCoroutine (IrMenu ());
	}

	IEnumerator IrMenu()
	{
		yield return new WaitForSeconds(1.5F);
		Destroy (bgm);
		Application.LoadLevel("menu");
		
		//int scene = SceneManager.GetActiveScene().buildIndex;
		//SceneManager.LoadScene (scene);
	}
}
