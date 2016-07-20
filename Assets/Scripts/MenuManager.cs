using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public Animator menuAnim;
	public GameObject painelInfo;

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

	public void AbrirInfo(){
		menuAnim.SetTrigger ("ClicouInfo");
	}

	public void SairInfo(){
		menuAnim.SetTrigger ("SaiuInfo");
		StartCoroutine (FecharInfo ());
	}

	IEnumerator FecharInfo()
	{
		yield return new WaitForSeconds(1);
		painelInfo.SetActive (false);
	}
}
