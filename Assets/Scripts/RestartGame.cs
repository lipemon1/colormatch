using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	public Animator jogarDeNovoAnim;
	public bool fecharGameOver;
	public GameObject bgm;
    public GameObject gameoverPanel;

	void Awake(){
		bgm = GameObject.Find ("BGM");
        FecharTelaGameOver();
	}

    void FecharTelaGameOver() {
		if (fecharGameOver) {
			gameoverPanel.SetActive (false);
		}
    }

	public void Restart()
	{
		jogarDeNovoAnim.SetBool ("JogarDeNovo", true);
		StartCoroutine (Reiniciar ());
	}

	IEnumerator Reiniciar()
	{
		yield return new WaitForSeconds(2);

		//Application.LoadLevel("game");

		//int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene ("game");
	}

	IEnumerator IrMenu()
	{
		yield return new WaitForSeconds(2);
		Destroy (bgm);
		//Application.LoadLevel("menu");

		//int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene ("menu");
	}

	public void IrParaMenu(){
		jogarDeNovoAnim.SetBool ("JogarDeNovo", true);
		StartCoroutine (IrMenu ());
	}
}
