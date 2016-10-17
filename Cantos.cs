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
        public enum Canto: byte { RondaUno = 1, RondaDos, RondaTres, RondaCuatro, Trivilin, Patrulla, Vijia, Registro }

        public void EstablecerCantoGanador(List<Jugador>objListaJugadores)
        {
            objListaJugadores.OrderBy(a=> a.PosicionMesa);
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
                ResolverCantosRepetidos(JugadorGanadorCanto, CantoMayor, objListaJugadores);
            else
                objListaJugadores.ForEach(a=> {
                    if (a.idJugador == JugadorGanadorCanto.Select(b => b.idJugador).FirstOrDefault())
                        a.CantoGanador = true;
                });

            QuitarPuntosCantosPerdedores(objListaJugadores);
        }

        private static void ResolverCantosRepetidos(List<Jugador> JugadorGanadorCanto, Canto paramCanto, List<Jugador> objListaJugadores)
        {
            //Ingresar la suma de las cartas a un diccionario por jugador
            Dictionary<int, int> sumaCartas = new Dictionary<int, int>();
            JugadorGanadorCanto.ForEach(a=> {
                sumaCartas.Add(a.idJugador, a.ListaCartasJugador.Sum(b => (int)b.Valor));
            });

            //Saber cuales cartas son las mayores
            var cartasMayores = sumaCartas.Max(a => a.Value);

            //Saber el jugador ganador
            var ganador = JugadorGanadorCanto.Where(a => a.ListaCartasJugador.Sum(b => (int)b.Valor) == cartasMayores).ToList();

            //Si hay mas de un ganador, es decir tienen las mismas cartas gana la derecha de la mano
            if (ganador.Count > 1)
                JugadorGanadorCanto.ForEach(a=> {
                    if (sumaCartas.ContainsKey(a.idJugador) && a.PosicionMesa > 1 && (JugadorGanadorCanto.Where(b=>b.CantoGanador).Count() == 0))
                        a.CantoGanador = true;
                });
            else 
                JugadorGanadorCanto.ForEach(a =>
                {
                    if (a.idJugador == ganador.Select(b=> b.idJugador).FirstOrDefault())
                        a.CantoGanador = true;
                });
        }

        private static void QuitarPuntosCantosPerdedores(List<Jugador> objListaJugadores)
        {
            objListaJugadores.ForEach(a => {
                if (!a.CantoGanador && a.PuntuacionCanto != 0)
                    a.PuntuacionCanto -= (int)a.CantoJugador;
            });
        }
    }
}
