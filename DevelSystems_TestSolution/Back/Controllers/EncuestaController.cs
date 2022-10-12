﻿using Back.Models;
using Back.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {
        private readonly ILogger<EncuestaController> _logger;
        InterfaceEncuesta _encuestaService;

        public EncuestaController(ILogger<EncuestaController> logger, InterfaceEncuesta encuestaService)
        {
            _encuestaService = encuestaService;
            _logger = logger;
        }
        // :::::::::::::    CREAR ENCUESTA  :::::::::::::    
        [HttpPost]
        [Authorize]
        public IActionResult CrearEncuesta([FromBody] Encuestum encuesta)
        {
            return Ok(_encuestaService.addEncuesta(encuesta));
        }
        // :::::::::::::    GET ENCUESTA  :::::::::::::    
        [HttpGet]
        [Authorize]
        public IActionResult GetEncuesta(string nombre){
            return Ok(_encuestaService.getEncuesta(nombre));
        }
        // :::::::::::::    GET ENCUESTAS  :::::::::::::    
        [HttpGet]
        [Authorize]
        [Route("All")]
        public IActionResult GetEncuestas()
        {
            return Ok(_encuestaService.getEncuestas());
        }
        // :::::::::::::    EDITAR ENCUESTA :::::::::::::    
        [HttpPut]
        [Authorize]
        public IActionResult EditarEncuesta([FromBody] Encuestum encuesta)
        {
            return Ok(_encuestaService.updateEncuesta(encuesta));
        }
        // :::::::::::::    ELIMINAR ENCUESTA :::::::::::::    
        [HttpDelete]
        [Authorize]
        public IActionResult EliminarEncuesta(string nombre)
        {
            return Ok(_encuestaService.delEncuesta(nombre));
        }
        // :::::::::::::    GET RESPUESTA   :::::::::::::    
        [HttpGet]
        [Authorize]
        [Route("GetAnswer")]
        public IActionResult GetRespuesta(string nombre)
        {
            return Ok(_encuestaService.getRespuestas(nombre));
        }
        // :::::::::::::    AGREGAR RESPUESTA   :::::::::::::    
        [HttpPut]
        [Authorize]
        [Route("AddAnswer")]
        public IActionResult AddRespuesta(Respuestum respuesta)
        {
            return Ok(_encuestaService.addRespuesta(respuesta));
        }
    }
}
