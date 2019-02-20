using ArrayCalculator.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayCalculator.UnitTest.Service
{
    /// <summary>
    /// Test class for ArrayCalcService
    /// </summary>
    [TestClass]
    public class ArrayCalcServiceUnitTest
    {
        #region Private fields

        /// <summary>
        /// IArrayCalcService instance
        /// </summary>
        private ArrayCalcService _arrayCalcService;

        #endregion

        #region Constructor

        public ArrayCalcServiceUnitTest()
        {
            _arrayCalcService = new ArrayCalcService();
        }

        #endregion

        #region Test methods

        #region Reverse test methods

        [TestMethod]
        public void Reverse_Null_Input_Test()
        {
            string result = _arrayCalcService.Reverse(null);
            Assert.IsTrue(result == "[]");
        }

        [TestMethod]
        public void Reverse_Zero_Length_Test()
        {
            string result = _arrayCalcService.Reverse(new int[0]);
            Assert.IsTrue(result == "[]");
        }

        [TestMethod]
        public void Reverse_One_Length_Test()
        {
            string result = _arrayCalcService.Reverse(new int[1] { 1 });
            Assert.IsTrue(result == "[1]");
        }

        [TestMethod]
        public void Reverse_MoreThanOne_Length_Test()
        {
            string result = _arrayCalcService.Reverse(new int[4] { 1,2,3,4 });
            Assert.IsTrue(result == "[4,3,2,1]");
        }

        [TestMethod]
        public void Reverse_MoreThanOne_Length2_Test()
        {
            string result = _arrayCalcService.Reverse(new int[4] { 101, 201, 3, 401 });
            Assert.IsTrue(result == "[401,3,201,101]");
        }

        #endregion

        #region Delete part test methods

        [TestMethod]
        public void Delete_Null_Input_Test()
        {
            string result = _arrayCalcService.DeletePart(0, null);
            Assert.IsTrue(result == "[]");
        }

        [TestMethod]
        public void Delete_Negative_Position_Input_Test()
        {
            string result = _arrayCalcService.DeletePart(-1, new int[3] { 1,2,3 });
            Assert.IsTrue(result == "[1,2,3]");
        }
        
        [TestMethod]
        public void Delete_Zero_Length_Test()
        {
            string result = _arrayCalcService.DeletePart(0, new int[0]);
            Assert.IsTrue(result == "[]");
        }

        [TestMethod]
        public void Delete_One_Length_Test()
        {
            string result = _arrayCalcService.DeletePart(1, new int[1] { 1 });
            Assert.IsTrue(result == "[]");
        }

        [TestMethod]
        public void Delete_MoreThanOne_Length_Test()
        {
            string result = _arrayCalcService.DeletePart(2, new int[4] { 1, 2, 3, 4 });
            Assert.IsTrue(result == "[1,3,4]");
        }

        [TestMethod]
        public void Delete_MoreThanOne_Length2_Test()
        {
            string result = _arrayCalcService.DeletePart(1, new int[4] { 101, 201, 3, 401 });
            Assert.IsTrue(result == "[201,3,401]");
        }

        [TestMethod]
        public void Delete_MoreThanOne_Length3_Test()
        {
            string result = _arrayCalcService.DeletePart(4, new int[4] { 101, 201, 3, 401 });
            Assert.IsTrue(result == "[101,201,3]");
        }

        #endregion

        #endregion
    }
}
