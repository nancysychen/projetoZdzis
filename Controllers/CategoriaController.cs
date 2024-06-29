using APITeste2.Model;
using Microsoft.AspNetCore.Mvc;

namespace APITeste2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {     
        

        public CategoriaController()
        {
           
        }

        [HttpGet()]
        public IEnumerable<Categoria> Get()
        {
            return CategoriaLista.ToList();
        }

        public static List<Categoria> CategoriaLista = new List<Categoria>();


        [HttpPost()]
        public Categoria Post([FromBody] Categoria categoria)
        {
            CategoriaLista.Add(categoria);
            
            return categoria;
        }
    }
}
