using Microsoft.AspNetCore.Mvc;

namespace RESTWithASPDotNETCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(Util.Util.IsNumeric(firstNumber) && Util.Util.IsNumeric(secondNumber))
            {
                decimal sum = Util.Util.ConvertToDecimal(firstNumber) + Util.Util.ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input!");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (Util.Util.IsNumeric(firstNumber) && Util.Util.IsNumeric(secondNumber))
            {
                decimal sum = Util.Util.ConvertToDecimal(firstNumber) - Util.Util.ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input!");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if (Util.Util.IsNumeric(firstNumber) && Util.Util.IsNumeric(secondNumber))
            {
                decimal sum = Util.Util.ConvertToDecimal(firstNumber) * Util.Util.ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input!");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (Util.Util.IsNumeric(firstNumber) && Util.Util.IsNumeric(secondNumber))
            {
                decimal sum = Util.Util.ConvertToDecimal(firstNumber) / Util.Util.ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input!");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (Util.Util.IsNumeric(firstNumber) && Util.Util.IsNumeric(secondNumber))
            {
                decimal sum = (Util.Util.ConvertToDecimal(firstNumber) + Util.Util.ConvertToDecimal(secondNumber)) / 2;
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input!");
        }

        [HttpGet("sqrt/{num}")]
        public IActionResult Sqrt(string num)
        {
            if (Util.Util.IsNumeric(num))
            {
                double sum = Math.Sqrt(Util.Util.ConvertToDouble(num));
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input!");
        }
    }
}