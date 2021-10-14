using CountCash_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CountCash_Backend.Controllers
{
    [Route("api/[controller]")]
  
    [ApiController]
    public class FlujoUsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public FlujoUsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("GetFlujoUsuario")]
        [HttpGet]
        public JsonResult Get(FlujoUsuarioModel FlujoUsuario)
        {
            

            string query = @"EXEC SeleccionarFlujoFecha '"+ FlujoUsuario.UsuarioID + @"'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DBconn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        



    }
}
