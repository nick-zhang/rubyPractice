using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.Serialization;
using Syncfusion.Drawing;
using Syncfusion.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using Syncfusion.Windows.Forms.Grid;
using Slb.Horizon.Products.GenericComponents;

namespace Slb.Horizon.GCFramework
{
    public enum Orientation
    {
        Portrait = 0,
        Landscape = 1
    }

    /// <summary>
    /// Base class for Essential Gird based graphical components.
    /// </summary>
    /// <remarks>
    /// It is assumed that 
    /// 
    /// 1. Only one grid is included in the component and;
    /// 2. Default label is not used.
    /// 3. All cells are serializable. This implies that you cannot embed a grid inside a grid since
    ///    grid itself is not serializable.
    /// 
    /// Derived class has to set the values of the following during the construction of the grid:
    /// 
    /// 1. m_PrintHeight (except header: header needs to set m_PrintWidth).
    /// 2. m_Orientation;
    /// 
    /// This base class will implement all printing related virtual methods. Derived classes only 
    /// need to create the Grid instance for display (gridControlMain) and override some non-printing related
    /// virtual methods/Properties.
    /// </remarks>
    public class GridGraphicalComponentUIBase : GraphicalComponentUIBase
    {
        #region private variables
        /// <summary>
        /// Orientation when printed.
        /// </summary>
        protected Orientation m_Orientation;	
		
		/// <summary>
        /// Offset of print start point from the top of the component in points.
		/// </summary>						
        protected double m_OffsetY;	
		
        /// <summary>
        /// Grid control for display.
		/// </summary>
        protected SlbGridControl2 gridControlMain;
        
        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GridGraphicalComponentUIBase()
        {
            m_Orientation = Orientation.Portrait;
            m_OffsetY = 0.0;
            m_PrintHeight = 0.0;
            gridControlMain = null;
        }

        protected override bool OnStartPrint(PrinterSettings printerSettings, RectangleF imageableArea, double startPosition, double printWidth, bool isCutSheetPaper)
        {
            bool rc = base.OnStartPrint(printerSettings,imageableArea,startPosition,printWidth,isCutSheetPaper);
            if (!rc) return rc;

            // Initialize the grid control for printing.
            gridControlMain.PrintingMode = true;
            gridControlMain.PrintInfo.m_bPrintPaintMsg = false;
            gridControlMain.PrintInfo.m_nPrintTopRow = 1;
            gridControlMain.PrintInfo.m_nPrintLeftCol = 1;

            return true;
        }

        /// <summary>
        /// Print a single page.
        /// </summary>
        /// <remarks>
        /// This function will be called once for each page.
        /// </remarks>
        /// <param name="gra">Graphics object for printing. Cannot be null.</param>
        /// <param name="pageNumber">
        ///	Current page number of relative to this component, zero based. This may not be the page number 
        ///	with respect to the whole graphical deliverable.
        ///	</param>
        ///	<param name="imageableArea">Printable area for the print job. Cannot be null.</param>
        /// <param name="hasMorePages">
        ///	If the component finished printing (reached end of the component), set this to false. 
        ///	Otherwise, set this to true.
        ///	</param>
        /// <param name="stopPosition">
        ///	Stop position on the page. This is the offset in points from the top of page(not from top of 
        ///	imageableArea). A component may finish printing at the middle of a page. This value is to tell 
        ///	the caller the end position on the page. This value is ignored by caller if hasMorePages == true.
        ///	</param>
        /// <returns>true if success, false otherwise.</returns>
        protected override bool OnPrintPage(Graphics gra, int pageNumber,
            RectangleF imageableArea, out bool hasMorePages,
            out double stopPosition)
        {
            Rectangle rectPrint = new Rectangle(0, 0, (int)(this.m_PrintWidth * 100 / 72.0), (int)(this.m_PrintHeight * 100 / 72.0));
            gridControlMain.PrintBounds = rectPrint;

            // Print Grid Control
            // m_Location.X is the offset relative to the left edge of the page, which is caused by layout row/column position and alignment
            // m_Location.Y is the offset relative to its parent grid cell, which is caused by alignment style

            double offsetX = 100 * imageableArea.Left / 72.0 + m_Location.X;
            double offsetY = 100 * (this.m_StartOffsetFTOIA + imageableArea.Top - m_OffsetY) / 72.0 + m_Location.Y; 

            // Clip away the printed part.
            gra.TranslateTransform((float)offsetX, (float)offsetY);

            if (m_Orientation == Orientation.Portrait)
            {
                gra.TranslateTransform((float)(gridControlMain.Location.X * 0.72F), (float)(gridControlMain.Location.Y * 0.72F));
            }
            else
            {
                gra.TranslateTransform((float)(gridControlMain.Location.Y * 0.72F), (float)(gridControlMain.Location.X * 0.72F));
            }


            RectangleF rectClipF;
            Rectangle rectClip;

            // Clip away unwanted part of the grid.
            if (m_Orientation == Orientation.Portrait)
            {
                rectClipF = new RectangleF(0, 0, (float)(100 * this.m_PrintWidth / 72.0), (float)(100 * this.m_PrintHeight / 72.0));
                gra.SetClip(rectClipF);
            }
            else
            {
                //Work around to resolve the problem of rotated section printing of header.
                //The issue was introduced by Synfusion upgraded from 2.0 to 6.0. 
                //And currently synfusion support has no solution for this issue yet.
                //Once we get solution from Synfusion side, this part of code can be removed.
                if (ComponentCode.Equals(GCComponentCode_t.Component_Header))
                {
                    object oHeaderType = null;
                    GetProperty("Header_Type", out oHeaderType);
                    string headerType = oHeaderType.ToString();

                    if (headerType.StartsWith("OP", StringComparison.OrdinalIgnoreCase))
                    {
                        float tempHeight = 1;
                        rectClipF = new RectangleF(0 + m_Location.X, 0, (float)(100 * this.m_PrintHeight / 72.0), tempHeight);
                        gra.SetClip(rectClipF);
                        gra.TranslateTransform((float)(Math.Min(this.m_PrintHeight, imageableArea.Width) * 100 / 72), (float)0.0F);
                        gra.RotateTransform(90);

                        rectClip = new Rectangle((int)rectClipF.X, (int)rectClipF.Y, (int)rectClipF.Height, (int)rectClipF.Width);
                        gridControlMain.OnDrawClientRowCol(0, 0, gridControlMain.RowCount, 1, gra, rectClip);


                        Pen pPen = new Pen(Color.Black, (float)1.5);
                        gra.DrawLine(pPen, 0, 0, 0, rectClipF.Width);

                        rectClipF = new RectangleF((float)(0), 0 + m_Location.X, (float)(100 * this.m_PrintWidth / 72.0), (float)(100 * this.m_PrintHeight / 72.0));
                        gra.SetClip(rectClipF);

                        rectClip = new Rectangle((int)rectClipF.X, (int)rectClipF.Y, (int)rectClipF.Width, (int)rectClipF.Height);
                        gridControlMain.OnDrawClientRowCol(0, 2, gridControlMain.RowCount, gridControlMain.ColCount, gra, rectClip);

                        // Manually fill the boundarry line of Logo image.
                        pPen.Color = Color.Black;
                        gra.DrawLine(pPen, tempHeight,  m_Location.X, rectClipF.Width-6,  m_Location.X);

                        pPen.Dispose();
                    }
                    else
                    {
                        float tempHeight = (float)((gridControlMain.ColWidths[1]));
                        rectClipF = new RectangleF(0, 0, (float)(100 * this.m_PrintHeight / 72.0), tempHeight);
                        gra.SetClip(rectClipF);
                        gra.TranslateTransform((float)(Math.Min(this.m_PrintHeight, imageableArea.Width) * 100 / 72), (float)0.0F);
                        gra.RotateTransform(90);

                        rectClip = new Rectangle((int)rectClipF.X, (int)rectClipF.Y, (int)rectClipF.Height, (int)rectClipF.Width);
                        gridControlMain.OnDrawClientRowCol(0, 0, gridControlMain.RowCount, 1, gra, rectClip);

                        Pen pPen = new Pen(Color.Black, (float)1.5);
                        gra.DrawLine(pPen, 0, 0, 0, rectClipF.Width);

                        rectClipF = new RectangleF((float)(tempHeight + 1), 0 + m_Location.X, (float)(100 * this.m_PrintWidth / 72.0), (float)(100 * this.m_PrintHeight / 72.0));
                        gra.SetClip(rectClipF);

                        rectClip = new Rectangle((int)rectClipF.X, (int)rectClipF.Y, (int)rectClipF.Width, (int)rectClipF.Height);
                        gridControlMain.OnDrawClientRowCol(0, 2, gridControlMain.RowCount, gridControlMain.ColCount, gra, rectClip);

                        // This part of code is a workaround to fix the blank area of Logo Image issue, 
                        // once the higher Synfusion grid dll resolve this problem, we can remove them.

                        //Calculate the logo image's print width, it occupy 8 rows of the grid.
                        float tempWidth = (float)0.0;
                        for (int i = 1; i <= 8; i++)
                            tempWidth += (float)((gridControlMain.RowHeights[i]));

                        // Manually fill the blank area of Schlumberger Logo block.
                        rectClipF = new RectangleF((float)(tempHeight), 0 + m_Location.X, tempHeight + 5, (float)(tempWidth - 1));
                        gra.SetClip(rectClipF);

                        pPen.Color = Color.FromArgb(0, 51, 102);  //This color is Slb Blue
                        pPen.Width = (float)2;
                        gra.DrawLine(pPen, tempHeight + 1, 1 + m_Location.X, tempHeight + 1, (float)(tempWidth - 1));

                        // Manually fill the boundarry line of Logo image.
                        pPen.Color = Color.Black;
                        gra.DrawLine(pPen, tempHeight, 0 + m_Location.X, tempHeight + 2, 0 + m_Location.X);

                        pPen.Dispose();
                    }
                }
                else
                {
                    rectClipF = new RectangleF(0, 0, (float)(100 * this.m_PrintHeight / 72.0), (float)(100 * this.m_PrintWidth / 72.0));
                    gra.SetClip(rectClipF);
                    gra.TranslateTransform((float)(Math.Min(this.m_PrintHeight, imageableArea.Width) * 100 / 72), (float)0.0F);
                    gra.RotateTransform(90);
                }
            }
            if (!ComponentCode.Equals(GCComponentCode_t.Component_Header))
            {
                rectClip = new Rectangle((int)rectClipF.X, (int)rectClipF.Y, (int)rectClipF.Width, (int)rectClipF.Height);
                // Draw the grid.
                gridControlMain.OnDrawClientRowCol(0, 0, gridControlMain.RowCount, gridControlMain.ColCount, gra, rectClip);
            }


            // Calculate len of printable area
            double len = imageableArea.Height - this.m_StartOffsetFTOIA;

            // Update variables.
            if (m_Orientation == Orientation.Portrait)
            {
                if (len > this.m_PrintHeight - this.m_OffsetY)
                {
                    hasMorePages = false;
                    stopPosition = this.m_StartOffsetFTOIA + imageableArea.Top + this.m_PrintHeight - this.m_OffsetY;
                    m_OffsetY = 0;
                }
                else
                {
                    hasMorePages = true;
                    stopPosition = imageableArea.Top + imageableArea.Height;
                    m_OffsetY += len;
                }
            }
            else
            {
                if (len > this.m_PrintWidth - this.m_OffsetY)
                {
                    hasMorePages = false;
                    stopPosition = this.m_StartOffsetFTOIA + imageableArea.Top + this.m_PrintWidth - this.m_OffsetY;
                    m_OffsetY = 0;
                }
                else
                {
                    hasMorePages = true;
                    stopPosition = imageableArea.Top + imageableArea.Height;
                    m_OffsetY += len;
                }
            }

            return true;
        }

        /// <summary>
        /// Get the print length of the component based on the given print width.
        /// </summary>
        /// <remarks>
        /// This method can be called anytime after the component is instantiated.
        /// Print length info is needed to create the table of contents page.
        /// </remarks>
        /// <param name="printerSettings">Printer settings for a print job. Cannot be null.</param>
        /// <param name="printWidth">Print width in points.</param>
        /// <returns>Return the print length of the component.</returns>
        protected override double OnGetPrintLength(PrinterSettings printerSettings,
            double printWidth)
        {
            if (this.m_Orientation == Orientation.Portrait)
            {
                return this.m_PrintHeight * printWidth / this.m_PrintWidth;
            }
            else
            {
                return this.m_PrintWidth * printWidth / this.m_PrintHeight;
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (gridControlMain != null)
                {
                    gridControlMain.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// return how many columns does the text span in the gridCotnrol
        /// </summary>
        /// <param name="sText"></param>
        /// <param name="font"></param>
        /// <param name="iStartColNum">start column number</param>
        /// <param name="iEndColNum">the minimum column number to hold the text in font; set to -1 if gridControl is not initialized</param>
        protected void GetTextColumnSpan(string sText, Font font, int iStartColNum, out int iEndColNum)
        {
            iEndColNum = -1;
            int iTitleWidth = StringPixelUtility.GetStringWidthPixels(sText, font);
            int iAccumulatedWidth = 0;
            for (int i = iStartColNum; i < gridControlMain.ColCount; i++)
            {
                iAccumulatedWidth += gridControlMain.ColWidths[i];
                if (iAccumulatedWidth > iTitleWidth)
                {
                    iEndColNum = i;
                    break;
                }
            }
        }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase:GridGCUIBase.cs;28 */
/*      28*[1419689] 11-NOV-2010 09:57:47 (GMT) HZhang27 */
/*         "[P3] Fix SMR 2514710:  Header report print in PDF file cutoff in left side" */
/*    27A1 [1419641] 11-NOV-2010 09:57:44 (GMT) HZhang27 */
/*         "[9602] Fix SMR 2514710:  Header report print in PDF file cutoff in left side" */
/*      27*[1373587] 08-JUL-2010 09:04:23 (GMT) YChen32 */
/*         "[phase 3] [SMR 2385373 2385377] Special Layout Enhancement" */
/*    21A2 [1348435] 22-APR-2010 09:40:36 (GMT) XChen22 */
/*         "[phase2] TRC Header Print support" */
/*      26*[1347988] 21-APR-2010 10:16:49 (GMT) YChen32 */
/*         "[Phase 3] Add method GetTextColumnSpan for all grid-based viewers" */
/*      25*[1322566] 03-FEB-2010 09:49:52 (GMT) TPeng */
/*         "[Phase 3] Update API Comments on GridGCUIBase" */
/*      24*[1266878] 06-JAN-2010 03:38:24 (GMT) KJiang */
/*         "[P3]Calibration Report Enhancement Calibration Data Source Manager" */
/*      23*[1289477] 03-DEC-2009 07:01:23 (GMT) TPeng */
/*         "[Phase 3] Update PrintBounds while each page being printed" */
/*    21A1 [1247056] 15-JUL-2009 09:59:18 (GMT) YWang38 */
/*         "[Phase 2] Fix smr 2404322, Fix blank area in Logo image when printing." */
/*      22*[1247039] 15-JUL-2009 09:57:40 (GMT) YWang38 */
/*         "[Phase 3] Fix smr 2404322, Fix blank area in Logo image when printing." */
/*      21*[1192598] 18-FEB-2009 10:30:15 (GMT) YWang38 */
/*         "[PRD]Fix smr 2367356, No Company name printed in PDF." */
/*      20*[1127634] 19-SEP-2008 09:45:57 (GMT) YWang38 */
/*         "[PRD] Support printing of Special Layout Complex Component." */
/*      19*[1085268] 05-JUN-2008 10:24:25 (GMT) YWang38 */
/*         "[PRD]Graphical Deliverable Scalability - Printing Part" */
/*      18*[1073977] 22-MAY-2008 09:57:13 (GMT) PYin2 */
/*         "[phase 2] Update Digital Deliverable Clients  of iteration 2 with slbgrid2" */
/*      17*[957798] 23-MAY-2007 10:02:46 (GMT) qwang11 */
/*         "Fix SMR 2261832: CF when printing graphical diliverable to non-slb printer" */
/*      16*[953561] 14-MAY-2007 09:32:50 (GMT) qwang11 */
/*         "Fix SMR 2228151: GDI objects exhausted when printing PDF in deliverable console" */
/*      15*[890547] 14-NOV-2006 06:34:09 (GMT) XWang16 */
/*         "reinject rev 857677-fix smr 2209027:a "print status" window pop-up and can not open delivables window any more" */
/*      14*[884641] 03-NOV-2006 03:43:11 (GMT) DYuan2 */
/*         "Rollback to PAP_9765" */
/*      13*[857677] 02-AUG-2006 07:56:28 (GMT) XWang16 */
/*         "fix smr 2209027:a "print status" window pop-up and can not open "delivables" window any more" */
/*      12*[729258] 19-JUN-2005 21:22:02 (GMT) rshethia */
/*         "Fixing Grid Dispose" */
/*      11*[728677] 16-JUN-2005 23:07:58 (GMT) rshethia */
/*         "Memory related fixes for SynFusionGrid" */
/*      10*[702162] 11-JUN-2005 06:32:07 (GMT) rshethia */
/*         "Added Dispose method to dispose Grid" */
/*       9*[615689] 19-OCT-2004 15:54:33 (GMT) JWWANG */
/*         "Updated GridGCUIBase.dll to use Syncfusion Essential Grid Version 2.1" */
/*       8*[550077] 03-MAR-2004 16:48:12 (GMT) JWWANG */
/*         "Modified OnGetPrintLength to return correct print length in landscape mode." */
/*       7*[523134] 10-DEC-2003 21:12:15 (GMT) JWWANG */
/*         "Added code to GridGCUIBase to guard against potential threading problem." */
/*       6*[512403] 12-NOV-2003 15:28:09 (GMT) JWWANG */
/*         "Minor enhancement" */
/*       5*[511615] 11-NOV-2003 08:31:20 (GMT) AJacob */
/*         "PAP: Graphical Product Helper" */
/*       4*[510432] 06-NOV-2003 08:23:20 (GMT) JWWANG */
/*         "Removed m_PrintHeight and added code to position the grid using Location info." */
/*       3*[508328] 31-OCT-2003 14:31:57 (GMT) JWWANG */
/*         "Added OnUnInitPrint()." */
/*       2*[496974] 09-OCT-2003 19:40:41 (GMT) JWWANG */
/*         "Add a comment in GridGCUIBase (All cells must be serializable)." */
/*       1*[491265] 25-SEP-2003 15:42:55 (GMT) JWWANG */
/*         "Initial version of GridGCUIBase source code (Base Class definition)." */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase:GridGCUIBase.cs;28 */
