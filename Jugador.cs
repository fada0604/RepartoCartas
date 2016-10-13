using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartoCartas
{
    public class Jugador
    {
        private List<Cartas> _ListaCartasJugador;

        public List<Cartas> ListaCartasJugador
        {
            get { return _ListaCartasJugador; }
            set { _ListaCartasJugador = value; }
        }

        private Cantos _CantoJugador;

        public Cantos CantoJugador
        {
            get { return _CantoJugador; }
            set { _CantoJugador = value; }
        }


    }
}
