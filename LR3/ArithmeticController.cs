// ArithmeticController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ArithmeticController : ControllerBase
{
    private readonly CalcService _calcService;

    public ArithmeticController(CalcService calcService)
    {
        _calcService = calcService;
    }

    // GET /arithmetic/add?a=5&b=3
    [HttpGet("add")]
    public IActionResult Add(int a, int b)
    {
        var result = _calcService.Add(a, b);
        return Ok(result);
    }



    // GET /arithmetic/subtract?a=5&b=3
    [HttpGet("subtract")]
    public IActionResult Subtract(int a, int b)
    {
        var result = _calcService.Subtract(a, b);
        return Ok(result);
    }

    [HttpGet("multiply")]
    public IActionResult Multiply(int a, int b)
    {
        var result = _calcService.Multiply(a, b);
        return Ok(result);
    }
    [HttpGet("divide")]
    public IActionResult Divide(int a, int b)
    {
        try
        {
            var result = _calcService.Divide(a, b);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
