using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slb.Horizon.GCFramework;

namespace GridGcUibaseMsTest
{
    [TestClass]
    public class GcCellStyleTest
    {       

       [TestMethod]
       public void gc_font_and_horizontal_alignment_get_test()
       {
           GcCellStyle sut = new GcCellStyle(GcFontType.TitleText, GcCellHorizontalAlignment.Left);

           GcFontType fontType = sut.Font;
           GcCellHorizontalAlignment alignment = sut.HorizontalAlignment;

           Assert.AreEqual(GcFontType.TitleText,fontType);
           Assert.AreEqual(GcCellHorizontalAlignment.Left, alignment);
       }
        
        [TestMethod]
        public void gc_font_and_horizontal_alignment_set_test()
        {
            GcCellStyle sut = new GcCellStyle(GcFontType.TitleText, GcCellHorizontalAlignment.Left);

            GcFontType fontType = sut.Font;
            GcCellHorizontalAlignment alignment = sut.HorizontalAlignment;

            Assert.AreEqual(GcFontType.TitleText, fontType);
            Assert.AreEqual(GcCellHorizontalAlignment.Left, alignment);                       

            sut.Font = GcFontType.NormalText;
            sut.HorizontalAlignment = GcCellHorizontalAlignment.Center;

            fontType = sut.Font;
            alignment = sut.HorizontalAlignment;

            Assert.AreEqual(GcFontType.NormalText, fontType);
            Assert.AreEqual(GcCellHorizontalAlignment.Center, alignment);                       

        }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcCellStyleTest.cs;1 */
/*       1*[1660835] 22-AUG-2012 10:01:07 (GMT) SLiu10 */
/*         "[P4] Add unit test for Depth Summary part 1" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcCellStyleTest.cs;1 */
