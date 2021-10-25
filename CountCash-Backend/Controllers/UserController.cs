using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using CountCash_Backend.Models;
using System.Data;

namespace CountCash_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("GetUsuario")]
        [HttpGet]
        public JsonResult Get([FromQuery] User usuario)
        {
            string query = @"EXEC SeleccionarUsuario_login '" + usuario.Nombre + @"', '" + usuario.Contraseña + @"'";
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
        [Route("PostUsuario")]
        [HttpPost]
        public JsonResult Post(User usuario)
        {
            string query = @"EXEC InsertarUsuario '" + usuario.Nombre + @"', '" + usuario.Email + @"', '" + usuario.Contraseña + @"'";
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
            return new JsonResult("Crear Usuario funciona.");
        }
        [Route("DeleteUsuario")]
        [HttpDelete]
        public JsonResult Delete(User usuario)
        {
            string query = @"EXEC EliminarUsuario " + usuario.ID_Usuario + @"";
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
            return new JsonResult("Usuario Eliminado.");
        }
        [Route("UpdateUsuario")]
        [HttpPut]
        public JsonResult Put(User usuario)
        {
            string query = @"EXEC UpdateUsuario " + usuario.ID_Usuario + @", '" + usuario.Nombre + @"', '" + usuario.Email + @"', '" + usuario.Contraseña + @"'";
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
            return new JsonResult("Usuario Updeitiado.");
        }
    }
}
