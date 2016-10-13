using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepartoCartas
{
    public class Cartas: IComparer, IComparable
    {
        public enum Palos { Bastos, Copas, Espadas, Oro}
        public enum Valores { Uno=1, Dos, Tres, Cuatro, Cinco, Seis, Siete, Diez, Once, Doce}

        private List<Palos> _ListaPalo;

        public List<Palos> ListaPalo
        {
            get { return _ListaPalo; }
            set { _ListaPalo = value; }
        }

        private List<Valores> _ListaValor;

        public List<Valores> ListaValor
        {
            get { return _ListaValor; }
            set { _ListaValor = value; }
        }

        private Palos _Palo;

        public Palos Palo
        {
            get { return _Palo; }
            set { _Palo = value; }
        }

        private Valores _Valor;

        public Valores Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }


        public Cartas()
        {
            if (ListaPalo == null)
            {
                ListaPalo = new List<Palos>();
                foreach (var item in Enum.GetValues(typeof(Palos)))
                    ListaPalo.Add((Palos)item);
            }

            if (ListaValor == null)
            {
                ListaValor = new List<Valores>();
                foreach (var item in Enum.GetValues(typeof(Valores)))
                    ListaValor.Add((Valores)item);

            }
        }
        
        public Cartas(Palos paramPalo, Valores paramValor)
        {
            _Palo = paramPalo;
            _Valor = paramValor;
        }
        
        public int Compare(object x, object y)
        {
            Cartas cartaUno = (Cartas)x;
            Cartas cartaDos = (Cartas)y;

            //REGISTRO 
            if (cartaUno.Valor == Valores.Uno && cartaDos.Valor == Valores.Once && this.Valor == Valores.Doce)
                return 8;
            //TRIBILIN 1-1-1
            else if (cartaUno.Valor == cartaDos.Valor && this.Valor == cartaDos.Valor)
                return 5;
            //PATRULLA 1-2-3
            else if (this.Valor == (cartaDos.Valor + 1) && cartaDos.Valor == (cartaUno.Valor + 1))
                return 6;
            //VIJIA 
            else if (cartaUno.Valor == cartaDos.Valor && (this.Valor == cartaDos.Valor + 1) ||
                cartaDos.Valor == this.Valor && (cartaUno.Valor == cartaDos.Valor - 1))
                return 7;
            //RONDA
            else if (cartaUno.Valor == cartaDos.Valor && (this.Valor != cartaDos.Valor + 1))
            {
                if ((byte)cartaUno.Valor >= 1 && (byte)cartaUno.Valor <= 7)
                    return 1;
                else if (cartaUno.Valor == Valores.Diez)
                    return 2;
                else if (cartaUno.Valor == Valores.Once)
                    return 3;
                else 
                    return 4;
            }
            else if (cartaDos.Valor == this.Valor && (cartaUno.Valor != cartaDos.Valor - 1))
            {
                if ((byte)cartaDos.Valor >= 1 && (byte)cartaDos.Valor <= 7)
                    return 1;
                else if (cartaDos.Valor == Valores.Diez)
                    return 2;
                else if (cartaDos.Valor == Valores.Once)
                    return 3;
                else
                    return 4;
            }
            return 0;
        }

        public int CompareTo(object obj)
        {
            return ((int)this.Valor).CompareTo((int)((Cartas)obj).Valor);
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", this.Palo, this.Valor);
        }
    }
}
