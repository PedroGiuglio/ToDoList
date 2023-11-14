using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Probamos.Models;
using System.Collections.Generic;
using System.Linq;

namespace Probamos.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {

        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {
            List<Clien> clientes = new List<Clien>
          {
              new Clien
              {
                  id=1,
                  nombre="Pedro",
                  edad="25",
                  correo="pedrogiuglio@hotmail.com"
              },
                  new Clien
              {
                  id=2,
                  nombre="Bautista",
                  edad="20",
                  correo="batigiuglio@hotmail.com"
              },
                          new Clien
              {
                  id=3,
                  nombre="David Daniel",
                  edad="27",
                  correo="ddsalcedo@hotmail.com"
              }
           };
            return clientes;
        }

        [HttpGet]
        [Route("listarPorId")]
        public dynamic listarClientePorId(int codigo)
        {
            return new Clien
            {
                id = codigo,
                nombre = "David Danddiel",
                edad = "27",
                correo = "ddsalcedo@hotmail.com"
            };
        }


        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Clien cliente)
        {
            cliente.id = 3;
            return new
            {
                succes = true,
                message = "success",
                result = cliente
            };
        }

        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarCliente(Clien cliente)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            if (token != "marco123.")
            {
                return new
                {
                    succes = false,
                    message = "token incorrect",
                    result = cliente
                };
            }

            return new
            {
                succes = true,
                message = "cliente eliminado",
                result = cliente
            };
        }
    }
}
