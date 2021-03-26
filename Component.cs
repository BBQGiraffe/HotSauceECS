using System;
namespace HotSauceECS
{
    public abstract class Component
    {
        public Entity entity;
        public void Invoke(string function)
        {
            GetType().GetMethod(function)?.Invoke(this, null);
        }
    }
}
