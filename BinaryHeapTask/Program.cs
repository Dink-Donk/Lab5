using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinaryHeap;
using System.Threading.Tasks;

namespace BinaryHeapTask
{
    /*
    Нужно разложить n объектов, каждый весом от нуля до одного килограмма, в наименьшее количество контейнеров, максимальная емкость каждого из которых не 
    больше одного килограмма. Используйте алгоритм "первый худший": объекты рассматриваются в исходном порядке и каждый объект помещается в частично заполненный 
    контейнер, в котором после помещения данного объекта  останется наибольший свободный объем. На входе последовательность из n весов, на выходе - количество 
    контейнеров 
    */
    class Program
    {
        static void Main(string[] args)
        {
            var mc = new MinComparer<double>();
            BinaryHeap<double> bh = new BinaryHeap<double>(mc);
            List<double> elements = new List<double>();
            double input = 0;
            do
            {
                input = double.Parse(Console.ReadLine());
                if (input != 0)
                    elements.Add(input);
            } while (input != 0);
            foreach (double item in elements)
                bh.Add(item);
            int conatinerCount = 1;
            double currentContainer=0;
            for(int i = 0;i<elements.Count;i++)
            {
                double currItem = bh.RemoveRoot(); 
                if(currentContainer+currItem<=1)
                {
                    currentContainer += currItem;
                }    
                else
                {
                    currentContainer = currItem;
                    conatinerCount++;
                }
            }
            Console.WriteLine(conatinerCount);
            Console.ReadKey();

        }
    }
}
