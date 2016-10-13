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

        public Cantos ObtenerCanto(List<Cartas> objCartas)
        {
            objCartas.Sort();
            var retorno = objCartas[2].Compare(objCartas[0], objCartas[1]);
            return this;
           
        }

      
    }
}
