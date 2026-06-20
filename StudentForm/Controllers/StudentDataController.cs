
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentForm.Models;
using StudentForm.Infra;
using StudentForm.ViewModel;

public class StudentDataController : Controller
{
    private readonly AppDbContext _context;

    public StudentDataController(AppDbContext context)
    {
        _context = context;
    }

    // GET: STUDENTMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Students.ToListAsync());
    }

    // GET: STUDENTMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var studentmodel = await _context.Students
            .FirstOrDefaultAsync(m => m.Id == id);
        if (studentmodel == null)
        {
            return NotFound();
        }

        return View(studentmodel);
    }

    // GET: STUDENTMODELS/Create
    public async Task<IActionResult> Create()
    {
        List<Course> courses = await _context.Course.ToListAsync();
        StudentViewModel student = new StudentViewModel()
        {
            Courses = courses.Select(c => CourseSelectionViewModel.ToVM(c)).ToList()
        };
        return View(student);
    }

    // POST: STUDENTMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Email,Age,Course,EnrollmentId,Specialisation,Message")] StudentModel studentmodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(studentmodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(studentmodel);
    }

    // GET: STUDENTMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var studentmodel = await _context.Students.FindAsync(id);
        if (studentmodel == null)
        {
            return NotFound();
        }
        return View(studentmodel);
    }

    // POST: STUDENTMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Email,Age,Course,EnrollmentId,Specialisation,Message")] StudentModel studentmodel)
    {
        if (id != studentmodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(studentmodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(studentmodel.Id))
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
        return View(studentmodel);
    }

    // GET: STUDENTMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var studentmodel = await _context.Students
            .FirstOrDefaultAsync(m => m.Id == id);
        if (studentmodel == null)
        {
            return NotFound();
        }

        return View(studentmodel);
    }

    // POST: STUDENTMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var studentmodel = await _context.Students.FindAsync(id);
        if (studentmodel != null)
        {
            _context.Students.Remove(studentmodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StudentModelExists(int? id)
    {
        return _context.Students.Any(e => e.Id == id);
    }
}
