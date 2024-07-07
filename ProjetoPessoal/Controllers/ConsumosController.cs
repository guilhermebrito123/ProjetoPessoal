using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoPessoal.Models;

namespace ProjetoPessoal.Controllers
{
    public class ConsumosController : Controller
    {
        private readonly AppDbContext _context;
        
        public ConsumosController(AppDbContext context)
        {
            _context = context;
        } 

        //GET: Consumos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Consumos.Include(c => c.Veiculo);
            return View(await appDbContext.ToListAsync());
        }

        //GET: Consumos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.Consumos == null) 
            {
                return NotFound();
            }
            var consumo = await _context.Consumos.Include(c => c.Veiculo).FirstOrDefaultAsync(m => m.Id == id);
            if(consumo == null)
            {
                return NotFound();
            }
            return View(consumo);   
        }

        //GET: Consumos/Create
        public IActionResult Create()
        {
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome");
            return View();
        }

        //POST: Consumos/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to.
        //For more details, see http://go.microsoft.com/fwlink/?LinkId=317598
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Descricao, Data, Valor, Km, Tipo, VeiculoId")] Consumo consumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome", consumo.VeiculoId);
            return View(consumo);
        }
        //GET: Consumos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.Consumos == null)
            {
                return NotFound();
            }
            var consumo = await _context.Consumos.FindAsync(id);
            if(consumo == null)
            {
                return NotFound();
            }
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome", consumo.VeiculoId);
            return View(consumo);
         }

        //POST: Consumos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("Id, Descricao, Data, Valor, Km, Tipo, VeiculoId")] Consumo consumo)
        {
            if(id != consumo.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumoExists(consumo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome", consumo.VeiculoId);
            return View(consumo);
        }

        private bool ConsumoExists(int id)
        {
            return _context.Veiculos.Any(e => e.Id == id);
        }

        //GET: Consumos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || _context.Consumos == null)
            {
                return NotFound();
            }
            var consumo = await _context.Consumos.Include(c => c.Veiculo).FirstOrDefaultAsync(m => m.Id == id);
            if(consumo == null)
            {
                return NotFound();
            }
            return View (consumo);
        }

        //POST: Consumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_context.Consumos == null)
            {
                return Problem("Entity set 'AppDbContext.Consumos' is null.");
            }
            var consumo = await _context.Consumos.FindAsync(id);
            if(consumo != null)
            {
                _context.Consumos.Remove(consumo);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
