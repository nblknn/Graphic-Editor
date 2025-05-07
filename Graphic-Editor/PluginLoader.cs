using System.Reflection;
using Graphic_Editor.ShapeFactories;

namespace Graphic_Editor {
    internal class PluginLoader {
        public List<MyShapeFactory> LoadPlugin(string path) {
            Assembly assembly = Assembly.LoadFrom(path);
            List<MyShapeFactory> result = new();
            foreach (Type type in assembly.GetTypes()) {
                if (typeof(MyShapeFactory).IsAssignableFrom(type)) {
                    MyShapeFactory? factory = Activator.CreateInstance(type) as MyShapeFactory;
                    if (factory != null)
                        result.Add(factory);
                }
            }
            if (result.Count == 0)
                throw new Exception("В файле не найдено подходящих классов");
            return result;
        }
    }
}