using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartoCartas
{
    public class Cantos
    {
        public enum Canto: byte { RondaUno=1, RondaDos, RondaTres, RondaCuatro, Tribilin, Patrulla, Vijia, Registro }

        public Canto ObtenerCanto(List<Cartas> objCartas)
        {
            objCartas.Sort();
            return (Canto)objCartas[2].Compare(objCartas[0], objCartas[1]);           
        }

        public void ObtenerCantoGanador(List<Jugador>objListaJugadores)
        {
            var objListaDeCantos = new List<Canto>();
            //Establecer el canto por jugador y su puntuacion
            objListaJugadores.ForEach(b => {
                //Ordeno la lista
                b.ListaCartasJugador.Sort();
                //Comparo las cartas para obtener el canto. Esto va al metodo Compare de la clase cartas
                b.CantoJugador = (Canto)b.ListaCartasJugador[2].Compare(b.ListaCartasJugador[0], b.ListaCartasJugador[1]);
                //Lleno una lista con todos los cantos obtenidos
                objListaDeCantos.Add(b.CantoJugador);
                //Establezco la puntuacion de los cantos por jugador
                b.PuntuacionCanto = (int)b.CantoJugador;
            });
            
            //Identifico cual es el canto mayor           
            var CantoMayor = objListaJugadores.Max(a=> a.CantoJugador);
            //Obtengo los jugadores que tienen el canto mayor
            var JugadorGanadorCanto = objListaJugadores.Where(a => a.CantoJugador == CantoMayor).ToList();

            //Si hay mas de un jugador con el mismo canto....
            if (JugadorGanadorCanto.Count > 1)
            {
                //Si es registro
                if (CantoMayor == Canto.Registro)
                    ValidarRegistro(JugadorGanadorCanto);

                //Si es vijia
                if (CantoMayor == Canto.Vijia)
                    ValidarVijia(JugadorGanadorCanto);
               



            }
        }

        private static void ValidarVijia(List<Jugador> JugadorGanadorCanto)
        {
            List<CantoPorJugador> objCantosPorJugador = new List<CantoPorJugador>();
            //Saber que carta se repite por jugador
            foreach (var item in JugadorGanadorCanto)
            {
                //Se agrupa y se cuenta las cartas que tienen dos cantidades
                var cantidadCartasRepetidas = item.ListaCartasJugador.GroupBy(a => a.Valor).Select(b =>
                    new { Count = b.Count(), Val = b.Key, item.idJugador }).Where(c => c.Count == 2);
                //Se llena una lista para gestionar las cantidades y cartas repetidas por el Id del jugador
                objCantosPorJugador.Add(new CantoPorJugador
                {
                    idJugador = item.idJugador,
                    ValorCarta = (int)cantidadCartasRepetidas.Select(a => a.Val).FirstOrDefault(),
                    CantidadCartaRepetida = (int)cantidadCartasRepetidas.Select(a => a.Count).FirstOrDefault()
                });
            }

            //Se saca cual es la carta mayor que ganó el vijia
            var CartaGanadoraVijia = objCantosPorJugador.Max(b => b.ValorCarta);
            //Se sacan los jugadores que tienen esa carta
            var JugadorGanadorVijia = objCantosPorJugador.Where(a => a.ValorCarta == CartaGanadoraVijia).ToList();

            //Si hay mas de un jugador que tiene las mismas cartas...
            if (JugadorGanadorVijia.Count > 1)
            {
                var result = from j in JugadorGanadorVijia
                             join cn in JugadorGanadorCanto on j.idJugador equals cn.idJugador
                             where (cn.Mano)
                             select new { idJugador = j.idJugador };
            }
            else
            {
               
            }
        }

        private static void ValidarRegistro(List<Jugador> JugadorGanadorCanto)
        {
            //Saca quien es la mano y establece la propiedad CantoGanador a true
            JugadorGanadorCanto.ForEach(a =>
            {
                if (a.Mano)
                    a.CantoGanador = true;
                else
                    a.PuntuacionCanto -= (int)Canto.Registro;
            });
        }
    }

    public class CantoPorJugador
    {
        private int _idJugador;

        public int idJugador
        {
            get { return _idJugador; }
            set { _idJugador = value; }
        }

        private int _ValorCarta;

        public int ValorCarta
        {
            get { return _ValorCarta; }
            set { _ValorCarta = value; }
        }

        private int _CantidadCartaRepetida;

        public int CantidadCartaRepetida
        {
            get { return _CantidadCartaRepetida; }
            set { _CantidadCartaRepetida = value; }
        }


    }
}
