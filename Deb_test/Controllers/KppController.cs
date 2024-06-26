using Deb_test.DTO.WorkShift;
using Deb_test.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.WorkShift;

namespace Deb_test.Controllers;

/// <summary>
/// Контроллер КПП
/// </summary>
[ApiController]
[Route("[controller]")]
public class KppController : ControllerBase
{
    private readonly IWorkShiftService _service;

    /// <summary>
    /// Конструктор с DI.
    /// </summary>
    /// <param name="service"> Сервис работы со сменами. </param>
    public KppController(IWorkShiftService service)
    {
        _service = service;
    }
    
    /// <summary>
    /// Начало смены.
    /// </summary>
    /// <param name="data"> Номер пропуска и время от КПП </param>
    /// <returns>true/false</returns>
    [HttpPost("start")]
    public async Task<IActionResult> StartShift(KppDataDto data) // Пока здесь инициализирую данные
    {
        try
        {
            var result = await _service.StartShift(data);
            return Ok(result);
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
    /// Конец смены.
    /// </summary>
    /// <param name="data"> Номер пропуска и время от КПП </param>
    /// <returns>true/false</returns>
    [HttpPost("end")]
    public async Task<IActionResult> EndShift(KppDataDto data) // Пока здесь инициализирую данные
    {
        try
        {
            var result = await _service.EndShift(data);
            return Ok(result);
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