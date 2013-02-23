using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler
{
    public class TriangleSummer
    {

        private readonly List<List<long>> triangle = new List<List<long>>();

        public TriangleSummer(string filePath)
        {
            this.SetTriangle(filePath);
        }

        public long FindMaxSumInTriangle()
        {
            for (int i = triangle.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    long multiplier = Math.Max(triangle[i + 1][j], triangle[i + 1][j + 1]);
                    triangle[i][j] += multiplier;
                }
            }

            return triangle[0][0];
        }

        private void SetTriangle(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    List<long> numbers = new List<long>();
                    string[] triangleLine = line.Split(' ');
                    foreach (string numString in triangleLine)
                    {
                        string trimmedNumString = numString.TrimStart('0');
                        long num = Int64.Parse(trimmedNumString);
                        numbers.Add(num);
                    }
                    triangle.Add(numbers);
                }
            }
        }


        
    }
}
