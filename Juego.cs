using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartoCartas
{
    public class Juego
    {
        public Juego()
        {

        }

        public Juego(byte cantidadJugadores, byte cantidadCartasARepartirPorJugador)
        {
            ListaJugadores = new List<Jugador>();
            CantidadCartasARepartir = cantidadCartasARepartirPorJugador;
            objMazo = new Mazo();
            objMazo.ConstruirMazo();
               
            for (int i = 0; i < cantidadJugadores; i++)
            {
                ListaJugadores.Add(new Jugador());
            }

        }

        private byte _cantidadCartasARepartir;

        public byte CantidadCartasARepartir
        {
            get { return _cantidadCartasARepartir; }
            set { _cantidadCartasARepartir = value; }
        }


        private List<Jugador> _ListaJugadores;

        public List<Jugador> ListaJugadores
        {
            get { return _ListaJugadores; }
            set { _ListaJugadores = value; }
        }

        private Mazo _Mazo;

        public Mazo objMazo
        {
            get { return _Mazo; }
            set { _Mazo = value; }
        }


        public void RepartirCartas()
        {
            for (int i = 0; i < ListaJugadores.Count; i++)
            {
                if (ListaJugadores[i].ListaCartasJugador == null)
                {
                    ListaJugadores[i].ListaCartasJugador = new List<Cartas>();
                }
                for (int j = 0; j < CantidadCartasARepartir; j++)
                {
                    ListaJugadores[i].ListaCartasJugador.Add(objMazo.ExtraerMazo());
                }
            }
        }

        public void ObtenerCanto()
        {
            Cantos objCantos = new Cantos();
            for (int i = 0; i < ListaJugadores.Count; i++)
            {
                ListaJugadores[i].CantoJugador = objCantos.ObtenerCanto(ListaJugadores[i].ListaCartasJugador);
            }

            objCantos.ObtenerCantoGanador(ListaJugadores);
        }
    }
}
