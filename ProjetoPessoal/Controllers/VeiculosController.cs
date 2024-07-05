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
        public async Task<IActionResult> Edit(int? id)//? significa que ele pode ser null, que, caso seja o caso, retornará uma página vazia
        {
            if(id == null)
                return NotFound();//aqui é o status 404 (recurso não encontrado)

            var dados = await _context.Veiculos.FindAsync(id);//método Find() faz uma consulta no bd
            if(dados == null)
                return NotFound();
            return View(dados);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veiculo veiculo)//Aqui eu recebo como dados de entrada o id informado e achado e os dados do veículo específico para poder editá-los
        {
            if(id != veiculo.Id)
                return NotFound();
            _context.Veiculos.Update(veiculo);//Estou atualizando meus dados no bd
            await _context.SaveChangesAsync();//Salvo as minhas informações no meu bd.

            return RedirectToAction("Index");//Retorno para a minha Index onde serão exibidos todos os cadastros
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var dados = await _context.Veiculos.FindAsync(id);//puxo os dados do veículo que possui o parâmetro de entrada.
            if (dados == null)
                return NotFound();

            return View(dados);
        }

    }
}
