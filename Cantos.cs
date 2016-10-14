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
                    //Saca quien es la mano y establece la propiedad CantoGanador a true
                    JugadorGanadorCanto.ForEach(a => { if (a.Mano) a.CantoGanador = true; });

                //Si es vijia
                if (CantoMayor == Canto.Vijia) {

                }
              
                

            }
        }
      
    }
}
