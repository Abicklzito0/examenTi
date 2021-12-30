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
    public class TipoDocumentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Respuesta<TipoDocumento> Respuesta = new Respuesta<TipoDocumento>();
            try
            {

                TipoDocumento TipoDocumento = new TipoDocumento();
                TipoDocumento.ID = id;
                DALTipoDocumento dal = new DALTipoDocumento(ClaseBase.getConexion());
                dal.Obtener( TipoDocumento);
                Respuesta.Data = TipoDocumento;
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
            Respuesta<List<TipoDocumento>> Respuesta = new Respuesta<List<TipoDocumento>>();
            try
            {

                DALTipoDocumento dal = new DALTipoDocumento(ClaseBase.getConexion());
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
        public IActionResult add(TipoDocumento TipoDocumento)
        {
            Respuesta<List<TipoDocumento>> Respuesta = new Respuesta<List<TipoDocumento>>();
            try
            {


                DALTipoDocumento dal = new DALTipoDocumento(ClaseBase.getConexion());
                if (dal.Insertar(TipoDocumento) > 0)
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
        public IActionResult edit(TipoDocumento TipoDocumento)
        {
            Respuesta<List<TipoDocumento>> Respuesta = new Respuesta<List<TipoDocumento>>();
            try
            {

                DALTipoDocumento dal = new DALTipoDocumento(ClaseBase.getConexion());
                if (dal.Actualizar(TipoDocumento) > 0)
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
            Respuesta<TipoDocumento> Respuesta = new Respuesta<TipoDocumento>();
            try
            {
                TipoDocumento TipoDocumento = new TipoDocumento() { ID = id };
                DALTipoDocumento dal = new DALTipoDocumento(ClaseBase.getConexion());

                if (dal.Eliminar(TipoDocumento) > 0)
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
