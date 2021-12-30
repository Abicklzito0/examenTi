using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModeloDatos;

namespace TalperExamen.Server.Controllers
{
 
    
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Respuesta<Documento> Respuesta = new Respuesta<Documento>();
            try
            {

                Documento Documento = new Documento();
                Documento.ID = id;
                DALDocumento dal = new DALDocumento(ClaseBase.getConexion());
                dal.Obtener(ref Documento);
                Respuesta.Data = Documento;
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
            Respuesta<List<Documento>> Respuesta = new Respuesta<List<Documento>>();
            try
            {

                DALDocumento dal = new DALDocumento(ClaseBase.getConexion());
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
        public IActionResult add(Documento Documento)
        {
            Respuesta<List<Documento>> Respuesta = new Respuesta<List<Documento>>();
            try
            {


                DALDocumento dal = new DALDocumento(ClaseBase.getConexion());
                if (dal.Insertar(Documento) > 0)
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
        public IActionResult edit(Documento Documento)
        {
            Respuesta<List<Documento>> Respuesta = new Respuesta<List<Documento>>();
            try
            {

                DALDocumento dal = new DALDocumento(ClaseBase.getConexion());
                if (dal.Actualizar(Documento) > 0)
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
            Respuesta<Documento> Respuesta = new Respuesta<Documento>();
            try
            {
                Documento Documento = new Documento() { ID = id };
                DALDocumento dal = new DALDocumento(ClaseBase.getConexion());

                if (dal.Eliminar(Documento) > 0)
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
