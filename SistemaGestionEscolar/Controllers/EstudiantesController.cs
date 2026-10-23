
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGestionEscolar.Models;
using SistemaGestionEscolar.Data;

public class EstudiantesController : Controller
{
    private readonly AppDbContext _context;

    public EstudiantesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: ESTUDIANTES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Estudiantes.ToListAsync());
    }

    // GET: ESTUDIANTES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var estudiante = await _context.Estudiantes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (estudiante == null)
        {
            return NotFound();
        }

        return View(estudiante);
    }

    // GET: ESTUDIANTES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ESTUDIANTES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Correo,Cedula")] Estudiante estudiante)
    {
        if (ModelState.IsValid)
        {
            _context.Add(estudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(estudiante);
    }

    // GET: ESTUDIANTES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var estudiante = await _context.Estudiantes.FindAsync(id);
        if (estudiante == null)
        {
            return NotFound();
        }
        return View(estudiante);
    }

    // POST: ESTUDIANTES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Apellido,Correo,Cedula")] Estudiante estudiante)
    {
        if (id != estudiante.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(estudiante);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(estudiante.Id))
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
        return View(estudiante);
    }

    // GET: ESTUDIANTES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var estudiante = await _context.Estudiantes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (estudiante == null)
        {
            return NotFound();
        }

        return View(estudiante);
    }

    // POST: ESTUDIANTES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var estudiante = await _context.Estudiantes.FindAsync(id);
        if (estudiante != null)
        {
            _context.Estudiantes.Remove(estudiante);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EstudianteExists(int? id)
    {
        return _context.Estudiantes.Any(e => e.Id == id);
    }
}
