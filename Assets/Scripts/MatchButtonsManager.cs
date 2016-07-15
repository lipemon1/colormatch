using UnityEngine;
using System.Collections;

public class MatchButtonsManager : MonoBehaviour {

	public int ladoAtivo;

	public GameObject[] lados;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		VerificaQualLadoEstaAtivo ();
	}

	void VerificaQualLadoEstaAtivo()
	{
		if (ladoAtivo == 0) {
			lados [0].SetActive (true);
			lados [1].SetActive (false);
		} else {
			lados [1].SetActive (true);
			lados [0].SetActive (false);
		}
	}

	public void MudarLado()
	{
		print ("mudou");
		ladoAtivo = (int)Random.Range(0,lados.Length);
	}
}
