using ArrayCalculator.Service;
using Microsoft.AspNetCore.Mvc;

namespace ArrayCalculator.Controllers
{
    /// <summary>
    /// Array calc controller class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArrayCalcController : ControllerBase
    {
        #region Private fields

        /// <summary>
        /// Service instance 
        /// </summary>
        private IArrayCalcService _arrayCalcService;

        #endregion

        #region Constructor

        /// <summary>
        /// Controller constructor
        /// </summary>
        /// <param name="arrayCalcService">Array service instance</param>
        public ArrayCalcController(IArrayCalcService arrayCalcService)
        {
            _arrayCalcService = arrayCalcService;
        }

        #endregion

        #region Action methods

        /// <summary>
        /// Reverses the productIds supplied
        /// Validates productIds input for length
        /// </summary>
        /// <param name="productIds">Int array of productIds</param>
        /// <returns>Returns the string of reversed productIds</returns>
        [HttpGet("reverse")]
        public ActionResult<string> Reverse([FromQuery]int[] productIds)
        {
            if (productIds == null || productIds.Length == 0)
            {
                return BadRequest("productIds parameter is missing");
            }

            return Ok(_arrayCalcService.Reverse(productIds));
        }

        /// <summary>
        /// Deletes a productId at the specified position
        /// Validates productIds input for length
        /// Validates position for non-zero positive value and should be less than length of productIds
        /// </summary>
        /// <param name="position">Position at which productId should be deleted</param>
        /// <param name="productIds">Int array of productIds</param>
        /// <returns>Returns the string of productIds after deleting the one at specified position</returns>
        [HttpGet("deletePart")]
        public ActionResult<string> Delete([FromQuery] int position, [FromQuery]int[] productIds)
        {
            if (productIds == null || productIds.Length == 0)
            {
                return BadRequest("productIds parameter is missing");
            }

            if (position <= 0)
            {
                return BadRequest("position should be a positive number");
            }

            if (position > productIds.Length)
            {
                return BadRequest("position should be a less than or equal to length of productIds");
            }

            return Ok(_arrayCalcService.DeletePart(position, productIds));
        }

        #endregion
    }
}