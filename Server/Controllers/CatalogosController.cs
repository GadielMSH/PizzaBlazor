using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBlazor.Server.Data;
using PizzaBlazor.Shared.Models;

namespace PizzaBlazor.Server.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]//hacer que solo los usuarios autorizados revisen la info
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CatalogosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Tamanos>> Tamanos()
        {
            List<Tamanos> tamanos = new List<Tamanos>();

            tamanos = await context.Tamanos.ToListAsync();

            //tamanos = new List<Tamanos>()
            //{
            //  new Tamanos{Id = 1, Tamano="Personal", Precio=10.0f},
            //  new Tamanos{Id = 2, Tamano="Chica", Precio=20.0f},
            //  new Tamanos{Id = 3, Tamano="Mediana", Precio=30.0f},
            //  new Tamanos{Id = 4, Tamano="Grande", Precio=40.0f}
            //};
            return tamanos;
        }

        [HttpGet("tipomasa")]
        public async Task<List<TipoMasa>> Masas()
        {
            List<TipoMasa> tiposMasa = new List<TipoMasa>();
            tiposMasa = await context.TipoMasa.ToListAsync();
            //tiposMasa = new List<TipoMasa>()
            //{
            //    new TipoMasa{Id = 1, Tipo="Tradicional", Precio=15.0f},
            //    new TipoMasa{Id = 2, Tipo="Crunch", Precio=20.0f},
            //    new TipoMasa{Id = 3, Tipo="Orilla de queso", Precio=35.0f},
            //    new TipoMasa{Id = 4, Tipo="Sartén", Precio=15.0f}
            //};
            return tiposMasa;
        }

        [HttpGet("ingredientes")]
        public async Task<List<Ingrediente>> Ingredientes()
        {
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            ingredientes = await context.Ingredientes.ToListAsync();

            //ingredientes = new List<Ingrediente>()
            //{
            //    new Ingrediente{Id = 1, Nombre="Pepperoni", Precio=50.0f},
            //    new Ingrediente{Id = 2, Nombre="Salchicha", Precio=20.0f},
            //    new Ingrediente{Id = 3, Nombre="Piña y Jamon", Precio=20.0f},
            //    new Ingrediente{Id = 4, Nombre="Champiñones", Precio=40.0f},
            //    new Ingrediente{Id = 4, Nombre="Atún", Precio=40.0f}
            //};
            return ingredientes;
        }

        //[HttpPost("nvoingrediente")]
        //public async Task<int> NuevoIngrediente(Ingrediente nvoIngrediente)
        //{
        //    Ingrediente ingrediente = new Ingrediente();
        //    ingrediente = nvoIngrediente;
        //    context.Add(ingrediente);
        //    await context.SaveChangesAsync();
        //    return nvoIngrediente.Id;
        //}
    }
}
