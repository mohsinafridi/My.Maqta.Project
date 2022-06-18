using EmployeeAPI.Controllers;
using EmployeeAPI.Db;
using EmployeeAPI.Models;
using EmployeeAPI.Tests.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeAPI.Tests.Controller
{
    public class EmployeeControllerTest
    {

        private readonly EmployeeController _controller;
        private readonly IEmployeeRepository _service;
        private readonly List<Employee> _employees;



        Stack<List<Employee>> employees;

        public EmployeeControllerTest()
        {
            _employees = new List<Employee>()
            {
                new Employee()
        {
            Id = 1,
                    FirstName = "Mohsin",
                    LastName = "Azam",
                    Email = "mohsin.afridi91@gmail.com" ,
                    Phone = "123123123"
                 
                },

              new Employee()
        {
            Id = 2,
                    FirstName = "Muhammad",
                    LastName = "Ali",
                    Email = "m.ali@gmail.com" ,
                    Phone = "123123123"
                  
                },
              new Employee()
        {
            Id = 3,
                    FirstName = "Abdul",
                    LastName = "Mutlib",
                    Email = "abdul.mutlib@gmail.com" ,
                    Phone = "123123123",
                }
    };
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(repo => repo.GetAllEmployees).Equals(_employees);
            var controller = new EmployeeController(mockRepo.Object);

            // Act
            var result = controller.GetAllEmployees();

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<Employee>>(result);
            Assert.Equal(3, model.Count());            
        }
    }
}
