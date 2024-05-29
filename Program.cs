using static System.Console;
using System.Collections.Generic;

namespace CouseSchedule2
{
    class Program
    {
        private static Dictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();
        private static HashSet<int> visit = new HashSet<int>();
        private static HashSet<int> cycle = new HashSet<int>();
        private static List<int> output = new List<int>();
    

        public static void Main(string[] args)
        {
            //crear la lista de prerequsitos 
            int[][] prerequisit = new int[][]
            {
               new int[] {0, 1},
               new int[] {0, 2},
               new int[] {1, 3},
               new int[] {3, 2},
               new int[] {4, 0},
               new int[] {5, 0},
            };

            // resultado de la busqueda dfs 
            int[] result = FindOrder(6, prerequisit);

            foreach (var item in result)
            {
                WriteLine($"FindOrder: {item}");
            }

        }

        public static int[] FindOrder(int numCourses , int[][] prerequisites)
        {

            // Crear el diccionario preMap
            preMap = new Dictionary<int, List<int>>();

            for (int i = 0; i < numCourses; i++)
            {
                preMap[i] = new List<int>();
            }


            // Llenar el diccionario con los prerequisitos
            foreach (var pre in prerequisites)
            {
                int crs = pre[0];
                int prerequisite = pre[1];
                preMap[crs].Add(prerequisite);
            }
             
            for (int i = 0; i < numCourses; i++)
            {
                if (dfs(i) == false)
                {
                    return new int[0];
                }
            }

            return output.ToArray();
        }

        private static bool dfs(int crs)
        {
            if (cycle.Contains(crs))
            {
                return false;
            }

            if (visit.Contains(crs))
            {
                return true;
            }
  
            cycle.Add(crs);

            foreach (int pre in preMap[crs])
            {
                if (dfs(pre) == false)
                {
                    return false;
                }
            }
            cycle.Remove(crs);
            visit.Add(crs);
            output.Add(crs);
            return true;
        }
    }
}