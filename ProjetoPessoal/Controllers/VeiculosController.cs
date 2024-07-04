using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPessoal.Models;

namespace ProjetoPessoal.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context;//esse _context é o contexto do bd, éa variável que está conectada ao meu contexto do bd, através dela o meu controller terá acesso aos dados.
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Veiculos.ToListAsync();//todos os dados da tabela Veiculos estão sendo armazenados dentro da variável dados, em seguida
                                                   //passo-a como parâmetro no View para que os dados dentro dela sejam retornados na View
            return View(dados);
        }  
    }
}
