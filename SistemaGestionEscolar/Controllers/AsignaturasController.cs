
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestionEscolar.Models;
using SistemaGestionEscolar.Data;

public class AsignaturasController : Controller
{
    private readonly AppDbContext _context;

    public AsignaturasController(AppDbContext context)
    {
        _context = context;
    }

    // GET: ASIGNATURAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Asignaturas.ToListAsync());
    }

    // GET: ASIGNATURAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var asignatura = await _context.Asignaturas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (asignatura == null)
        {
            return NotFound();
        }

        return View(asignatura);
    }

    // GET: ASIGNATURAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ASIGNATURAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Codigo,HorasSemanales,Descripcion")] Asignatura asignatura)
    {
        if (ModelState.IsValid)
        {
            _context.Add(asignatura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(asignatura);
    }

    // GET: ASIGNATURAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var asignatura = await _context.Asignaturas.FindAsync(id);
        if (asignatura == null)
        {
            return NotFound();
        }
        return View(asignatura);
    }

    // POST: ASIGNATURAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Codigo,HorasSemanales,Descripcion")] Asignatura asignatura)
    {
        if (id != asignatura.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(asignatura);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignaturaExists(asignatura.Id))
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
        return View(asignatura);
    }

    // GET: ASIGNATURAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var asignatura = await _context.Asignaturas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (asignatura == null)
        {
            return NotFound();
        }

        return View(asignatura);
    }

    // POST: ASIGNATURAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var asignatura = await _context.Asignaturas.FindAsync(id);
        if (asignatura != null)
        {
            _context.Asignaturas.Remove(asignatura);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AsignaturaExists(int? id)
    {
        return _context.Asignaturas.Any(e => e.Id == id);
    }
}
