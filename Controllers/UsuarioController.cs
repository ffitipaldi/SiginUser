using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiginUser.Data;
using SiginUser.Models;

namespace SiginUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //-------------------------------------------------//
        //Pega o contexto do banco de dados
        //-------------------------------------------------//
        private readonly ApplicationDbContext context;

        public UsuarioController(ApplicationDbContext context)
        {
            this.context = context;
        }

        ///-------------------------------------------------//
        /// <summary>
        /// GET:api/ususario/GetUsuarios -  lista com todos os Usuarios
        /// </summary>
        /// <returns></returns>
        ///-------------------------------------------------//
        ///
        [HttpGet("GetUsuarios", Name = "GetUsuarios")]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            return await context.Usuarios.AsNoTracking()
                .OrderBy(x => x.UserName)
                .ToListAsync();
        }



        ///----------------------------------------------------------------//
        /// <summary>
        /// GET:api/usuario/GetUsuarioById/{id}  -  ler um Usuario pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// ---------------------------------------------------------------//
        /// 
        [HttpGet("GetUsuarioById/{id}", Name = "GetUsuarioById")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            return await context.Usuarios
                .Where(x => x.UserId == id)
                .FirstOrDefaultAsync();
        }

        ///-----------------------------------------------------------//
        /// <summary>
        /// POST:api/usuario/AddUsuario  - Inclui um novo Usuario
        /// </summary>
        /// <param name="usuario">JASON com o id = 0</param>
        /// <returns></returns>
        ///-----------------------------------------------------------//
        ///
        [HttpPost("AddUsuario", Name = "AddUsuario")]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            context.Add(usuario);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetUsuarioById", new { id = usuario.UserId }, usuario);
        }



        ///-----------------------------------------------------------------------------------------//
        /// <summary>
        /// PUT:api/usuario/UpdateUsuarioById/{id} -  Altera ua Usuario pelo Id contido no corpo da requisição
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        ///-----------------------------------------------------------------------------------------//
        ///
        [HttpPut("UpdateUsuarioById/{id}", Name = "UpdateUsuarioById")]

        public async Task<ActionResult<Usuario>> Put(int id, Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(usuario);
        }


        ///--------------------------------------------------------------------//
        /// <summary>
        /// Delete:api/usuario/DeleteUsuarioById/{id} - Deleta um usuario pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ///--------------------------------------------------------------------//
        ///
        [HttpDelete("DeleteUsuarioById/{id}", Name = "DeleteUsuarioById")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            var usuario = new Usuario { UserId = id };
            context.Remove(usuario);
            await context.SaveChangesAsync();
            return Ok(usuario);
        }
    }
}
