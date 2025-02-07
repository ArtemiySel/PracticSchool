using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.Appdata
{
    internal class Connect
    {
        public static PracticaEntities c;
        public static PracticaEntities Contex
        {
            get
            {
                if (c == null)
                    c = new PracticaEntities();
                return c;
            }
        }
    }
}
