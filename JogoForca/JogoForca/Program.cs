using System;
using System.Collections;
using System.Threading;

namespace JogoForca
{
    internal class Program
    {
        static ArrayList letrasTentadas = new ArrayList();
        static ArrayList palavraCaracteres = new ArrayList();
        static int acertos = 0;
        static void Main(string[] args)
        {
            string palavra = "";
            Console.WriteLine("Seja bem vindo ao jogo da forca!");
            Console.WriteLine("Vamos começar a jogar...");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Você tem 6 chances para acertar a palavra!");
                Console.WriteLine();
                int tentativas = 6;
                string letra = "";
                 palavra = sorteioPalavra(); //palavra selecionada
                caracteres(palavra); //mostrar a quantidade de caracteres
                while (tentativas > 0)
                {
                    while (true)
                    {
                        Console.Write("Letras tentadas: ");
                        foreach (string caracter in letrasTentadas)
                        {
                            Console.Write(caracter + " ");
                        }
                        Console.WriteLine();
                        Console.Write("Qual letra você acha que a palavra tem? ");
                        letra = Console.ReadLine().ToLower();
                        bool res = verificaLetra(letra);
                        if (res)
                        {
                            letrasTentadas.Add(letra);
                            break;
                        }
                    }
                    tentativas = letraPalavra(palavra, letra, tentativas);
                    Console.WriteLine();
                    if (tentativas == 1000)
                    {
                        Console.WriteLine("Parabens você venceu!!!");
                        Console.ReadKey();
                        return;
                    }
                }
                break;
            }
            Console.WriteLine($"Você perdeu! A palavra era {palavra}");
            Console.ReadKey();
        }
        static int letraPalavra(string palavra, string letra, int chances)
        {
            /*
             Verificar se a letra está na palavra
             */
            bool acertou = false;
            int cont = 1;
            foreach(char caracter in palavra)
            {
                if (caracter.ToString() == letra) //letra correta
                {
                    acertou = true;
                    acertos++;
                    Console.WriteLine($"Parabens! Você acertou uma letra na posição {cont}");
                    palavraCaracteres.RemoveAt(cont - 1);
                    palavraCaracteres.Insert(cont - 1, letra);
                    foreach(string letraPos in palavraCaracteres)
                    {
                        Console.Write(letraPos + " ");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                }
                cont++;
            }
            if (acertos == palavra.Length)
            {
                chances = 1000;
                return chances; //se chances == 1000 é vitória
            }
            if (!acertou)
            {
                chances--;
                Console.WriteLine($"Você errou a letra!\nVocê ainda possui {chances} chances");
                return chances;
            }
            else{
                return chances;
            }
        }
        static bool verificaLetra(string letra)
        {
            /*
             Verificar o que foi digitado
             */
            foreach(string caracter in letrasTentadas)
            {
                if(caracter == letra)
                {
                    Console.WriteLine("Essa letra já foi digitada!");
                    Console.WriteLine();
                    return false;
                }
            }
            if (letra.Length > 1 || letra.Length < 1) //tamanho do que foi digitado
            {
                Console.WriteLine("Você digitou algo errado!");
                Console.WriteLine();
                return false;
            }
            return true;
        }
        static string sorteioPalavra()
        {
            /*
             Sortear a palavra do jogo e retorna-la
             */
            Console.WriteLine("Sorteando a palavra..");
            string[] palavras = { "carro", "carteira", "livro", "computador", "impressora", "gaveta" }; //palavras do jogo
            //Sortear palavra
            Random sortear = new Random();
            int posicao = sortear.Next(palavras.Length); //retorna um índice do array de palavras
            string palavra = palavras[posicao]; //palavra selecionada

            return palavra;
        } 
        static void caracteres(string palavra)
        {
            /*
             Quantidade de caractres da palavra
             */
            int cont = 0;
            Thread.Sleep(1200);
            Console.WriteLine($"A palavra sorteada tem: {palavra.Length} letras");
            for(int a = 1; a <= palavra.Length; a++)
            {
                //palavraCaracteres = palavraCaracteres + "_ ";
                palavraCaracteres.Insert(cont, "_");
                Console.Write("_ ");
                Thread.Sleep(500);
                cont++;
            }
            Console.WriteLine();
        }
    }
}