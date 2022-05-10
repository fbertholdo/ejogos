using EJOGOS.Interface;
using System.Collections.Generic;
using System.IO;

namespace EJOGOS.Models
{

    //Herança 

    public class Equipe : EquipeBase, IEquipe

    {
        public int idEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }


        //variavel de dados
        private const string caminhobd = "Database/equipe.csv";
        private IEnumerable<string> equipe_texto;

        public Equipe()
            
        {
            //metodo da classe de herança EquipeBase
            CriarPastaOuAqrquivo(caminhobd);
        }

        //Criar uma função que vai recebr o objeto EQUIPE e vai retornar no formato de CSV (STRING)

        private string Preparar(Equipe e)
        {
            // return e.idEquipe + ";" + e.Nome + ";" e.Imagem;

            return $"{e.idEquipe};{e.Nome};{e.Imagem}";
        }



        public void Criar(Equipe novaequipe)
        {
            //array de string = na posição 0 temos o retorno do "Preparar".
            string[] equipe_texto = { Preparar(novaequipe) };
            
            //arquivo camos adicionar uma nova linha
            //caminho do arquivo, string em formato array
            File.AppendAllLines(caminhobd, equipe_texto);

        }

        public List<Equipe> LerEquipes()
        {
            List<Equipe> listaEquipes = new List<Equipe>();

            //ler todas as linhas do arquivo CSV, armazenar em uma array;
            string[] linhas = File.ReadAllLines(caminhobd);

            foreach (string item in linhas)
            {
                //1; nome da equipe; caminho da imagem

                string[] linhaEquipe=item.Split(';');

                Equipe equipeAtual = new Equipe();
                equipeAtual.idEquipe = int.Parse(linhaEquipe[0]);
                equipeAtual.Nome = linhaEquipe[1];
                equipeAtual.Imagem = linhaEquipe[2];

                listaEquipes.Add(equipeAtual);
            }
            return listaEquipes;
        }
    }
}
