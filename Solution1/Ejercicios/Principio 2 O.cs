using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    public class Principio_2_O : IDescuento
    {
        public double Calcular(double monto)
        {
            return monto * 0.05;
        }


        public class DescuentoRegular : IDescuento
        {
            public double Calcular(double monto)
            {
                return monto * 0.05;
            }

        }
        public class DescuentoVIP : IDescuento
        {
            public double Calcular(double monto)
            {
                return monto * 0.10;
            }

        }

    }
}
