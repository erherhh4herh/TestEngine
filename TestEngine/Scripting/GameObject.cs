using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame;
using Microsoft.Xna.Framework;

namespace TestEngine
{
    public class GameObject
    {
        public string Name;
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;
        
        internal List<Type> _components = new List<Type>();

        public GameObject()
        {
            Name = "GameObject";
            Scale = new Vector3(1, 1, 1);
            Engine.CurrentScene._gameObjects.Add(this);
        }

        public GameObject(string name)
        {
            Name = name;
            Scale = new Vector3(1, 1, 1);
            Engine.CurrentScene._gameObjects.Add(this);
        }

        public GameObject(string name, Vector3 position)
        {
            Name = name;
            Position = position;
            Scale = new Vector3(1, 1, 1);
            Engine.CurrentScene._gameObjects.Add(this);
        }

        public GameObject(string name, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            Name = name;
            Position = position;
            Scale = scale;
            Rotation = rotation;
            Engine.CurrentScene._gameObjects.Add(this);
        }

        public T AddComponent<T>() where T : Component
        {
            return this.internalAddComponent(typeof(T)) as T;
        }

        public void RemoveComponent(Type component)
        {
            _components.Remove(component);
        }

        internal Type internalAddComponent(Type component)
        {
            _components.Add(component);
            return component;
        }
    }
}
