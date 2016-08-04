using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float time;
	public GameObject gameOverPanel;
	public Slider barraDeTempo;

	public Animator[] botoesAnim;

	public Button[] botõesGame;

	void Awake()
	{
		//time = 15.0f;
	}

	// Use this for initialization
	void Start () {
        barraDeTempo.maxValue = time;

		
	}
	
	// Update is called once per frame
	void Update () {
		ReduzTempo ();
	}

	void ReduzTempo()
	{
		if (time > 0.0f) {
			time -= Time.deltaTime;
			MudaBarra ();
		} else {
			DesabilitaBotões ();
			GameOver ();
		}
	}

	void GameOver()
	{
		for (int i = 0; i < botoesAnim.Length; i++) {
			botoesAnim[i].SetBool ("GameOver", true);
			StartCoroutine (ChamarGameOver ());
		}
	}

	public void MudaBarra()
	{
		barraDeTempo.value = time;
	}

	IEnumerator ChamarGameOver() {
		//print(Time.time);
		yield return new WaitForSeconds(2);
		gameOverPanel.SetActive (true);
	}

	public void DesabilitaBotões(){
		for(int i = 0; i < botõesGame.Length; i++)
		{
			botõesGame [i].enabled = false;
		}
	}
}
