using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public Text points;
	public Text accurace;
	public Text tries;
	public Text gold;
	public Text goldTotal;
	public MatchManager mm;
	public Button[] botoesGameOver;

	void Awake(){
		//mm = GameObject.Find ("GameManager").GetComponent<MatchManager> ();
		mm.CalculaGold ();
		points.text = mm.score.ToString();
		accurace.text = mm.porcDeAcertos.ToString() + "%";
		tries.text = mm.numTentativas.ToString();
		gold.text = mm.gold.ToString ();
		goldTotal.text = mm.goldTotal.ToString ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DesabilitaBotões(){
		for(int i = 0; i < botoesGameOver.Length; i++)
		{
			botoesGameOver [i].enabled = false;
		}
	}
}
