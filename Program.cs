using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartoCartas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Juego objJuego = new Juego(3, 3);
            //objJuego.RepartirCartas();


            //foreach (var item in objJuego.ListaJugadores)
            //{
            //    Console.WriteLine("Jugador");
            //    foreach (var item1 in item.ListaCartasJugador)
            //    {
            //        Console.WriteLine(item1.ToString());
            //    }
            //}

            List<Cartas> objListaCartas = new List<Cartas>();
            objListaCartas.Add(new Cartas { Valor = Cartas.Valores.Uno, Palo = Cartas.Palos.Bastos });
            objListaCartas.Add(new Cartas { Valor = Cartas.Valores.Once, Palo = Cartas.Palos.Bastos });
            objListaCartas.Add(new Cartas { Valor = Cartas.Valores.Once, Palo = Cartas.Palos.Bastos });

            Cantos objCantos = new Cantos();
            objCantos.ObtenerCanto(objListaCartas);

                             
            //objJuego.ObtenerCanto();
        }
    }
}
