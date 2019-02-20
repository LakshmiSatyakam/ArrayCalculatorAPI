
namespace ArrayCalculator.Service
{
    /// <summary>
    /// Interface for Array calculator
    /// </summary>
    public interface IArrayCalcService
    {
        /// <summary>
        /// Reverses the productIds
        /// </summary>
        /// <param name="productIds">Int array of productIds</param>
        /// <returns>Returns the string of reversed productIds</returns>
        string Reverse(int[] productIds);

        /// <summary>
        /// Deletes a productId at the specified position
        /// </summary>
        /// <param name="position">Position at which productId should be deleted</param>
        /// <param name="productIds">Int array of productIds</param>
        /// <returns>Returns the string of productIds after deleting the one at specified position</returns>
        string DeletePart(int position, int[] productIds);
    }
}
