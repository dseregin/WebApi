using Microsoft.AspNetCore.Mvc;
using System;
using ES = LkWebApi.ExpressionService;

namespace LkWebApi.Controllers
{
    /// <summary>
    /// Контроллер для обработки выражения
    /// </summary>
    [Route("api/[controller]")]
    public class ExpressionController : ControllerBase
    {
        private ES.ExpressionService _expressionService;

        public ExpressionController(ES.ExpressionService expressionService)
        {
            _expressionService = expressionService;
        }

        /// <summary>
        /// Вычисление значения выражения в постфиксной записи
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Calculate(string expression)
        {
            try
            {
                var result = _expressionService.Calculate(expression);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
