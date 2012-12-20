namespace Slb.Horizon.GCFramework
{
    public struct GcPosition
    {
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
    }

    public struct GcSize
    {
        public GcSize(int height, int width)
        {
            m_Width = width;
            m_Height = height;
        }
        public int Width { get { return m_Width; } set { m_Width = value; } }
        public int Height { get { return m_Height; } set { m_Height = value; } }

        private int m_Width ;
        private int m_Height;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcPosition.cs;1 */
/*       1*[1647855] 23-JUL-2012 07:32:38 (GMT) YLi27 */
/*         "Some basic definition for graphical components" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcPosition.cs;1 */
