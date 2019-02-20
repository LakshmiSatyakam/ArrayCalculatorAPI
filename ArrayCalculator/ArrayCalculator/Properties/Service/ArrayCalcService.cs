using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("ArrayCalculator.UnitTest")]

namespace ArrayCalculator.Service
{
    /// <summary>
    /// Array calc service class
    /// </summary>
    internal class ArrayCalcService : IArrayCalcService
    {
        #region Implementing IArrayCalcService

        /// <summary>
        /// Reverses the productIds
        /// </summary>
        /// <param name="productIds">Int array of productIds</param>
        /// <returns>Returns the string of reversed productIds</returns>
        public string Reverse(int[] productIds)
        {
            string result = string.Empty;

            try
            {
                for (int index = productIds.Length - 1; index >= 0; index--)
                {
                    result += productIds[index].ToString();
                    result += index > 0 ? "," : string.Empty;
                }
            }
            catch (NullReferenceException)
            {
            }

            return "[" + result + "]";
        }

        /// <summary>
        /// Deletes a productId at the specified position
        /// </summary>
        /// <param name="position">Position at which productId should be deleted</param>
        /// <param name="productIds">Int array of productIds</param>
        /// <returns>Returns the string of productIds after deleting the one at specified position</returns>
        public string DeletePart(int position, int[] productIds)
        {
            string result = string.Empty;

            try
            {
                for (int index = 0; index < productIds.Length; index++)
                {
                    if (position - 1 == index)
                    {
                        continue;
                    }

                    result += productIds[index].ToString();
                    result += ",";
                }
            }
            catch (NullReferenceException)
            {
            }

            return "[" + result.TrimEnd(',') + "]";
        }
        
        #endregion
    }
}
