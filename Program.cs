using System;

namespace csharp_snacks_2
{
    internal class Program
    {
        static void Main(string[] args)  //entry point
        {

            // Scrivere un codice csharp che crea un accumulatore e poi lo utilizza
            //Esempio: var accumulatore1 = CreaAccumulatore();
            //accumulatore1(10) => 10
            //accumulatore1(40) => 50
            //accumulatore1(90) => 140


            //1: per evitare di dichiarare un tipo cosa uso? var!!!
            var Maker = () =>
            {
                long totale = 0;
                return (int n) =>
                {
                    totale += n;
                    return totale;
                };
            };
            var acc1 = Maker();
            var acc2 = Maker();
            Console.WriteLine(acc1(10));
            Console.WriteLine(acc1(10));
            Console.WriteLine(acc1(10));
            Console.WriteLine(acc2(10));
            Console.WriteLine(acc2(10));
            Console.WriteLine(acc2(10));



            //Data una lista di interi, metterli tutti al quadrato 

             List<double> list = new List<double>() { 1, 2, 3, 4, 5};

             List<double> lsquadrato = MettiAlQuadrato(list);


             foreach (int i in lsquadrato) { Console.WriteLine(i); }

             List<double> MettiAlQuadrato(List<double> list)
             {
                 List<double> result = new List<double>();

                 double ele = 0;

                 foreach (int i in list)
                 {
                     ele = Math.Pow(i, 2);
                     result.Add(ele);
                 }

                 return result;
                 //throw new NotImplementedException();
             }

            /*//Second versione

            List<int> li = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            List<int> lsquare = MettiAlQuadrato(li);
            foreach (int n in lsquare)
                Console.WriteLine(n);
            //=> lsquare = {1, 4, 9, 16, 25, 36, 49}
            List<int> MettiAlQuadrato(List<int> li)
            {
                List<int> lout = new List<int>();
                foreach (int n in li)
                    lout.Add(n * n);
                return lout;
                //throw new NotImplementedException();
            }

            */
            List<int> li = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };



            List<int> EseguiIlCalcolo(List<int> li, Func<int, int> fun)
            {
                List<int> lout = new List<int>();

                foreach (int n in li)
                    lout.Add(fun(n));
                return lout;
            }

            List<int> lcalcolo = EseguiIlCalcolo(li, (n) => n * (n + 1) / 2);

            foreach (int n in lcalcolo)
                Console.WriteLine(n);

            //Abbiamo in questo modo costruito una funzione "generale" per trasformare
            //tutti gli elementi di una stringa da numero intero a numero intero => nuovo = f(vecchio);
            //Purtroppo per come è stata costruita, questa funzione si applica esclusivamente
            //alle lista di numeri interi 
            //e torna una lista di numeri interi


            //Se inserisco una Lista di stringhe e voglio la lista di uscita in intero

            //devo scrivere 

            List<string> ls = new List<string>() { "uno","due","tre"};


            List<int> EseguiIlCalcoloS(List<string> li, Func<string, int> fun)
            {
                List<int> lout = new List<int>();

                foreach (string n in li)
                    lout.Add(fun(n));
                return lout;
            }

            // Si può usare select che e' indipendete dal tipo
            var lslen = ls.Select(l => l.Length);


            List<int> nuovalista = new List<int>() { 1, 2, 3};

            var listaQuadrati = nuovalista.Select(n => n * n);

            foreach (int n in listaQuadrati) { Console.WriteLine(n); }


            //Data una lista di interi estrarre la lista dei numeri pari

            List<int> lisStart = new List<int>() { 1, 3, 4, 6, 78, 11, 120};

            var listaPari = lisStart.Where(n => (n % 2) == 0);


            //ordinare una lista di interi
            li = new List<int>() { 8, 4, 67, 12, 43, 91, 0, 1, 2, 3, 5, 5 };
            li.Sort();  //sort e reverse modificano la lista
            li.Reverse();  //se la volessi al contrario
            foreach (int n in li)
                Console.WriteLine(n);
            Console.WriteLine("\n\n\n\n");
            li = new List<int>() { 8, 4, 67, 12, 43, 91, 0, 1, 2, 3, 5, 5 };
            li.Sort((int v1, int v2) =>
            {
                if (v1 < v2)
                    return -1;
                if (v1 == v2)
                    return 0;
                else
                    return 1;
            });
            foreach (int n in li)
                Console.WriteLine(n);
            //crescente
            Console.WriteLine("\n\n\n\n");
            li = new List<int>() { 8, 4, 67, 12, 43, 91, 0, 1, 2, 3, 5, 5 };
            li.Sort((int v1, int v2) =>
            {
                if (v1 < v2)
                    return 1;
                if (v1 == v2)
                    return 0;
                else
                    return -1;
            });
            foreach (int n in li)
                Console.WriteLine(n);
            //Data la lista di stringhe {"uno", "due", "tre", "quattro", "cinque", "Sei"}
            //ordinarla e stamparla in verso decrescente

            List<string> conto = new List<string>() { "uno", "due", "tre", "quattro", "cinque", "Sei" };

            conto.Sort();
            conto.Reverse();

            foreach (string s in conto) { Console.WriteLine(s); }

          
            //!!ordinamento lessicografico
            //numeri davanti a tutto, maiuscole prima delle minuscole

            //Formulazione 1
            List<string> lstr = new List<string>() { "uno", "due", "tre", "quattro", "cinque", "Sei" };
            //Con gli insiemi ordinati
            SortedSet<string> ords = new SortedSet<string>();
            foreach (String s in lstr)
                ords.Add(s);
            foreach (String s in ords)
                Console.WriteLine(s);
            
            //Formulazione 3
            Console.WriteLine("\n\n\n\n");
            lstr = new List<string>() { "uno", "due", "tre", "quattro", "cinque", "Sei" };
            lstr.Sort((string s1, string s2) => -s1.CompareTo(s2));
            foreach (String s in lstr)
                Console.WriteLine(s);

            //Esercizio finale
            //Data una lista di coppia <String, int> , stamparle ordinate
            //Dalla data meno recente alla data più recente

            //Una coppia in C# si dichiara con 

            List<Tuple<string, int>> lcoppie = new List<Tuple<string, int>>() {
                new Tuple<string, int>("uno",1),
                new Tuple<string, int>("due",21),
                new Tuple<string, int>("quattro",41),
                new Tuple<string, int>("sette",71),
                new Tuple<string, int>("diciannove",191),

            };

            lcoppie.Sort(Comparer<Tuple<string, int>>.Default);

            foreach (Tuple<string, int> s in lcoppie)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();
            Console.WriteLine("---------------");

            //oppure

            lcoppie.ForEach(n => Console.WriteLine(n));

            Console.WriteLine();
            Console.WriteLine("---------------");

            //oppure

            Console.WriteLine(String.Join("\n", lcoppie));

            Console.WriteLine();
            Console.WriteLine("---------------");


            //ordiniamo ora per il secondo elemento della tupla

            lcoppie.Sort((t1, t2) => t1.Item2.CompareTo(t2.Item2));


            List<Tuple<int, int, int>> lcoppie1 = new List<Tuple<int, int, int>>()
            {
                    new Tuple<int, int, int>(1, 2, 3),
                    new Tuple<int, int, int>(4, 8, 32),
                    new Tuple<int, int, int>(5, 3, 12),
                    new Tuple<int, int, int>(6, 7, 65),
                    new Tuple<int, int, int>(42, 12, 11),
                    new Tuple<int, int, int>(42, 85, 31),
            };


            lcoppie1.Sort();
            Console.WriteLine(String.Join("n", lcoppie1));



            //calcolo del tempo attuale in millionesimi di secondo

            //double microseconds = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            //Console.WriteLine("microseconds: {0}", microseconds);


        }


    }
}