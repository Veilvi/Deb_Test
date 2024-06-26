
using Deb_test.DTO.Employee;
using Deb_test.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Employee;

namespace Deb_test.Controllers;


/// <summary>
/// Контроллер отдела кадров.
/// </summary>
[ApiController]
[Route("[controller]")]

public class HrDepartmentController : ControllerBase
{
    private readonly IEmployeeService _service;

    /// <summary>
    /// Конструктор с DI.
    /// </summary>
    /// <param name="service"> Сервис работы с сотрудниками. </param>
    public HrDepartmentController(IEmployeeService service)
    {
        _service = service;
    }
    
   
    /// <summary>
    /// Получение списка всех сотрудников.
    /// </summary>
    /// <returns> Список сотрудников. </returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result=await _service.GetAll();
            return StatusCode(200, result);
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);
        }
    }
 
    /// <summary>
    /// Получение сотрудника по id.
    /// </summary>
    /// <param name="id"> id сотрудника. </param>
    /// <returns> Данные сотрудника. </returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            var result = await _service.GetByID(id);
            return StatusCode(200, result);
        }
        catch (ItemNotFoundException ex)
        {
            return StatusCode(400, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);
        }
    }
 
    
     /// <summary>
     /// Добавление нового сотрудника.
     /// </summary>
     /// <param name="dto"> Данные сотрудника. </param>
     /// <returns>true/false</returns>
     [HttpPost]
     public async Task<IActionResult> Create(EmployeeCreateDto dto)
     {
         try
         {
             var result=await _service.Add(dto);
             return StatusCode(200, result);
         }
         catch (ItemNotFoundException ex)
         {
             return StatusCode(400, ex.Message);
         }
         catch (Exception ex)
         {
             return StatusCode(400, ex.Message);
         }
     }

     
     /// <summary>
     /// Обновление данных сотрудника.
     /// </summary>
     /// <param name="dto"> данные сотрудника. </param>
     /// <param name="id"> id сотрудника. </param>
     /// <returns>true/false</returns>
     [HttpPut("{id}")]
     public async Task<IActionResult> Update(EmployeeCreateDto dto, long id)
     {
         try
         {
             var result=await _service.Update(dto, id);
             return StatusCode(200, result);
         }
         catch (ItemNotFoundException ex)
         {
             return StatusCode(400, ex.Message);
         }
         catch (Exception ex)
         {
             return StatusCode(400, ex.Message);
         }
     }

     
     /// <summary>
     /// Удаление сорудника.
     /// </summary>
     /// <param name="id"> id сотрудника. </param>
     /// <returns>true/false</returns>
     [HttpDelete("{id}")]
     public async Task<IActionResult> Delete(long id)
     {
         try
         {
             var result=await _service.Delete(id);
             return StatusCode(200, result);
         }
         catch (ItemNotFoundException ex)
         {
             return StatusCode(400, ex.Message);
         }
         catch (Exception ex)
         {
             return StatusCode(400, ex.Message);
         }
     }
     
     /// <summary>
     /// Получить спиок должностей.
     /// </summary>
     /// <returns>Список должностей.</returns>
     [HttpGet("job_title")]
     public async Task<IActionResult> GetAllJobTitles()
     {
         try
         {
             var result=await _service.GetJobTitles();
             return StatusCode(200, result);
         }
         catch (Exception ex)
         {
             return StatusCode(400, ex.Message);
         }
     }
     
     /// <summary>
     /// Получение списка смен и нарушений.
     /// </summary>
     /// <returns> Список смен. </returns>
     [HttpGet("observe")]
     public async Task<IActionResult> Observe()
     {
         try
         {
             var result=await _service.Observation();
             return StatusCode(200, result);
         }
         catch (ItemNotFoundException ex)
         {
             return StatusCode(400, ex.Message);
         }
         catch (Exception ex)
         {
             return StatusCode(400, ex.Message);
         }
     }
}