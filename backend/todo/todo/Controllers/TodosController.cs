using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todos.Models;

namespace todos.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController: ControllerBase
    {
        //private static List<string> all = new List<string>()
        //{
        //    "Remodle Bathroom",
        //    "Finish my Laser app",
        //    "Do things with kids"
        //};

        private IRepository<Todo> todoRepo;
        public TodosController(IRepository<Todo> todoRepo)
        {
            this.todoRepo = todoRepo;
        }

        // GET api/todos
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return todoRepo.GetAll();
        }

        // GET api/todos/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "todos";
        }

        // POST api/todos
        [HttpPost]
        public IEnumerable<Todo> Post([FromBody] Todo todos)
        {
            todoRepo.Create(todos);
            return todoRepo.GetAll();
        }



        // PUT api/todos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string todos)
        {
        }

        // DELETE api/todos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
