using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMerPedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private string conexion = @"Server=localhost; Database=facturacion; Uid=root;";

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Models.Pedido> lst = null;
            using (var db = new MySqlConnection(conexion))
            {
                var sql = "SELECT * from clientes";
                lst = db.Query<Models.Pedido>(sql);
            }
            return Ok(lst);
        }
    }
}
