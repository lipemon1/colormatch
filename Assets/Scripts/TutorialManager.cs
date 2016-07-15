using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {
	public Animator botaoAprender;
	public Animator tutorial;
	public GameObject bgm;
	public bool clicouAprender;

	void Awake(){
		bgm = GameObject.Find ("BGM");
	}

	void Update(){

	}

	public void ClicouParaAprender(){
		botaoAprender.SetTrigger ("ciclouAprender");

	}

	public void Entendeu(){
		Destroy (bgm);
		Application.LoadLevel ("menu");
		//SceneManager.LoadScene ("menu");
	}

	public void NaoEntedeu(){
		Application.LoadLevel ("tuto");
		//SceneManager.LoadScene ("tuto");
	}
}
