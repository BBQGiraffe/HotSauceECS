using System;
using System.Collections.Generic;
namespace HotSauceECS
{
    public class Entity
    {
        static List<Entity> entities = new List<Entity>();
        static List<Entity> toBeAdded = new List<Entity>();

        static Dictionary<Type, Dictionary<int, Component>> components = new Dictionary<Type, Dictionary<int, Component>>();
        int id;

        public Dictionary<int, Component> GetComponentsOfType<T>() where T : Component
        {
            return components[typeof(T)];
        }
        
        public T GetComponent<T>() where T : Component
        {
            return GetComponentsOfType<T>()[id] as T;
        }

        public T AddComponent<T>() where T : Component
        {
            var component = Activator.CreateInstance<T>();
            if (components.ContainsKey(typeof(T)))
            {
                GetComponentsOfType<T>().Add(id, component);
            }
            else
            {
                components.Add(typeof(T), new Dictionary<int, Component>());
                GetComponentsOfType<T>().Add(id, component);
            }
            component.entity = this;
            component.Invoke("Start");
            return component;
        }

        public static void InvokeAll(string function)
        {
            foreach (var e in entities)
            {
                e.Invoke(function);
            }
            foreach ( var b in components.Values)
            {
                foreach(var component in b.Values)
                {
                    component.Invoke(function);
                }
            }
        }

        public void Invoke(string function)
        {
            GetType().GetMethod(function)?.Invoke(this, null);
        }

        public static T Create<T>() where T : Entity
        {
            var entity = Activator.CreateInstance<T>();
            entity.id = entities.Count;
            entities.Add(entity);
            entity.Invoke("Start");
            return entity;
        }

        public static Entity Create()
        {
            return Create<Entity>();
        }

      
    }
}
