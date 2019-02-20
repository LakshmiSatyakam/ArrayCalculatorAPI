using ArrayCalculator.Controllers;
using ArrayCalculator.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ArrayCalculator.UnitTest.Controllers
{
    /// <summary>
    /// Test class for ArrayCalcController
    /// </summary>
    [TestClass]
    public class ArrayCalcControllerUnitTest
    {
        #region Private fields

        /// <summary>
        /// ArrayCalc service Moq instance
        /// </summary>
        private Mock<IArrayCalcService> _mockArrayCalcService;

        /// <summary>
        /// ArrayCalcController instance
        /// </summary>
        private ArrayCalcController _arrayCalcController;

        #endregion

        #region TestInitialize

        [TestInitialize]
        public void TestInitialize()
        {
            _mockArrayCalcService = new Mock<IArrayCalcService>();
            _arrayCalcController = new ArrayCalcController(_mockArrayCalcService.Object);
        }

        #endregion

        #region Test methods

        #region Constructor tests

        [TestMethod]
        public void Constructor_Test()
        {
            ArrayCalcController controller = new ArrayCalcController(_mockArrayCalcService.Object);
            Assert.IsNotNull(controller);
        }

        #endregion

        #region Reverse action test methods

        [TestMethod]
        public void Reverse_Null_Input_Test()
        {
            ActionResult<string> result = _arrayCalcController.Reverse(null);
            Assert.IsTrue(result.Result is BadRequestObjectResult);

            Assert.IsTrue((result.Result as BadRequestObjectResult).Value.ToString() == "productIds parameter is missing");
        }

        [TestMethod]
        public void Reverse_Invalid_Input_Test()
        {
            ActionResult<string> result = _arrayCalcController.Reverse(new int[0]);
            Assert.IsTrue(result.Result is BadRequestObjectResult);

            Assert.IsTrue((result.Result as BadRequestObjectResult).Value.ToString() == "productIds parameter is missing");
        }

        [TestMethod]
        public void Reverse_Valid_Input_Test()
        {
            string res = "[5,4,3,2,1]";
            _mockArrayCalcService.Setup(x => x.Reverse(It.IsAny<int[]>())).Returns(res);

            ActionResult<string> result = _arrayCalcController.Reverse(new int[5] { 1, 2, 3, 4, 5 });
            Assert.IsTrue(result.Result is OkObjectResult);

            Assert.IsTrue((result.Result as OkObjectResult).Value.ToString() == res);
        }

        #endregion

        #region Delete part action test methods

        [TestMethod]
        public void Delete_Null_Input_Test()
        {
            ActionResult<string> result = _arrayCalcController.Delete(0, null);
            Assert.IsTrue(result.Result is BadRequestObjectResult);

            Assert.IsTrue((result.Result as BadRequestObjectResult).Value.ToString() == "productIds parameter is missing");
        }

        [TestMethod]
        public void Delete_Invalid_Input_Test()
        {
            ActionResult<string> result = _arrayCalcController.Delete(0, new int[0]);
            Assert.IsTrue(result.Result is BadRequestObjectResult);

            Assert.IsTrue((result.Result as BadRequestObjectResult).Value.ToString() == "productIds parameter is missing");
        }

        [TestMethod]
        public void Delete_Invalid_Input2_Test()
        {
            ActionResult<string> result = _arrayCalcController.Delete(0, new int[3] { 1, 2, 3 });
            Assert.IsTrue(result.Result is BadRequestObjectResult);

            Assert.IsTrue((result.Result as BadRequestObjectResult).Value.ToString() == "position should be a positive number");
        }

        [TestMethod]
        public void Delete_Invalid_Input3_Test()
        {
            ActionResult<string> result = _arrayCalcController.Delete(-10, new int[3] { 1, 2, 3 });
            Assert.IsTrue(result.Result is BadRequestObjectResult);

            Assert.IsTrue((result.Result as BadRequestObjectResult).Value.ToString() == "position should be a positive number");
        }

        [TestMethod]
        public void Delete_Invalid_Input4_Test()
        {
            ActionResult<string> result = _arrayCalcController.Delete(5, new int[3] { 1, 2, 3 });
            Assert.IsTrue(result.Result is BadRequestObjectResult);

            Assert.IsTrue((result.Result as BadRequestObjectResult).Value.ToString() == "position should be a less than or equal to length of productIds");
        }

        [TestMethod]
        public void Delete_Valid_Input_Test()
        {
            string res = "[1,2,4]";
            _mockArrayCalcService.Setup(x => x.DeletePart(It.IsAny<int>(), It.IsAny<int[]>())).Returns(res);

            ActionResult<string> result = _arrayCalcController.Delete(3, new int[4] { 1, 2, 3, 4 });
            Assert.IsTrue(result.Result is OkObjectResult);

            Assert.IsTrue((result.Result as OkObjectResult).Value.ToString() == res);
        } 

        #endregion

        #endregion
    }
}
