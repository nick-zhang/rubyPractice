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
    /// Summary description for GcRegionTest
    /// </summary>
    [TestClass]
    public class GcRegionTest
    {
        public GcRegionTest()
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
            _sut =  new GcRegion();
            _gcGridMock = new Mock<IGcGrid>();
            _position = new GcPosition(){ColumnIndex = 1, RowIndex = 1};
            _size = new GcSize(2, 2);
            _elementAnchor = new GcElementAnchor();
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Full_Anchor_Set_When_Only_One_Element_Is_Adde()
        {
            Mock<IGcElement> rowMock = new Mock<IGcElement>();
            _sut.AddElement(rowMock.Object);

            _elementAnchor.Region = GcElementAnchorType.Full;
            _sut.Draw(_gcGridMock.Object, _position, _size, _elementAnchor);

            rowMock.Verify(fw => fw.Draw(_gcGridMock.Object, _position, _size, It.Is<GcElementAnchor>(arg => (arg.Row == GcElementAnchorType.Full && arg.Region == GcElementAnchorType.Full ))));
        }

        [TestMethod]
        public void Top_Bottom_Anchor_Set_When_Two_Element_Is_Adde()
        {
            Mock<IGcElement> topRowMock = new Mock<IGcElement>();
            Mock<IGcElement> bottomRowMock = new Mock<IGcElement>();
            topRowMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));
            bottomRowMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));

            _sut.AddElement(topRowMock.Object);
            _sut.AddElement(bottomRowMock.Object);

            _elementAnchor.Region = GcElementAnchorType.Full;
            _sut.Draw(_gcGridMock.Object, _position, _size, _elementAnchor);

            topRowMock.Verify(fw => fw.Draw(_gcGridMock.Object, _position, _size, It.Is<GcElementAnchor>(arg => (arg.Row == GcElementAnchorType.Top && arg.Region == GcElementAnchorType.Full))));
            bottomRowMock.Verify(fw => fw.Draw(_gcGridMock.Object, It.Is<GcPosition>(position => position.RowIndex == 2), _size, It.Is<GcElementAnchor>(arg => (arg.Row == GcElementAnchorType.Bottom && arg.Region == GcElementAnchorType.Full))));
        }

        [TestMethod]
        public void Large_Row_Will_Not_Be_Drawn_When_Its_Height_Is_Larger_Than_Region()
        {
            Mock<IGcElement> topRowMock = new Mock<IGcElement>();
            Mock<IGcElement> bottomRowMock = new Mock<IGcElement>();
            Mock<IGcElement> largeRowMock = new Mock<IGcElement>();
            topRowMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));
            bottomRowMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));
            largeRowMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));

            _sut.AddElement(topRowMock.Object);
            _sut.AddElement(bottomRowMock.Object);
            _sut.AddElement(largeRowMock.Object);

            _elementAnchor.Region = GcElementAnchorType.Full;
            _sut.Draw(_gcGridMock.Object, _position, _size, _elementAnchor);

            topRowMock.Verify(fw => fw.Draw(_gcGridMock.Object, _position, _size, It.Is<GcElementAnchor>(arg => (arg.Row == GcElementAnchorType.Top && arg.Region == GcElementAnchorType.Full))));
            bottomRowMock.Verify(fw => fw.Draw(_gcGridMock.Object, It.Is<GcPosition>(position => position.RowIndex == 2), _size, It.Is<GcElementAnchor>(arg => (arg.Row == GcElementAnchorType.Middle && arg.Region == GcElementAnchorType.Full))));
            largeRowMock.Verify(fw => fw.Draw(It.IsAny<IGcGrid>(), It.IsAny<GcPosition>(), It.IsAny<GcSize>(), It.IsAny<GcElementAnchor>()), Times.Never());

        }

        [TestMethod]
        public void Correct_Row_Height_Size_Returned()
        {
            Mock<IGcElement> topRowMock = new Mock<IGcElement>();
            Mock<IGcElement> bottomRowMock = new Mock<IGcElement>();

            topRowMock.Setup(fw => fw.Size).Returns(new GcSize(1, 2));
            bottomRowMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));

            _sut.AddElement(topRowMock.Object);
            _sut.AddElement(bottomRowMock.Object);

            Assert.AreEqual(2, _sut.Size.Height);
            Assert.AreEqual(2, _sut.Size.Width);


        }

        private GcRegion _sut;
        private Mock<IGcGrid> _gcGridMock;
        private GcPosition _position;
        private GcSize _size;
        private GcElementAnchor _elementAnchor;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcRegionTest.cs;1 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcRegionTest.cs;1 */
