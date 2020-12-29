using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogSystem.Data;
using BlogSystem.Models;

/// <summary>
/// Blog controller CRUD
/// </summary>
namespace BlogSystem.Controllers
{
    public class BlogsController : Controller
    {
        private readonly BlogSystemContext _context;

        public BlogsController(BlogSystemContext context)
        {
            _context = context;
        }

        // GET: Blogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blogs.ToListAsync());
        }

        // GET: Blogs that have status pending to approve, returns JSON.
        public async Task<IActionResult> IndexJSON()
        {
            var blog = await _context.Blogs
                .Where(m => m.status == 1)
                .ToListAsync();

            return Json (blog);

        }

        // GET: Blog with determined value that have status Approved and list of Status and Comments
        public async Task<IActionResult> UserView(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .Where(m => m.id == id && m.status == 2)
                .Include(ms => ms.BlogStatus)
                .Include(mc => mc.Comments)
                .FirstOrDefaultAsync();

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Blog with determined value and list of Status
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .Where(m => m.id == id)
                .Include(ms => ms.BlogStatus)
                .FirstOrDefaultAsync();

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Blogs/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Add comment to a determined Blog
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment([Bind("blog_id,comment,comment_date,alt_name,user_id")] Comments C)
        {
            if (ModelState.IsValid)
            {
                _context.Comments.Add(C);
                await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(UserView),new { id = C.blog_id});

            }
            return View(C);
        }


        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,blog_title,blog_text,user_id,creation_date,approval_date,last_mod_date,status")] Blogs blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Edit determined Blog
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        //GET: Edit status of determined Blog, returns JSON
        public async Task<IActionResult> EditJSON(int id, int BlogStatus)
        {
            
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            
            try
            {
                blog.last_mod_date = DateTime.Now;
                if (BlogStatus == 2)
                {
                    blog.approval_date = DateTime.Now;
                }
                blog.status = BlogStatus;

                _context.Update(blog);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(blog.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return Json(blog);
        }

        // POST: Edit determined Blog
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,blog_title,blog_text,user_id,creation_date,approval_date,last_mod_date,status")] Blogs blog)
        
        {
            if (id != blog.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    blog.last_mod_date = DateTime.Now;
                    if (blog.status == 2) {
                        blog.approval_date = DateTime.Now;
                    }
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.id))
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
            return View(blog);
        }

        // GET: Show determined Blog to be deleted
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .FirstOrDefaultAsync(m => m.id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Delete determined Blog after confirm
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.id == id);
        }
    }
}
