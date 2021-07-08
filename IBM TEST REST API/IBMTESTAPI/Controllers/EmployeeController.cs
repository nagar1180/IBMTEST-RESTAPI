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

namespace IBMTESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> logger;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
        {
            this.logger = logger;
            this.employeeRepository = employeeRepository;
        }
        // GET: api/<EmployeeController>
        // GET: api/<DepartmentController>
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await employeeRepository.GetAll();
                var model = Mapper.Map<List<EmployeeViewModel>>(result);
                return Ok(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await employeeRepository.GetById(id);
                var model = Mapper.Map<EmployeeViewModel>(result);
                return Ok(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Post([FromBody] EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var outPut = Mapper.Map<Employee>(model);
                    await employeeRepository.Add(outPut);
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

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeViewModel model)
        {
            model.EmpId = id;
            try
            {
                if (ModelState.IsValid)
                {
                    var entiry = Mapper.Map<Employee>(model);
                    await employeeRepository.Update(entiry);
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

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(id > 0)
                {                    
                    await employeeRepository.Delete(id);
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
