using System;
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

            public RendezettLista(Func<T,T, int> relacio)
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
                if (itt==lista.Count)
                    lista.Add(e); // nem rekurzió! A lista Add-ját hívtuk meg!
                else
                    lista.Insert(itt, e);
            }

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


        }
    }
}
