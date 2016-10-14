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
            //List<Cartas> objListaCartas = new List<Cartas>();
            //objListaCartas.Add(new Cartas { Valor = Cartas.Valores.Uno, Palo = Cartas.Palos.Bastos });
            //objListaCartas.Add(new Cartas { Valor = Cartas.Valores.Once, Palo = Cartas.Palos.Bastos });
            //objListaCartas.Add(new Cartas { Valor = Cartas.Valores.Once, Palo = Cartas.Palos.Bastos });

            //Cantos objCantos = new Cantos();
            //objCantos.ObtenerCanto(objListaCartas);




            //Juego objJuego = new Juego(3, 3);
            //objJuego.RepartirCartas();
            //objJuego.ObtenerCanto();

            //foreach (var item in objJuego.ListaJugadores)
            //{
            //    foreach (var item1 in item.ListaCartasJugador)
            //    {
            //        Console.WriteLine(item1.ToString());
            //    }
            //    Console.WriteLine(item.CantoJugador);
            //    Console.WriteLine("\n");
            //}

            var ListaCartas1 = new List<Cartas> { new Cartas { Valor = Cartas.Valores.Uno, Palo = Cartas.Palos.Bastos },
                                                  new Cartas { Valor = Cartas.Valores.Dos, Palo = Cartas.Palos.Bastos },
                                                  new Cartas { Valor = Cartas.Valores.Dos, Palo = Cartas.Palos.Bastos }};

            var ListaCartas2 = new List<Cartas> { new Cartas { Valor = Cartas.Valores.Cuatro, Palo = Cartas.Palos.Bastos },
                                                  new Cartas { Valor = Cartas.Valores.Tres, Palo = Cartas.Palos.Bastos },
                                                  new Cartas { Valor = Cartas.Valores.Tres, Palo = Cartas.Palos.Bastos }};

            var ListaCartas3 = new List<Cartas> { new Cartas { Valor = Cartas.Valores.Tres, Palo = Cartas.Palos.Bastos },
                                                  new Cartas { Valor = Cartas.Valores.Seis, Palo = Cartas.Palos.Bastos },
                                                  new Cartas { Valor = Cartas.Valores.Cinco, Palo = Cartas.Palos.Bastos }};
            var ListJugadores = new List<Jugador>();
            ListJugadores.Add(new Jugador { idJugador = 1, ListaCartasJugador = ListaCartas1, Mano=true });
            ListJugadores.Add(new Jugador { idJugador = 2, ListaCartasJugador = ListaCartas2 });
            ListJugadores.Add(new Jugador { idJugador = 3, ListaCartasJugador = ListaCartas3 });

            var objCanto = new Cantos();
            objCanto.ObtenerCantoGanador(ListJugadores);
           

            Console.Read();
        }
    }
}
