using UnityEngine;
using System.Collections;

public class MatchManager : MonoBehaviour {

	GameManager gameManager;
	MatchButtonsManager buttonsManager;

	[Header("Animators")]
	public Animator like;
	public Animator dislike;

	[Header("Sistema de Match")]
	public int acertos;
	public int erros;
	public int numTentativas;
	public float porcDeAcertos;
	public int matchs;
	public int notMatchs;

	[Header("EfeitosSonoros")]
	public GameObject certo;
	public GameObject errado;

	[Header("Sistema de Vida")]
	public int vidas;

	[Header("Sistema de Pontos")]
	public int score;
	public int primeiroScore;
	public int acertoSeguidos;
	public int gold;
	public int goldTotal;

	void Awake()
	{
		CarregaGoldTotal ();
		gameManager = this.gameObject.GetComponent<GameManager> ();
		buttonsManager = GameObject.Find ("MatchButtonManager").GetComponent<MatchButtonsManager> ();
		ResetaAcertosSeguidos ();
	}

	//Função que verifica se deu match ou não
	public void TestarMatch(int opção)
	{
		numTentativas++;
		switch (opção) 
		{
		case 0: //caso em que o jogador clicou em Don't Match
			if (!gameManager.isMatch) {
				like.SetBool("acertou", true);
				StartCoroutine (ResetarLike ());
				SomaAcertos ();
				SomaNotMatchs ();
				SomaAcertosSeguidos ();
				CalculaPontos (1);
				CorrectSfx ();
			} else 
			{
				dislike.SetBool("errou", true);
				StartCoroutine(ResetarDislike());
				SomaErros ();
				SomaMatchs ();
				ResetaAcertosSeguidos ();
				CalculaPontos (2);
				WrongSfx ();
			}
			break;

		case 1: //caso em que o jogador clicou em Match
			if (gameManager.isMatch) {
				like.SetBool("acertou", true);
				StartCoroutine (ResetarLike ());
				SomaAcertosSeguidos ();
				SomaAcertos ();
				SomaMatchs ();
				CalculaPontos (1);
				CorrectSfx ();
			} else 
			{
				dislike.SetBool("errou", true);
				StartCoroutine(ResetarDislike());
				SomaErros ();
				SomaNotMatchs ();
				ResetaAcertosSeguidos ();
				CalculaPontos (2);
				WrongSfx ();
			}
			break;

		default:
			break;
		}



		// chama novas cores
		buttonsManager.MudarLado();
		gameManager.EscolheCorDoBloco ();
	}

	void SomaAcertos()
	{
		acertos++;
		CalculaPorcentagemDeAcertos ();
	}
	void SomaErros()
	{
		erros++;
		CalculaPorcentagemDeAcertos ();
	}
	void SomaMatchs()
	{
		matchs++;
	}
	void SomaNotMatchs()
	{
		notMatchs++;
	}

	void SomaAcertosSeguidos()
	{
		acertoSeguidos++;
	}

	void ResetaAcertosSeguidos()
	{
		acertoSeguidos = 1;
	}

	void CalculaPorcentagemDeAcertos()
	{
		porcDeAcertos = (acertos*100) / numTentativas;
	}

	void CalculaPontos(int acertou)
	{
		switch(acertou){
		case 1:
			if (score == 0) {
				score = primeiroScore;
			} else {
				score += ((score / 10) + primeiroScore);
				if (acertoSeguidos > 1) {
					score += (primeiroScore * acertoSeguidos);
				}
			}
		break;

		case 2:
			if (score == 0) {
				score = 0;
			} else {
				score -= ((score / 10) + primeiroScore) + (acertoSeguidos*primeiroScore);
			}
			break;
		}
	}

	public void CalculaGold()
	{
		gold = score / 10;
		AtualizaGoldTotal ();
		SalvaGold ();
	}

	IEnumerator ResetarLike()
	{
		print("resetou like");
		yield return new WaitForSeconds(0.5f);
		like.SetBool("acertou", false);
	}

	IEnumerator ResetarDislike()
	{
		print("resetou DESlike");
		yield return new WaitForSeconds(0.5f);
		dislike.SetBool("errou", false);
	}

	void CorrectSfx(){
		Instantiate (certo);
	}

	void WrongSfx(){
		Instantiate (errado);
	}

	void SalvaGold(){
		PlayerPrefs.SetInt ("Gold", goldTotal);
	}

	void CarregaGoldTotal(){
		goldTotal += PlayerPrefs.GetInt ("Gold",0);
	}

	void AtualizaGoldTotal(){
		goldTotal += gold;
	}
}
