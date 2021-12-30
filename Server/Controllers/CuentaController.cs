using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModeloDatos;

namespace TalperExamen.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Respuesta<List<Cuenta>> Respuesta = new Respuesta<List<Cuenta>>();
            try
            {

                List<Cuenta> Cuenta = new List<Cuenta>();
                
                DALCuenta dal = new DALCuenta(ClaseBase.getConexion());
                Cuenta = dal.Listar(id);
                Respuesta.Data = Cuenta;
                Respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                Respuesta.Exito = 0;
                Respuesta.Mensaje = ex.Message;

            }
            return Ok(Respuesta);
        }
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Cuenta>> Respuesta = new Respuesta<List<Cuenta>>();
            try
            {

                DALCuenta dal = new DALCuenta(ClaseBase.getConexion());
                Respuesta.Data = dal.Listar();
                Respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                Respuesta.Exito = 0;
                Respuesta.Mensaje = ex.Message;

            }
            return Ok(Respuesta);
        }
        [HttpPost]
        public IActionResult add(Cuenta Cuenta)
        {
            Respuesta<List<Cuenta>> Respuesta = new Respuesta<List<Cuenta>>();
            try
            {


                DALCuenta dal = new DALCuenta(ClaseBase.getConexion());
                if (dal.Insertar(Cuenta) > 0)
                    Respuesta.Exito = 1;
                else
                    Respuesta.Exito = 0;
            }
            catch (Exception ex)
            {
                Respuesta.Exito = 0;
                Respuesta.Mensaje = ex.Message;

            }
            return Ok(Respuesta);
        }
        [HttpPut]
        public IActionResult edit(Cuenta Cuenta)
        {
            Respuesta<List<Cuenta>> Respuesta = new Respuesta<List<Cuenta>>();
            try
            {

                DALCuenta dal = new DALCuenta(ClaseBase.getConexion());
                if (dal.Actualizar(Cuenta) > 0)
                    Respuesta.Exito = 1;
                else
                    Respuesta.Exito = 0;
            }
            catch (Exception ex)
            {
                Respuesta.Exito = 0;
                Respuesta.Mensaje = ex.Message;

            }
            return Ok(Respuesta);
        }
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            Respuesta<Cuenta> Respuesta = new Respuesta<Cuenta>();
            try
            {
                Cuenta Cuenta = new Cuenta() { ID = id };
                DALCuenta dal = new DALCuenta(ClaseBase.getConexion());

                if (dal.Eliminar(Cuenta) > 0)
                    Respuesta.Exito = 1;
                else
                    Respuesta.Exito = 0;
            }
            catch (Exception ex)
            {
                Respuesta.Exito = 0;
                Respuesta.Mensaje = ex.Message;

            }
            return Ok(Respuesta);
        }
    }
}
