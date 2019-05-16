using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infraestructura.Errors
{
    public class CustomError:Exception
    {
        public string CodigoError { get; set; }
    }
}
