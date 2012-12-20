using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slb.Horizon.GCFramework;
using Moq;

namespace GridGcUibaseMsTest
{
    /// <summary>
    /// Summary description for GcBlockTest
    /// </summary>
    [TestClass]
    public class GcBlockTest
    {
        public GcBlockTest()
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
            _position = new GcPosition();
            _size = new GcSize(1, 2);
            _elementAnchor = new GcElementAnchor();

            _sut = new GcBlock(4);
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
            Mock<IGcElement> regionMock = new Mock<IGcElement>();
            _sut.AddElement(regionMock.Object);


            _sut.Draw(_gcGridMock.Object, _position, _size, _elementAnchor);

            regionMock.Verify(fw => fw.Draw(_gcGridMock.Object, _position, _size, It.Is<GcElementAnchor>(arg => arg.Region == GcElementAnchorType.Full)));
        }

        [TestMethod]
        public void Left_Right_Anchor_Set_When_Two_Element_Is_Adde()
        {
            Mock<IGcElement> leftRegionMock = new Mock<IGcElement>();
            Mock<IGcElement> rightRegionMock = new Mock<IGcElement>();

            leftRegionMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));
            rightRegionMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));

            _sut.AddElement(leftRegionMock.Object);
            _sut.AddElement(rightRegionMock.Object);


            _sut.Draw(_gcGridMock.Object, _position, _size, _elementAnchor);

            leftRegionMock.Verify(fw => fw.Draw(_gcGridMock.Object, _position, _size, It.Is<GcElementAnchor>(arg => arg.Region == GcElementAnchorType.Left)));
            rightRegionMock.Verify(fw => fw.Draw(_gcGridMock.Object, It.Is<GcPosition>(position => position.ColumnIndex == 1), _size, It.Is<GcElementAnchor>(arg => arg.Region == GcElementAnchorType.Right)));
        }

        [TestMethod]
        public void Region_Does_Not_Call_When_Size_Exceed_Block_Size()
        {
            Mock<IGcElement> leftRegionMock = new Mock<IGcElement>();
            Mock<IGcElement> rightRegionMock = new Mock<IGcElement>();
            Mock<IGcElement> largeRegionMock = new Mock<IGcElement>();

            leftRegionMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));
            rightRegionMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));
            largeRegionMock.Setup(fw => fw.Size).Returns(new GcSize(1, 4));
            _sut.AddElement(leftRegionMock.Object);
            _sut.AddElement(rightRegionMock.Object);
            _sut.AddElement(largeRegionMock.Object);


            _sut.Draw(_gcGridMock.Object, _position, _size, _elementAnchor);

            leftRegionMock.Verify(fw => fw.Draw(_gcGridMock.Object, _position, _size, It.Is<GcElementAnchor>(arg => arg.Region == GcElementAnchorType.Left)));
            rightRegionMock.Verify(fw => fw.Draw(_gcGridMock.Object, It.Is<GcPosition>(position => position.ColumnIndex == 1), _size, It.Is<GcElementAnchor>(arg => arg.Region == GcElementAnchorType.Middle)));
            largeRegionMock.Verify(fw => fw.Draw(It.IsAny<IGcGrid>(), It.IsAny<GcPosition>(), It.IsAny<GcSize>(), It.IsAny<GcElementAnchor>()), Times.Never());
            
        }

        [TestMethod]
        public void Max_Row_Height_Returned()
        {
            Mock<IGcElement> leftRegionMock = new Mock<IGcElement>();
            Mock<IGcElement> rightRegionMock = new Mock<IGcElement>();
            Mock<IGcElement> largeRegionMock = new Mock<IGcElement>();

            leftRegionMock.Setup(fw => fw.Size).Returns(new GcSize(1, 1));
            rightRegionMock.Setup(fw => fw.Size).Returns(new GcSize(2, 1));
            largeRegionMock.Setup(fw => fw.Size).Returns(new GcSize(4, 4));
            _sut.AddElement(leftRegionMock.Object);
            _sut.AddElement(rightRegionMock.Object);
            _sut.AddElement(largeRegionMock.Object);

            Assert.AreEqual(4, _sut.Size.Height);
        }



        private GcBlock _sut;
        private Mock<IGcGrid> _gcGridMock;
        private GcPosition _position;
        private GcSize _size;
        private GcElementAnchor _elementAnchor;
        
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcBlockTest.cs;1 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcBlockTest.cs;1 */
