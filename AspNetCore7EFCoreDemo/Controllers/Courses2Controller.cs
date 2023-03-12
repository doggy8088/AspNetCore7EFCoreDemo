using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore7EFCoreDemo.Models;
using AspNetCore7EFCoreDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace AspNetCore7EFCoreDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Courses2Controller : ControllerBase
    {
        private readonly ContosoUniversityContext db;

        public Courses2Controller(ContosoUniversityContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return db.Course.Include(p => p.Department).ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<Course> Get(int id)
        {
            var item = db.Course.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public ActionResult<Course> Post(Course item)
        {
            db.Course.Add(item);
            db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = item.CourseId }, item);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Put(int id, CourseCreate input)
        {
            if (id != input.CourseId)
            {
                return BadRequest();
            }

            //db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            var item = db.Course.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            // item.CourseId = input.CourseId;
            item.Title = input.Title;
            item.DepartmentId = input.DepartmentId;

            db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(int id)
        {
            var item = db.Course.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            db.Course.Remove(item);
            db.SaveChanges();

            return NoContent();
        }

    }
}