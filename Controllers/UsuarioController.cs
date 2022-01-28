﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiginUser.Data;
using SiginUser.Models;
using System;

namespace SiginUser.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public UsuarioController(ApplicationDbContext context)
        {
            this.context = context;
        }


        //GET:api/ususario -  ler uma lista de Categorias
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await context.Usuarios.AsNoTracking().ToListAsync();
        }

        //GET:api/usuario/1  -  ler um Usuario pelo Id
        [HttpGet("{id}", Name = "GetUsuario")]
        public async Task<ActionResult<Usuario>> Get(string id)
        {
            //return await context.Usuarios.FirstOrDefaultAsync(x => x.UserId == id);
            return await context.Usuarios.FirstOrDefaultAsync(x => x.UserId == 1);
        }

        //POST:api/usuario  - Inclui um novo Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            context.Add(usuario);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetUsuario", new { id = usuario.UserId }, usuario);
        }

        //PUT:api/usuario   -  Altera um Usuario pelo Id contido no corpo da requisição
        //PUT:api/categoria/3 -  Altera ua Usuario pelo Id contido no corpo da requisição
        [HttpPut]
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Put(int id, Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(usuario);
        }

        //Deleta um Usuario pelo Id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            var usuario = new Usuario { UserId = id };
            context.Remove(usuario);
            await context.SaveChangesAsync();
            return Ok(usuario);
        }
    }
}
