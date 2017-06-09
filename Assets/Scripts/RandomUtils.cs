using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Staple
{
    public static class RandomUtility
    {

        public interface IWeighted
        {
            float Weight { get; }
        }

        public static float GetQuadRand(float average, float variance)
        {

            // a random number between [0,1]
            float x = Random.value;

            float t = x * 2;
            if (t > 1)
            {
                t = 2 - t;
                float b = average + variance;
                float c = -variance;
                return -c * t * (t - 2) + b;
            }
            else
            {
                float c = variance;
                float b = average - variance;
                return -c * t * (t - 2) + b;
            }
        }

        public static List<T> Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            List<T> result = new List<T>();
            
			for (int i = 0; i < n; i++)
				result.Add(list[i]);
				
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n + 1);
                T value = result[k];
                result[k] = result[n];
                result[n] = value;
            }
            return result;
        }
		
		public static T[] Shuffle<T>(this T[] array)
        {
            int n = array.Length;
            T[] result = new T[n];
			System.Array.Copy(array, result, n);
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n + 1);
                T value = result[k];
                result[k] = result[n];
                result[n] = value;
            }
            return result;
        }

        public static bool Roll(float chance)
        {
            return Random.value < chance;
        }

        public static bool Bool()
        {
            return Roll(0.5f);
        }

        public static float Sign()
        {
            return Bool() ? 1.0f : -1.0f;
        }

        public static T PickRandom<T>(this IList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static T PickWeighted<T>(this IEnumerable<T> list) where T : RandomUtility.IWeighted
        {
			float sum = 0;
			foreach (var item in list)
				sum += item.Weight;

            float randomVal = Random.Range(0.0f, sum);
			
            foreach (var item in list)
            {
				if (randomVal < item.Weight)
					return item;
					
				randomVal -= item.Weight;
            }

            return list.FirstOrDefault();
        }
        public static void PopulateWithUniqueFrom<T>(this IList<T> list, IList<T> fromList, int amount = 0)
        {
            int pickedItems = 0;
            amount = amount == 0 ? fromList.Count : amount;
            while (pickedItems < amount)
            {
                var randomItem = fromList.PickRandom<T>();
                if (!list.Contains(randomItem))
                {
                    list.Add(randomItem);
                    pickedItems++;
                }
            }
        }
    }
}