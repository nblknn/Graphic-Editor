using Graphic_Editor.Shapes;
using Newtonsoft.Json;

namespace Graphic_Editor.Serializers {
    internal class JSONShapeSerializer : ShapeSerializer {
        public override string Serialize(List<MyShape> shapeList) {
            var settings = new JsonSerializerSettings() {
                TypeNameHandling = TypeNameHandling.Objects,
            };
            return JsonConvert.SerializeObject(shapeList, settings);
        }

        public override List<MyShape>? Deserialize(string json) {
            var settings = new JsonSerializerSettings() {
                TypeNameHandling = TypeNameHandling.Objects,
            };
            return JsonConvert.DeserializeObject<List<MyShape>>(json, settings);
        }
    }
}
