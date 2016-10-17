using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartoCartas
{
    public class Jugador
    {
        private int _idJugador;

        public int idJugador
        {
            get { return _idJugador; }
            set { _idJugador = value; }
        }

        private List<Cartas> _ListaCartasJugador;

        public List<Cartas> ListaCartasJugador
        {
            get { return _ListaCartasJugador; }
            set { _ListaCartasJugador = value; }
        }

        private Cantos.Canto _CantoJugador;

        public Cantos.Canto CantoJugador
        {
            get { return _CantoJugador; }
            set { _CantoJugador = value; }
        }

        private int _PuntuacionCanto;

        public int PuntuacionCanto
        {
            get { return _PuntuacionCanto; }
            set { _PuntuacionCanto = value; }
        }

        private bool _Mano;

        public bool Mano
        {
            get { return _Mano; }
            set { _Mano = value; }
        }

        private bool _CantoGanador;

        public bool CantoGanador
        {
            get { return _CantoGanador; }
            set { _CantoGanador = value; }
        }

        private int _PosicionMesa;
        /// <summary>
        /// Siempre la mano sera el 1
        /// </summary>
        public int PosicionMesa
        {
            get { return _PosicionMesa; }
            set { _PosicionMesa = value; }
        }


    }
}
