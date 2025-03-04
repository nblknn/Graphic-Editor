using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Graphic_Editor {
    internal class MyShape {
        public System.Windows.Media.Color color { get; set; }

        public virtual void Draw(Canvas canvas) { }
    }
}
