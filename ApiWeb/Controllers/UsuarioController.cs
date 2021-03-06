﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiWeb.DTO;
using ApiWeb.Model;
using ApiWeb.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApiWeb.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "UsuariosProductosAPI")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        /// <summary>
        /// Obtienen todos los usuarios registrados
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(201, Type = typeof(List<UsuarioDTO>))]
        [ProducesResponseType(400, Type = typeof(List<UsuarioDTO>))]
        public ActionResult GetUsuarios()
        {
            var LstUsuarios = _usuarioRepository.GetUsuarios();
            var LstUsuarioDTO = new List<UsuarioDTO>();
            foreach (var list in LstUsuarios)
            {
                LstUsuarioDTO.Add(_mapper.Map<UsuarioDTO>(list));
            }
            return Ok(LstUsuarioDTO);
        }
        [Authorize]
        [HttpGet("{IdUsuario:int}", Name = "GetUsuario")]
        public ActionResult GetUsuario(int IdUsuario)
        {
            var Usuario = _usuarioRepository.GetUsuario(IdUsuario);

            if (Usuario == null)
            {
                return NotFound();
            }
            var usuarioDTO = _mapper.Map<UsuarioDTO>(Usuario);
            return Ok(usuarioDTO);
        }

        [HttpPost("Registrar")]
        public ActionResult Registrar(UsuarioAuthDTO DatosRegistro)
        {
            if (_usuarioRepository.ExisteUsuario(DatosRegistro.ClientId.ToLower()))
            {
                return BadRequest($"El nombre de usuario {DatosRegistro.ClientId} ya eiste");
            }
            var CreaUsuario = new Usuario
            {
                ClientId = DatosRegistro.ClientId,
                Activo = DatosRegistro.Activo,
                FechaCreo = DatosRegistro.FechaCreo
            };
            var result = _usuarioRepository.Registrar(CreaUsuario, DatosRegistro.Password);
            return Ok(result);
        }

        [HttpPost("Login")]
        public ActionResult Login(UsuarioAuthLoginDTO DatosLogin)
        {
            var usuarioCredencial = _usuarioRepository.Login(DatosLogin.ClientId, DatosLogin.Password);
            if (usuarioCredencial == null)
            {
                return Unauthorized();
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuarioCredencial.ClientId),
                new Claim(ClaimTypes.Name, usuarioCredencial.ClientId)
            };
            //Secret para generar token

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:TokenKey").Value));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var descripcionToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credencial
            };
            var tokenHandle = new JwtSecurityTokenHandler();
            var token = tokenHandle.CreateToken(descripcionToken);
            return Ok(new
            {
                token = tokenHandle.WriteToken(token)
            });
        }
    }
}
