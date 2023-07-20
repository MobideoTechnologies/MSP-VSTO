using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAddIn3.Controls
{
    public class SubProjectsCheckedListBox : CheckedListBox
    {
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.DrawBackground();

                // Draw a line separator
                int lineY = e.Bounds.Bottom - 1;
                using (Pen pen = new Pen(Color.Black))
                {
                    e.Graphics.DrawLine(pen, e.Bounds.Left, lineY, e.Bounds.Right, lineY);
                }

                var addition = this.CheckOnClick ? 20 : 10;
                // Draw the checkbox and text
                e.Graphics.DrawString(
                    this.Items[e.Index].ToString(),
                    e.Font,
                    SystemBrushes.ControlText,
                    new PointF(e.Bounds.X + addition, e.Bounds.Y));

                e.DrawFocusRectangle();
            }
        }
    }
}
