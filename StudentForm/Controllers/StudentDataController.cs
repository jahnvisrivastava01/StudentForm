
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
        var students = await _context.Students
                                     .Include(s => s.Courses)
                                     .ToListAsync();

        return View(students);
    }

    // GET: STUDENTMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var studentmodel = await _context.Students
            .Include(s=>s.Courses).FirstOrDefaultAsync(m=>m.Id == id);
        if (studentmodel == null)
        {
            return NotFound();
        }

        return View(studentmodel);
    }

    
    // GET: StudentData/Create
    public async Task<IActionResult> Create()
    {
        List<Course> courses = await _context.Course.ToListAsync();

        StudentViewModel student = new StudentViewModel()
        {
            Courses = courses
                        .Select(c => CourseSelectionViewModel.ToVM(c))
                        .ToList()
        };

        return View(student);
    }

    // POST: STUDENTMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // POST: StudentData/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StudentViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            vm.Courses = await _context.Course
                                       .Select(c => CourseSelectionViewModel.ToVM(c))
                                       .ToListAsync();

            return View(vm);
        }

        StudentModel student = new StudentModel()
        {
            Name = vm.Name,
            Email = vm.Email,
            Age = vm.Age,
            EnrollmentId = vm.EnrollmentId,
            Specialisation = vm.Specialisation
        };

        var selectedCourseIds = vm.Courses
                           .Where(x => x.isSelected)
                           .Select(x => x.Id)
                           .ToList();

        student.Courses = await _context.Course
                                        .Where(c => selectedCourseIds.Contains(c.Id))
                                        .ToListAsync();

        _context.Students.Add(student);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // GET: STUDENTMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var studentmodel = await _context.Students
                                         .Include(s => s.Courses)
                                         .FirstOrDefaultAsync(s => s.Id == id);

        if (studentmodel == null)
        {
            return NotFound();
        }

        var selectedCourseIds = studentmodel.Courses
                                            .Select(x => x.Id)
                                            .ToHashSet();

        var allCourses = await _context.Course.ToListAsync();

        StudentViewModel vm = new StudentViewModel()
        {
            Id = studentmodel.Id,
            Name = studentmodel.Name,
            Email = studentmodel.Email,
            Age = studentmodel.Age,
            EnrollmentId = studentmodel.EnrollmentId,
            Specialisation = studentmodel.Specialisation,

            Courses = allCourses.Select(c => new CourseSelectionViewModel
            {
                Id = c.Id,
                CourseName = c.CourseName,
                isSelected = selectedCourseIds.Contains(c.Id)
            }).ToList()
        };

        return View(vm);
    }

    // POST: STUDENTMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, StudentViewModel vm)
    {
        if (id != vm.Id)
        {
            return NotFound();
        }
        Console.WriteLine("ModelState Valid = " + ModelState.IsValid);

        if (!ModelState.IsValid)
        {
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    Console.WriteLine($"{state.Key} : {error.ErrorMessage}");
                }
            }

            var allCourses = await _context.Course.ToListAsync();

            vm.Courses = allCourses.Select(c => new CourseSelectionViewModel
            {
                Id = c.Id,
                CourseName = c.CourseName,
                isSelected = vm.Courses != null &&
                             vm.Courses.Any(x => x.Id == c.Id && x.isSelected)
            }).ToList();

            return View(vm);
        }

        var student = await _context.Students
                                    .Include(s => s.Courses)
                                    .FirstOrDefaultAsync(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        student.Name = vm.Name;
        student.Email = vm.Email;
        student.Age = vm.Age;
        student.EnrollmentId = vm.EnrollmentId;
        student.Specialisation = vm.Specialisation;

        var selectedIds = vm.Courses
                            .Where(c => c.isSelected)
                            .Select(c => c.Id)
                            .ToList();

        student.Courses = await _context.Course
                                        .Where(c => selectedIds.Contains(c.Id))
                                        .ToListAsync();

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
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





    
