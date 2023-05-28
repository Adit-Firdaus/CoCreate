using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace CoCreate
{
    public class Component
    {
        public static List<Type> GetAllComponents()
        {
            return typeof(Component).Assembly.GetTypes().ToList().FindAll(t => t.IsSubclassOf(typeof(Component)));
        }
    }
}