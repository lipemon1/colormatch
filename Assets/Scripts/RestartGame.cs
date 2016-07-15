using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	public Animator jogarDeNovoAnim;
	public GameObject bgm;

	void Awake(){
		bgm = GameObject.Find ("BGM");
	}

	public void Restart()
	{
		jogarDeNovoAnim.SetBool ("JogarDeNovo", true);
		StartCoroutine (Reiniciar ());
	}

	IEnumerator Reiniciar()
	{
		yield return new WaitForSeconds(2);

		Application.LoadLevel("game");

		//int scene = SceneManager.GetActiveScene().buildIndex;
		//SceneManager.LoadScene (scene);
	}

	IEnumerator IrMenu()
	{
		yield return new WaitForSeconds(2);
		Destroy (bgm);
		Application.LoadLevel("menu");

		//int scene = SceneManager.GetActiveScene().buildIndex;
		//SceneManager.LoadScene (scene);
	}

	public void IrParaMenu(){
		jogarDeNovoAnim.SetBool ("JogarDeNovo", true);
		StartCoroutine (IrMenu ());
	}
}
