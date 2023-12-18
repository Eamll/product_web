using Microsoft.AspNetCore.Mvc;

public class ProductosController : Controller
{
    private readonly ApplicationContext _context;

    public ProductosController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: Productos
    public async Task<IActionResult> Index()
    {
        return View(await _context.Producto.ToListAsync());
    }

    // GET: Productos/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Productos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,PrecioUnitario,Descripcion")] Producto producto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(producto);
    }

    private bool ProductoExists(int id)
    {
        return _context.Producto.Any(e => e.Id == id);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,PrecioUnitario,Descripcion")] Producto producto)
    {
        if (id != producto.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(producto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(producto);
    }

    // GET: Productos/Delete/id
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var producto = await _context.Producto
            .FirstOrDefaultAsync(m => m.Id == id);
        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    // POST: Productos/Delete/id
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var producto = await _context.Producto.FindAsync(id);
        _context.Producto.Remove(producto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}