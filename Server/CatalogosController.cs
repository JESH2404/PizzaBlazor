using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBlazor.Client.Shared.Models;
using PizzaBlazor.Server.Data;


namespace PizzaBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CatalogosController(ApplicationDbContext context) {
            this.context = context;

        }
        [HttpGet("tamanos")]
        public async Task<List<Tamanos>> Tamanos()
        {
            List<Tamanos> tamanos = new List<Tamanos>();
            tamanos = await context.Tamanos.ToListAsync();
            /*tamanos = new List<Tamanos>()
        {
            new Tamanos{Id=1,Tamano="Personal",Precio=10.0f},
            new Tamanos{Id=2,Tamano="Chica",Precio=20.0f},
            new Tamanos{Id=3,Tamano="Mediana",Precio=30.0f},
            new Tamanos{Id=4,Tamano="Grande",Precio=40.0f},
        };*/
            return tamanos;
        }

        [HttpGet("tipomasa")]
        public async Task<List<TipoMasa>> Masas()
        {
            List<TipoMasa> tiposMasa = new List<TipoMasa>();
            tiposMasa = await context.TipoMasas.ToListAsync();
            /*
            tiposMasa = new List<TipoMasa>()
        {
            new TipoMasa{Id=1,Tipo="Tradicional",Precio=30.0f},
            new TipoMasa{Id=2,Tipo="Crunch",Precio=25.0f},
            new TipoMasa{Id=3,Tipo="Orilla de Queso",Precio=35.0f},
            new TipoMasa{Id=4,Tipo="Sartén",Precio=45.0f},
        };*/

            return tiposMasa;
        }

        [HttpGet("ingredientes")]
        public async Task<List<Ingrediente>> Ingredientes()
        {
            List<Ingrediente> tipoIngrediente = new List<Ingrediente>();
            tipoIngrediente = await context.Ingredientes.ToListAsync();

            /*tipoIngrediente = new List<Ingrediente>()
        {
            new Ingrediente{Id=1,Nombre="Peperonni",Precio=30.0f},
            new Ingrediente{Id=2,Nombre="Jamon",Precio=25.0f},
            new Ingrediente{Id=3,Nombre="Piña",Precio=35.0f},
            new Ingrediente{Id=4,Nombre="Champiñones",Precio=45.0f},
        };
            */
            return tipoIngrediente;
        }
        [HttpPost("nvoingrediente")]
        public async Task<int> NuevoIngrediente(Ingrediente nvoIngrediente)
        {
            context.Add(nvoIngrediente);
            await context.SaveChangesAsync();
            return nvoIngrediente.Id;
        }
    } 
    
}
