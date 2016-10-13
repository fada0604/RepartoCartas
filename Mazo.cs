using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartoCartas
{
    public class Mazo
    {
        const int TotalCartas = 40;
        List<byte> almacenDeNumeroAleatorios = new List<byte>();
        public Mazo()
        {
            
        }
        
        private List<Cartas> _objListaCartas;

        public List<Cartas> objListaCartas
        {
            get { return _objListaCartas; }
            set { _objListaCartas = value; }
        }

        public void ConstruirMazo()
        {
            Cartas objCartas = new Cartas();
            objListaCartas = new List<Cartas>();

            for (int i = 0; i < objCartas.ListaPalo.Count; i++)
            {
                for (int j = 0; j < objCartas.ListaValor.Count; j++)
                {
                    objListaCartas.Add(new Cartas(objCartas.ListaPalo[i], objCartas.ListaValor[j]));

                }
            }
            
        }

        public Cartas ExtraerMazo()
        {
            Random objRandom = new Random();
            Byte numeroAleatorio = 0;
            do
            {
                numeroAleatorio = (byte)objRandom.Next(1, TotalCartas);
            } while (almacenDeNumeroAleatorios.Contains(numeroAleatorio));
            
            almacenDeNumeroAleatorios.Add(numeroAleatorio);
            
            var CartaAEliminar = objListaCartas[numeroAleatorio];

            var CartaSeleccionada = objListaCartas.Where(a=> a.Palo == CartaAEliminar.Palo && a.Valor == CartaAEliminar.Valor).FirstOrDefault();
            
            return CartaSeleccionada;
        }


    }
}
