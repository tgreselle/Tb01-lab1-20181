using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppTb01Lab_Greselle.Models;

namespace WebAppTb01Lab_Greselle.Controllers
{
    public class AutomovelController : Controller
    {
        private readonly AutomovelContext _context;

        public AutomovelController(AutomovelContext context)
        {
            _context = context;
        }

        // GET: Automovel
        [Route("")]
        [Route("automovel")]
        [Route("automovel/administracao/listar")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Automovel.ToListAsync());
        }

        // GET: Automovel/Details/5
        [Route("automovel/administracao/detalhes/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automovel = await _context.Automovel
                .SingleOrDefaultAsync(m => m.AutomovelId == id);
            if (automovel == null)
            {
                return NotFound();
            }

            return View(automovel);
        }

        // GET: Automovel/Create
        [Route("automovel/administracao/cadastrar")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Automovel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("automovel/administracao/cadastrar")]
        public async Task<IActionResult> Create([Bind("AutomovelId,Tipo,Descricao,Marca,Disponivel,DataCadastro")] Automovel automovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(automovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(automovel);
        }

        // GET: Automovel/Edit/5
        [Route("automovel/administracao/atualizar/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automovel = await _context.Automovel.SingleOrDefaultAsync(m => m.AutomovelId == id);
            if (automovel == null)
            {
                return NotFound();
            }
            return View(automovel);
        }

        // POST: Automovel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("automovel/administracao/atualizar/{id:int}")]
        public async Task<IActionResult> Edit(int id, [Bind("AutomovelId,Tipo,Descricao,Marca,Disponivel,DataCadastro")] Automovel automovel)
        {
            if (id != automovel.AutomovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomovelExists(automovel.AutomovelId))
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
            return View(automovel);
        }

        // GET: Automovel/Delete/5
        [Route("automovel/administracao/remover/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automovel = await _context.Automovel
                .SingleOrDefaultAsync(m => m.AutomovelId == id);
            if (automovel == null)
            {
                return NotFound();
            }

            return View(automovel);
        }

        // POST: Automovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("automovel/administracao/remover/{id:int}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var automovel = await _context.Automovel.SingleOrDefaultAsync(m => m.AutomovelId == id);
            _context.Automovel.Remove(automovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomovelExists(int id)
        {
            return _context.Automovel.Any(e => e.AutomovelId == id);
        }
    }
}
