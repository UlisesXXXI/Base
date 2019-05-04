using Application.bbdd.Entities;
using Application.Bll.Interface;
using Application.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bll.Implementacion
{
    public class GastoService:ServicioBase<Gasto>,IGastoService
    {
        public GastoService(IRepositorioGenerico<Gasto> repositorio):base(repositorio)
        {

        }
    }
}
