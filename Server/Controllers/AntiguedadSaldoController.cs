using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModeloDatos;

namespace TalperExamen.Server.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AntiguedadSaldoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{Inicio}/{Fin}/{idCuenta}/{idAuxiliar}")]
        public IActionResult Get(DateTime Inicio, DateTime Fin, int idCuenta,int idAuxiliar)
        {
            Respuesta<List<AntiguedadSaldo>> Respuesta = new Respuesta<List<AntiguedadSaldo>>();
            try
            {
                AntiguedadSaldo anti =new AntiguedadSaldo();
                anti.FechaInicio = Inicio;
                anti.FechaFin = Fin;
                anti.IdCuenta = idCuenta;
                anti.IdAuxiliar = idAuxiliar;
                DALDocumento dal = new DALDocumento(ClaseBase.getConexion());
                List<AntiguedadSaldo> lista = dal.ReporteAntiguedadSaldo(anti);
                Respuesta.Data = lista;
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

    }
}
