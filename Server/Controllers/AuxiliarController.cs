using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModeloDatos;

namespace TalperExamen.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuxiliarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Respuesta<Auxiliar> Respuesta = new Respuesta<Auxiliar>();
            try
            {

                Auxiliar Auxiliar = new Auxiliar();
                Auxiliar.ID = id;
                DALAuxiliar dal = new DALAuxiliar(ClaseBase.getConexion());
                Auxiliar= dal.Obtener( Auxiliar);
                Respuesta.Data = Auxiliar;
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
            Respuesta<List<Auxiliar>> Respuesta = new Respuesta<List<Auxiliar>>();
            try
            {

                DALAuxiliar dal = new DALAuxiliar(ClaseBase.getConexion());
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
        public IActionResult add(Auxiliar Auxiliar)
        {
            Respuesta<List<Auxiliar>> Respuesta = new Respuesta<List<Auxiliar>>();
            try
            {
                

                   DALAuxiliar dal = new DALAuxiliar(ClaseBase.getConexion());
                if (dal.Insertar(Auxiliar) > 0)
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
        public IActionResult edit(Auxiliar Auxiliar)
        {
            Respuesta<List<Auxiliar>> Respuesta = new Respuesta<List<Auxiliar>>();
            try
            {

                DALAuxiliar dal = new DALAuxiliar(ClaseBase.getConexion());
                if (dal.Actualizar(Auxiliar) > 0)
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
            Respuesta<Auxiliar> Respuesta = new Respuesta<Auxiliar>();
            try
            {
                Auxiliar Auxiliar = new Auxiliar() { ID = id };
                DALAuxiliar dal = new DALAuxiliar(ClaseBase.getConexion());

                if (dal.Eliminar(Auxiliar) > 0)
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
