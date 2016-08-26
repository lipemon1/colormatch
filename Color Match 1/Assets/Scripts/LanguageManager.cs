using UnityEngine;
using System.Collections;

public class LanguageManager : MonoBehaviour {

	public bool idiomaPortugues;
	public string nomePortugues;
	public string idiomaSistema;

	// Use this for initialization
	void Awake () {

		idiomaSistema = Application.systemLanguage.ToString ();

		if (idiomaSistema == nomePortugues) {
			idiomaPortugues = true;
		} else {
			idiomaPortugues = false;
		}
	}
}
