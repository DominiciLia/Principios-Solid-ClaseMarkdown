using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    public class principio_4__I
    {

        public class Humano : ITrabajador, IComedor 
        {
            public void Trabajar() { } 
            public void Comer() { } 
        
        }
        public class Robot : ITrabajador 
        {
            public void Trabajar() { }

        }
    }
}
