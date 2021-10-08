﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10FSchon_RendezettLista
{
    class Program
    {

        class RendezettLista<T>
        {
            private List<T> lista;
            private Func<T, T, int> relacio;

            public RendezettLista(Func<T, T, int> relacio)
            {
                this.lista = new List<T>();
                this.relacio = relacio;
            }

            private int Helye(T elem)
            {
                if (lista.Count != 0)
                {
                    int e = 0;
                    int v = lista.Count - 1;
                    int k;
                    do
                    {
                        k = (e + v) / 2;
                        if (relacio(elem, lista[k]) == -1)
                            v = k - 1;
                        else if (relacio(elem, lista[k]) == 1)
                            e = k + 1;
                    } while (e <= v && !elem.Equals(lista[k]));
                    return elem.Equals(lista[k]) ? k : e;
                }
                return 0;
            }

            public void Add(T e)
            {
                int itt = Helye(e);
                if (itt == lista.Count)
                    lista.Add(e); // nem rekurzió! A lista Add-ját hívtuk meg!
                else
                    lista.Insert(itt, e);
            }

            public override string ToString()
            {
                string str = "";
                for (int i = 0; i < lista.Count; i++)
                    str += $"{lista[i]} ";
                return str;
            }

            public T Max() => lista[lista.Count - 1];
            public T Min() => lista[0];
            public T Median() => lista[lista.Count / 2];
            public T Kvartilis1() => lista[lista.Count / 4];
            public T Kvartilis3() => lista[3 * lista.Count / 4];

            public T this[int i] { get => lista[i]; }

            public int Count => lista.Count;

            public void RemoveAt(int i) => lista.RemoveAt(i);

            public static RendezettLista<T> operator +(RendezettLista<T> A, RendezettLista<T> B)
            {
                RendezettLista<T> C = new RendezettLista<T>(A.relacio);

                int i = 0;
                int j = 0;

                while (i < A.Count && j < B.Count)
                {
                    ///...
                }

                while (i < A.Count)
                {
                    ///...
                }

                while (j < B.Count)
                {
                    ///...
                }

                return C;

            }

            // TODO list
            /*
             * + : unió
             * - : különbség
             * * : metszet
             * 
             */
        }

        static void Main(string[] args)
        {
            RendezettLista<int> rendezettlista = new RendezettLista<int>( (x,y) => x<y?-1:(x>y?1:0));
            rendezettlista.Add(3);
            rendezettlista.Add(9);
            rendezettlista.Add(10);
            rendezettlista.Add(1);
            rendezettlista.Add(10);
            rendezettlista.Add(20);
            rendezettlista.Add(15);
            rendezettlista.Add(1);

            Console.WriteLine(rendezettlista);

        }
    }
}
