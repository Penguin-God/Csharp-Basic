using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Data_Basic
{
	class Program
    {
        static void Main(string[] args)
        {
            List<int> Int_List = new List<int>() { 1,3,3,2 };

            List<int> Int_List_2 = Int_List;

            List<int> DeepCopy_List = new List<int>(Int_List);

            Int_List[0] = 200;
            Console.WriteLine(Int_List_2[0]);
            Console.WriteLine(DeepCopy_List[0]);
        }
    }
}
