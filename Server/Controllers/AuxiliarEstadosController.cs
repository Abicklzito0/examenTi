using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModeloDatos;
namespace TalperExamen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuxiliarEstadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Respuesta<AuxiliarEstados> Respuesta = new Respuesta<AuxiliarEstados>();
            try
            {

                AuxiliarEstados AuxiliarEstados = new AuxiliarEstados();
                AuxiliarEstados.ID = id;
                DALAuxiliarEstados dal = new DALAuxiliarEstados(ClaseBase.getConexion());
                dal.Obtener(ref AuxiliarEstados);
                Respuesta.Data = AuxiliarEstados;
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
            Respuesta<List<AuxiliarEstados>> Respuesta = new Respuesta<List<AuxiliarEstados>>();
            try
            {

                DALAuxiliarEstados dal = new DALAuxiliarEstados(ClaseBase.getConexion());
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
        public IActionResult add(AuxiliarEstados AuxiliarEstados)
        {
            Respuesta<List<AuxiliarEstados>> Respuesta = new Respuesta<List<AuxiliarEstados>>();
            try
            {

                DALAuxiliarEstados dal = new DALAuxiliarEstados(ClaseBase.getConexion());
                if (dal.Insertar(AuxiliarEstados) > 0)
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
        public IActionResult edit(AuxiliarEstados AuxiliarEstados)
        {
            Respuesta<List<AuxiliarEstados>> Respuesta = new Respuesta<List<AuxiliarEstados>>();
            try
            {

                DALAuxiliarEstados dal = new DALAuxiliarEstados(ClaseBase.getConexion());
                if (dal.Actualizar(AuxiliarEstados) > 0)
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
            Respuesta<AuxiliarEstados> Respuesta = new Respuesta<AuxiliarEstados>();
            try
            {
                AuxiliarEstados AuxiliarEstados = new AuxiliarEstados() { ID = id };
                DALAuxiliarEstados dal = new DALAuxiliarEstados(ClaseBase.getConexion());

                if (dal.Eliminar(AuxiliarEstados) > 0)
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