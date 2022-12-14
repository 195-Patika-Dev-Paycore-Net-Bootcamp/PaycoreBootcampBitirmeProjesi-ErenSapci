using AutoMapper;
using BootcampFinalProject.Base.Response;
using BootcampFinalProject.Models;
using BootcampFinalProject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace BootcampFinalProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;


        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }
        //get method listing all categories
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = categoryService.GetAll();
            return Ok(users);
        }
        //Method by which categories can be updated according to Id
        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryDto model)
        {
            categoryService.Update(id, model);
            return Ok(new { message = "Category updated successfully" });
        }

        //post method where we can add a new category
        [HttpPost]
        public IActionResult Post(CategoryDto model)
        {
            categoryService.Insert(model);
            return Ok(new { message = "Category Posted" });
        }
        //the method we used to remove categories
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            categoryService.Remove(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
