
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestionEscolar.Models;
using SistemaGestionEscolar.Data;

public class AulasController : Controller
{
    private readonly AppDbContext _context;

    public AulasController(AppDbContext context)
    {
        _context = context;
    }

    // GET: AULAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Aulas.ToListAsync());
    }

    // GET: AULAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var aula = await _context.Aulas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (aula == null)
        {
            return NotFound();
        }

        return View(aula);
    }

    // GET: AULAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: AULAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Capacidad,Ubicacion,Codigo")] Aula aula)
    {
        if (ModelState.IsValid)
        {
            _context.Add(aula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(aula);
    }

    // GET: AULAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var aula = await _context.Aulas.FindAsync(id);
        if (aula == null)
        {
            return NotFound();
        }
        return View(aula);
    }

    // POST: AULAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Capacidad,Ubicacion,Codigo")] Aula aula)
    {
        if (id != aula.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(aula);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AulaExists(aula.Id))
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
        return View(aula);
    }

    // GET: AULAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var aula = await _context.Aulas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (aula == null)
        {
            return NotFound();
        }

        return View(aula);
    }

    // POST: AULAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var aula = await _context.Aulas.FindAsync(id);
        if (aula != null)
        {
            _context.Aulas.Remove(aula);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AulaExists(int? id)
    {
        return _context.Aulas.Any(e => e.Id == id);
    }
}
