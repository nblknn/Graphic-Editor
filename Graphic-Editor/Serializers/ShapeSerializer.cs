using Graphic_Editor.Shapes;

namespace Graphic_Editor.Serializers {
    abstract class ShapeSerializer {
        public abstract string Serialize(List<MyShape> shapeList);
        public abstract List<MyShape>? Deserialize(string jsonString);
    }
}
