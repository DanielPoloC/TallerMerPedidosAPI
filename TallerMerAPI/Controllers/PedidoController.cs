using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerMerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private string _connection = @"Server=localhost; Database=classicmodels; Uid=root;";

        [HttpGet("{pedido}")]
        public IActionResult Get(int pedido)
        {
            IEnumerable<Models.Pedido> lst = null;
            using (var db = new MySql.Data.MySqlClient.MySqlConnection(_connection))
            {
                var sql = "SELECT orders.orderNumber AS ordenno, DATE_FORMAT(orders.orderDate, \"%d - %b - %Y\") AS orderdate, customers.customerName AS name," +
                    " CONCAT(COALESCE(customers.addressLine1,''), ' ', COALESCE(customers.addressLine2,'')) AS adress, customers.phone AS phone," +
                    " CONCAT(employees.lastName, ' ', employees.firstName) AS employe, products.productCode AS productCode, products.productName AS productName," +
                    " orderdetails.quantityOrdered AS quanty, products.buyPrice AS price, orderdetails.quantityOrdered* products.buyPrice AS total" +
                " FROM offices INNER JOIN employees ON employees.officeCode = offices.officeCode" +
                    " INNER JOIN customers ON customers.salesRepEmployeeNumber = employees.employeeNumber" +
                    " INNER JOIN payments ON payments.customerNumber = customers.customerNumber" +
                    " INNER JOIN orders ON orders.customerNumber = customers.customerNumber" +
                    " INNER JOIN orderdetails ON orderdetails.orderNumber = orders.orderNumber" +
                    " INNER JOIN products ON products.productCode = orderdetails.productCode" +
                    " INNER JOIN productlines ON productlines.productLine = products.productLine" +
                " WHERE orders.orderNumber = \"" + pedido + "\" " +
                " GROUP BY orderdetails.productCode";
                lst = db.Query<Models.Pedido>(sql);
            }
            return Ok(lst);
        }
    }
}
