using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LanguageItem : MonoBehaviour {

	public LanguageManager lm;
	public Text textoMostrado;
	public string textoIngles;
	public string textoPortugues;

	// Use this for initialization
	void Start () {
		MudarTexto ();
	}

	void MudarTexto(){
		if (lm.idiomaPortugues) {
			textoMostrado.text = textoPortugues;
		} else {
			textoMostrado.text = textoIngles;
		}
	}
}
