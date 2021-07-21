using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerokuCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        public ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("add")]
        public int Add([FromQuery] int lhs, [FromQuery] int rhs)
        {
            int result;
            try
            {
                checked
                {
                    result = lhs + rhs;
                }
            }
            catch (OverflowException ex)
            {
                _logger.LogError("Overflow error, operands: {0} {1} Exception: {2}", lhs, rhs, ex);
                throw;
            }

            return result;
        }

        [HttpGet("subtract")]
        public int Subtract([FromQuery] int lhs, [FromQuery] int rhs)
        {
            int result;
            try
            {
                checked
                {
                    result = lhs - rhs;
                }
            }
            catch (OverflowException ex)
            {
                _logger.LogError("Overflow error, operands: {0} {1} Exception: {2}", lhs, rhs, ex);
                throw;
            }

            return result;
        }

        [HttpGet("multiply")]
        public int Multiply([FromQuery] int lhs, [FromQuery] int rhs)
        {
            int result;
            try
            {
                checked
                {
                    result = lhs * rhs;
                }
            }
            catch (OverflowException ex)
            {
                _logger.LogError("Overflow error, operands: {0} {1} Exception: {2}", lhs, rhs, ex);
                throw;
            }

            return result;
        }

        [HttpGet("divide")]
        public double Divide([FromQuery] int lhs, [FromQuery] int rhs)
        {
            double result;
            try
            {
                checked
                {
                    result = lhs / rhs;
                }
            }
            catch (DivideByZeroException ex)
            {
                _logger.LogError("Divide by zero error, operands: {0} {1} Exception: {2}", lhs, rhs, ex);
                throw;
            }

            return result;
        }
    }
}
