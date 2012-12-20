using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Slb.Horizon.GCFramework;

namespace GridGcUibaseMsTest
{
    /// <summary>
    /// Summary description for GcRowTest
    /// </summary>
    [TestClass]
    public class GcRowTest
    {
        public GcRowTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _gcGridMock = new Mock<IGcGrid>();
            _position = new GcPosition() { ColumnIndex = 1, RowIndex = 1 };
            _size = new GcSize(2, 3);
            _elementAnchor = new GcElementAnchor();
            _sut = new GcRow();

            _leftCellMock = new Mock<IGcElement>();
            _middleCellMock = new Mock<IGcElement>();
            _rightCellMock = new Mock<IGcElement>();

            _leftCellMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));
            _middleCellMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));
            _rightCellMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));

            _sut.AddElement(_leftCellMock.Object);
            _sut.AddElement(_middleCellMock.Object);
            _sut.AddElement(_rightCellMock.Object);
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Cells_Are_Drawn_Correctly_With_Right_Anchor_Set()
        {
            _sut.Draw(_gcGridMock.Object, _position, _size, _elementAnchor);

            VerifyCellCorrectlyDrawn(_leftCellMock, 1, GcElementAnchorType.Left);
            VerifyCellCorrectlyDrawn(_middleCellMock, 2, GcElementAnchorType.Middle);
            VerifyCellCorrectlyDrawn(_rightCellMock, 3, GcElementAnchorType.Right);
        }

        

        [TestMethod]
        public void Large_Cell_Not_Drawn_When_Its_Width_Is_Bigger_Than_Row()
        {
            Mock<IGcElement> largeCellMock = new Mock<IGcElement>();

            largeCellMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));
            
            _sut.AddElement(largeCellMock.Object);

            _sut.Draw(_gcGridMock.Object, _position, _size, _elementAnchor);

            VerifyCellCorrectlyDrawn(_leftCellMock, 1, GcElementAnchorType.Left);
            VerifyCellCorrectlyDrawn(_middleCellMock, 2, GcElementAnchorType.Middle);
            VerifyCellCorrectlyDrawn(_rightCellMock, 3, GcElementAnchorType.Middle);
            
            VerifyCellNeverDrawn(largeCellMock);
        }

        private void VerifyCellCorrectlyDrawn(Mock<IGcElement> cellMock, int columnIndex, GcElementAnchorType cellAnchor)
        {
            cellMock.Verify(
                fw =>
                fw.Draw(_gcGridMock.Object, It.Is<GcPosition>(position => position.ColumnIndex == columnIndex), _size,
                        It.Is<GcElementAnchor>(anchor => anchor.Cell == cellAnchor)));
        }
        private void VerifyCellNeverDrawn(Mock<IGcElement> largeCellMock)
        {
            largeCellMock.Verify(
                fw => fw.Draw(It.IsAny<IGcGrid>(), It.IsAny<GcPosition>(), It.IsAny<GcSize>(), It.IsAny<GcElementAnchor>()),
                Times.Never());
        }

        [TestMethod]
        public void Calculate_Right_Row_Height_And_Size()
        {
            Assert.AreEqual(1, _sut.Size.Height);
            Assert.AreEqual(3, _sut.Size.Width);
        }

        private GcRow _sut;
        private Mock<IGcGrid> _gcGridMock;
        private GcPosition _position;
        private GcSize _size;
        private GcElementAnchor _elementAnchor;
        private Mock<IGcElement> _leftCellMock;
        private Mock<IGcElement> _middleCellMock;
        private Mock<IGcElement> _rightCellMock;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcRowTest.cs;1 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcRowTest.cs;1 */
