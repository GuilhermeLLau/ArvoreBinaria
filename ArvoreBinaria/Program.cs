using System;

namespace ArvoreBinaria
{
    class Arvore
    {
        public Arvore()
        { 
            info = 0; 
            sae = sad = null; 
        }
        public void Insere(int n, ref Arvore RAIZ)
        {
            Arvore temp, subarv;
            this.info = n;
            if (RAIZ == null) RAIZ = this;
            else
            {
                temp = RAIZ;
                while (temp != null)
                { 
                    subarv = temp; 
                    if (n <= temp.info) 
                    { 
                        temp = temp.sae; 
                        if (temp == null) subarv.sae = this; 
                    } 
                    else 
                    { 
                        temp = temp.sad; 
                        if (temp == null) subarv.sad = this; 
                    } 
                }
            }
        }
        public Arvore FindMax(Arvore node)
        {
            while(node.sae != null)
            {
                node = node.sae;
            }
            return node;
        }
        public void Remove(int n)
        {
            if(n < this.info)
            {
                if(this.sae.info == n && this.sae.sae == null && this.sae.sad == null)
                {
                    this.sae = null;
                }
                else if(this.sae.info == n && this.sae.sae != null && this.sae.sad == null)
                {
                    this.sae = this.sae.sae;
                }
                else if (this.sae.info == n && this.sae.sae == null && this.sae.sad != null)
                {
                    this.sae = this.sae.sad;
                }
                else
                {
                this.sae.Remove(n);
                }
            }
            else if(n > this.info)
            {
                if(this.sad.info == n && this.sad.sae == null && this.sad.sad == null)
                {
                    this.sad = null;
                }else if (this.sad.info == n && this.sad.sad != null && this.sad.sae == null)
                {
                    this.sad = this.sad.sad;
                }
                else if (this.sad.info == n && this.sad.sad == null && this.sad.sae != null)
                {
                    this.sad = this.sad.sae;
                }
                else
                {
                this.sad.Remove(n);
                }
            }else
            {
                Arvore aux = null; 
                while (this.sae != null)
                {
                    aux = this.sae;
                }
                this.info = aux.info;
                Remove(aux.info);
            }
           
        }
        public int Pesquisa(int n) 
        { 
            Arvore temp = this; 
            int nivel, achou; 
            nivel = achou = 0; 
            while (temp != null && achou == 0) 
            { 
                if (n == temp.info) achou = 1; 
                else 
                { 
                    if (n <= temp.info) temp = temp.sae; 
                    else temp = temp.sad; nivel++; 
                } 
            } 
            if (achou == 1) return (nivel); 
            else 
                return (-1); 
        }
        public void MostraArvorePreOrdem() 
        { 
            Console.Write("{0} ", this.info); 
            if (this.sae != null) (this.sae).MostraArvorePreOrdem(); 
            if (this.sad != null) (this.sad).MostraArvorePreOrdem(); 
        }
        public void MostraArvoreOrdemSimetrica() 
        { 
            if (this.sae != null) (this.sae).MostraArvoreOrdemSimetrica(); 
            Console.Write("{0} ", this.info); 
            if (this.sad != null) (this.sad).MostraArvoreOrdemSimetrica(); 
        }
        public void MostraArvorePosOrdem() 
        { 
            if (this.sae != null) (this.sae).MostraArvorePosOrdem(); 
            if (this.sad != null) (this.sad).MostraArvorePosOrdem(); 
            Console.Write("{0} ", this.info); 
        }
        private int info; 
        Arvore sae; 
        Arvore sad;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Arvore RAIZ = null;
            Arvore arv; int n, escolha, resultado, maiornivel, nivelsa;
            do
            {
                Console.Clear();
                Console.WriteLine(" Menu Principal");
                Console.WriteLine("(1) - Insere um elemento na Árvore");
                Console.WriteLine("(2) - Pesquisa um elemento na Árvore");
                Console.WriteLine("(3) - Lista Arvore - Pré-Ordem");
                Console.WriteLine("(4) - Lista Arvore - Ordem Simétrica");
                Console.WriteLine("(5) - Lista Arvore - Pos-Ordem");
                Console.WriteLine("(6) - Lista Arvore - Em Ordem");
                Console.WriteLine("(7) - Calcula Maior Nivel");
                Console.WriteLine("(8) - Remove um elemento na Árvore");
                Console.WriteLine("(9) - Para SAIR");
                escolha = int.Parse(Console.ReadKey(true).KeyChar.ToString());
                switch (escolha)
                {
                    case 1:
                        Console.Clear();
                        arv = new Arvore();
                        Console.Write("Entre com um numero : ");
                        n = int.Parse(Console.ReadLine());
                        arv.Insere(n, ref RAIZ);
                        break;
                    case 2:
                        Console.Clear();
                        if (RAIZ == null) Console.Write("Árvore Vazia");
                        else
                        {
                            Console.Write("Entre com um numero : ");
                            n = int.Parse(Console.ReadLine());
                            resultado = RAIZ.Pesquisa(n);
                            if (resultado == -1) Console.Write("Numero nao encontrado na Árvore!");
                            else Console.Write("Numero existe no nível {0} ", resultado);
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        if (RAIZ == null) Console.Write("Arvore não possui elementos!");
                        else RAIZ.MostraArvorePreOrdem();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        if (RAIZ == null) Console.Write("Arvore não possui elementos!");
                        else RAIZ.MostraArvoreOrdemSimetrica();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        if (RAIZ == null) Console.Write("Arvore não possui elementos!");
                        else RAIZ.MostraArvorePosOrdem();
                        Console.ReadKey();
                        break;
                    case 8: 
                        Console.Clear();
                        if (RAIZ == null) Console.Write("Arvore não possui elementos!");
                        else
                        {
                            Console.Write("Entre com um número : ");
                            n = int.Parse(Console.ReadLine());
                            RAIZ.Remove(n);
                        }
                        Console.ReadKey();
                        break;
                }
            } while (escolha != 9);
        }
    }
}
//Remove sad;
//Remove sae;
//public int info { get; set; }

//public Remove()
//{
//    sad = null;
//    sae = null;
//    info = 0;
//}

//public int num;
//public int AtribuirNum { set { this.num = value; } }
//public int RetornaNum { get { return (this.num); } }

//public Remove BuscaMaiorEsquerda()
//{
//    Remove aux = this;
//    while (aux.sae != null)
//    {
//        aux = aux.sad.BuscaMaiorEsquerda();
//    }
//    return aux;
//}

//public void RemoveDaArvore()
//{
//    Remove NoSucessor = null;
//    if (this.sad.info = num)
//    {
//        if ((this.sad.sad) = null && ((this.sad.sae) = null))
//        {
//            this.sad = null;
//        }
//        if (this.sad.sad != null) && ((this.sad.sae) == null) {
//            this.sad = this.sad.sad;
//        }
//        if ((this.sad.sad) != null) && ((this.sad.sae) != null){
//            NoSucessor = this.sae.BuscaMaiorEsquerda();

//        }


//    }
//    if (this.sae.info = num)
//    {
//        if ((this.sae.sad) = null && ((this.sae.sae) = null))
//        {
//            this.sae = null;
//        }
//        if (this.sae.sad != null) && ((this.sae.sae) == null) {
//            this.sae = this.sae.sae;
//        }

//    }

//    if (this.sae != null) this.sae.RemoveDaArvore();
//    if (this.sad != null) this.sad.RemoveDaArvore();
//}