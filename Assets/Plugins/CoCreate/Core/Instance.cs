using System.Collections;
using System.Collections.Generic;
using CoCreate;


namespace CoCreate
{
    public class Instance
    {
        public List<Component> components = new();

        public T GetComponent<T>() where T : Component
        {
            return components.Find(c => c.GetType() == typeof(T)) as T;
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T component = new T();
            components.Add(component);
            return component;
        }

        public void RemoveComponent<T>() where T : Component
        {
            components.Remove(components.Find(c => c.GetType() == typeof(T)));
        }
    }

}

