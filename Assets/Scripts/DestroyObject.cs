using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {
	public float tempoDeVida;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, tempoDeVida);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
