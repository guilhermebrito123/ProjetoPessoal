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
        public IActionResult Create()//Vai apenas exibir o formulário para o usuário    
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)//Se os dados inseridos no formulário forem válidos, o cliente será cadastrado
            {
                _context.Veiculos.Add(veiculo);//Estou inserindo no meu bd utilizando C#
                await _context.SaveChangesAsync();//Salvo as minhas informações no meu bd. É bom usar o async pois tenho
                                                  //múltiplas tarefas dentro desse método
                return RedirectToAction("Index");//Retorno para a minha Index onde serão exibidos todos os cadastros
            }
            return View(veiculo);//Se os dados não forem válidos, a View original será retornada com msgns de erro
        }
    }
}
