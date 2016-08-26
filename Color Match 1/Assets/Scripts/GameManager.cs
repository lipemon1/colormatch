using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[System.Serializable]
	public class Textos
	{
		public int id;
		public string nomeDaCor;
		public string nomeDaCor_PTBR;
	}

	[System.Serializable]
	public class Cores
	{
		public int id;
		public Color cor;
	}

	[System.Serializable]
	public class ComponenteDeCor
	{
		public int idTexto;
		public int idCorDoTexto;
		public Textos nomeDeCor;
		public Cores cor;
		public Text texto;
		public Color corDoTexto;
	}

	[Header("Idiomas")]
	public LanguageManager lm;

	[Header("Sistema de Cores")]
	public Textos[] listaDeNomes;
	public Cores[] listaDeCores;
	public ComponenteDeCor[] blocos;
	public bool isMatch;
	[Space(20)]

	[Header("Configurações")]
	[Range(2,8)]
	public int númeroDeCores;
	float numeroDeCores;

	// Use this for initialization
	void Awake(){
		numeroDeCores = númeroDeCores * 1;
		ConferirIDs ();
		EscolheCorDoBloco ();

	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Função apenas para garantir que a lista de cores e a lista de nomes de cores fique com identificação iguais.
	void ConferirIDs()
	{
		for (int i = 0; i < listaDeNomes.Length; i++) 
		{
			listaDeNomes [i].id = i;
			listaDeCores[i].id = listaDeNomes [i].id;
		}
	}

	//pega a cor a partir do texto para conferir se é a mesma guardada no bloco, apenas para conferencia
	void ConfereCorTexto()
	{
		blocos[0].corDoTexto = blocos[0].texto.color;
		blocos[1].corDoTexto = blocos[1].texto.color;
	}

	//todo o sistema de escolha de cores e configurações de nome de cores
	public void EscolheCorDoBloco()
	{
		for (int bloco = 0; bloco < blocos.Length; bloco++) {

			//aqui é escolhida um número que será utilizado utilizada para pegar a cor do texto
			int idTextoEscolhido = (int)Random.Range (0, numeroDeCores);
			blocos [bloco].idCorDoTexto = idTextoEscolhido;

			//aqui é escolhida um número que será utilizado utilizada para pegar a string do texto
			int idCorEscolhida = (int)Random.Range (0, numeroDeCores);
			blocos [bloco].idTexto = idCorEscolhida;

			//aqui estou setando o texto de acordo com o identificador de texto escolhido
			blocos [bloco].nomeDeCor.id = idTextoEscolhido;
			if(lm.idiomaPortugues){
				blocos [bloco].nomeDeCor.nomeDaCor = listaDeNomes [idTextoEscolhido].nomeDaCor_PTBR;
			} else {
				blocos [bloco].nomeDeCor.nomeDaCor = listaDeNomes [idTextoEscolhido].nomeDaCor;
			}
			blocos [bloco].texto.text = blocos [bloco].nomeDeCor.nomeDaCor;

			//aqui estou setando a cor de acordo com o identificador de cor escolhido
			blocos [bloco].cor.id = idCorEscolhida;
			blocos [bloco].cor.cor = listaDeCores [idCorEscolhida].cor;
			//passando as cores para o texto
			blocos [bloco].texto.color = new Color(blocos [bloco].cor.cor.r, blocos [bloco].cor.cor.g,blocos [bloco].cor.cor.b);
			ConfereCorTexto();
		}

		//verificar se as cores dão match ou não
		isMatch = VerificaMatch ();
	}


	//Função irá verificar se o match está correto ou não.
	public bool VerificaMatch(){
		bool matched;

        //verifica se a cor do texto do segundo é a que esta escrita no primeiro
        if (blocos[1].idTexto == blocos[0].idCorDoTexto)
        {
            matched = true;
        }
        else
        {
            matched = false;
        }

        //esse aqui verifica se os dois combinam, vamos usar para niveis mais dificeis
        /*if (blocos [0].idTexto == blocos [1].idCorDoTexto & blocos[1].idTexto == blocos[0].idCorDoTexto) {
			matched = true;
		} else {
			matched = false;
		}*/

        return matched;
	}
}
