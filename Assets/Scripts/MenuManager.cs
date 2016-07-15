using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public Animator menuAnim;

	public void Tutorial(){
		menuAnim.SetTrigger("SairMenu");
		//Application.LoadLevel ("tuto");
		//SceneManager.LoadScene ("tuto");
		StartCoroutine(SairMenu("tuto"));
	}

	public void Jogar(){
		menuAnim.SetTrigger("SairMenu");
		//Application.LoadLevel ("game");
		//SceneManager.LoadScene ("game");
		StartCoroutine(SairMenu("game"));
	}

	IEnumerator SairMenu(string cena)
	{
		yield return new WaitForSeconds(2);

		switch (cena) {
		case "game":
			Application.LoadLevel("game");
			break;
		case "tuto":
			Application.LoadLevel("tuto");
			break;
		}

		//int scene = SceneManager.GetActiveScene().buildIndex;
		//SceneManager.LoadScene (scene);
	}
}
