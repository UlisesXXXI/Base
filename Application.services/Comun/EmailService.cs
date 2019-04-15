using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.services.Comun
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Conecte su servicio de correo electrónico aquí para enviar correo electrónico.
            return Task.FromResult(0);
        }
    }
}
