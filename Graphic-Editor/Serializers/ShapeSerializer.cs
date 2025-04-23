using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic_Editor.Shapes;

namespace Graphic_Editor.Serializers {
    abstract class ShapeSerializer {
        public abstract string Serialize(List<MyShape> shapeList);
        public abstract List<MyShape>? Deserialize(string jsonString);
    }
}
