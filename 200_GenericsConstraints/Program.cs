using System;
using System.Collections.Generic;

namespace _200_GenericsConstraints
{
    class Program
    {
        public class Monobehaviour
        {
            public void SetActive(bool isActive)
            {
                //TODO: Implement function
            }
        }

        //Object Pool -> "Balde" de objetos que podem ser re-usados
        //E isso melhora a performance em situacoes onde voce tem que "criar" e "destruir" muitos objetos
        public class Pool<T> where T : Monobehaviour, new()
        {
            List<T> objects = new List<T>();

            public T GetOrCreate()
            {
                if (objects.Count > 0)
                {
                    T obj = objects[objects.Count - 1];
                    objects.RemoveAt(objects.Count - 1);
                    obj.SetActive(true);
                    return obj;
                }
                else
                {
                    return new T();
                }
            }

            public void ReturnToPool(T obj)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                    objects.Add(obj);
                }
            }
        }

        public class Weapon : Monobehaviour
        {
        }

        static void Main(string[] args)
        {
            Pool<Weapon> weaponPool = new Pool<Weapon>();
            Console.WriteLine("Hello World!");
        }
    }
}
