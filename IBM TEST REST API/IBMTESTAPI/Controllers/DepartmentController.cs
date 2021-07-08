using AutoMapper;
using DataAccess.Contract;
using DomainModel;
using IBMTESTAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IBMTESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> logger;
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentRepository departmentRepository)
        {
            this.logger = logger;
            this.departmentRepository = departmentRepository;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var outPut = await departmentRepository.GetAll();
                var model = Mapper.Map<List<DepartmentViewModel>>(outPut);
                return Ok(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var output = await departmentRepository.GetById(id);
                var model = Mapper.Map<DepartmentViewModel>(output);
                return Ok(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<DepartmentController>
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Post([FromBody] DepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dept = Mapper.Map<Department>(model);
                    await departmentRepository.Add(dept);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Put(int id, [FromBody] DepartmentViewModel model)
        {
            model.DeptId = id;
            try
            {
                if (ModelState.IsValid)
                {
                    var entiry = Mapper.Map<Department>(model);
                    await departmentRepository.Update(entiry);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Delete(int id)
        {
           
            try
            {  if(id > 0)
                {
                    await departmentRepository.Delete(id);
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
