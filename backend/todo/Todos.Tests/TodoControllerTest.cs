using System;
using Xunit;
using todos.Controllers;
using System.Linq;

namespace todos.Tests
{
    public class TodoControllerTest
    {
        [Fact]
        public void Get_Returns_List_of_Todos()
        {
            var underTest = new TodosController();

            var result = underTest.Get();

            Assert.Equal(3, result.Value.Count());
        }

        [Fact]
        public void Post_Creates_New_Todo()
        {
            var underTest = new TodosController();

            var result = underTest.Post("New task");

            Assert.Contains("New task", result.Value);
        }
    }
}
