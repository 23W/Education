using System;
using System.Collections.Generic;

namespace UniversalSort
{
    class Program
    {
        // returns true if x2 should be before x1
        delegate bool SortMethod<T>(T x1, T x2);

        static void Sort<T>(List<T> list, SortMethod<T> method)
        {
            for(int i = 0; i < list.Count - 1; i++)
            {
                int nesIndex = i;
                for(int j = i + 1; j < list.Count; j++)
                {
                    if(method(list[nesIndex], list[j]))
                    {
                        nesIndex = j;
                    }
                }

                if (i != nesIndex)
                {
                    T temp = list[i];
                    list[i] = list[nesIndex];
                    list[nesIndex] = temp;
                }
            }
        }

        delegate bool MinMethod<T>(T x1, T x2);
            
        static T FindMin<T>(List<T> list, MinMethod<T> method)
        {
            int minIndex = 0;
            for(int i = 0; i < list.Count; i++)
            {
                
                if(method(list[minIndex], list[i]))
                {
                    minIndex = i;
                }
            }

            T min = list[minIndex];
            return min;
        }


        delegate bool FindNesEl<T>(T x);

        static int FindElement<T>(List<T> list, FindNesEl<T> methodFind)
        {
            int resIndex = 0;
            for(int i = 0; i < list.Count; i++)
            {
                if( methodFind(list[i]))
                {
                    resIndex = i;
                    break;
                }
            }
            return resIndex;
        }

        static void TestNesInt()
        {
            List<int> listInt = new List<int>();
            listInt.Add(-100);
            listInt.Add(6);
            listInt.Add(0);
            listInt.Add(-2);
            listInt.Add(-1000000);

            int res = FindElement<int>(listInt, ( i) => 0 == i);

            Console.WriteLine($"The element is {listInt[res]}.");
        }

        static void TestNesString()
        {
            List<string> listString = new List<string>();
            listString.Add("mama");
            listString.Add("test");
            listString.Add("amore");
            listString.Add("lama");
            listString.Add("zebra");

            int res = FindElement<string>(listString, (s) => "mama" == s);

            Console.WriteLine($"The  string is {listString[res]}.");
        }

        static void TestNesStudent()
        {
            List<Student> listStudent = new List<Student>();

            Student s1 = new Student();
            s1.name = "Rita";
            s1.age = 18;

            Student s2 = new Student();
            s2.name = "Rika";
            s2.age = 12;

            Student s3 = new Student();
            s3.name = "Ortance";
            s3.age = 20;

            listStudent.Add(s1);
            listStudent.Add(s2);
            listStudent.Add(s3);

            int res = FindElement<Student>(listStudent, (s) => "Rita" == s.name);

            Console.WriteLine($"The name is {listStudent[res].name}.");
        }

        static void TestMinInt()
        {
            List<int> listInt = new List<int>();
            listInt.Add(-100);
            listInt.Add(6);
            listInt.Add(3);
            listInt.Add(-2);
            listInt.Add(-1000000);

            int res = FindMin<int>(listInt, (i1, i2) => i2 < i1);
                       
            Console.WriteLine($"The minimal element is {res}.");
        }

        static void TestMinString()
        {
            List<string> listString = new List<string>();
            listString.Add("mama");
            listString.Add("mamba");
            listString.Add("amore");
            listString.Add("lama");
            listString.Add("zebra");

            string res = FindMin<string>(listString, (s1, s2) => s2.Length < s1.Length);
                       
            Console.WriteLine($"The minimal string is {res}.");
        }

        static void TestMinBool()
        {
            List<bool> listBool = new List<bool>();
            listBool.Add(true);
            listBool.Add(true);
            listBool.Add(false);
            listBool.Add(true);
            listBool.Add(false);

            //Sort<bool>(listBool, (b1, b2) => !b2 && b1);
            bool res = FindMin<bool>(listBool, (b1, b2) => (b1 == true) && (b2 == false));

            Console.WriteLine($"The minimal type is {res}.");
        }
        static void TestSortInt()
        {
            List<int> listInt = new List<int>();
            listInt.Add(1);
            listInt.Add(6);
            listInt.Add(3);
            listInt.Add(-2);
            listInt.Add(1);

            Sort<int>(listInt, (i1, i2) => i2 < i1);

            foreach(int x in listInt)
            {
                Console.WriteLine(x);
            }
        }

        static void TestSortString()
        {
            List<string> listString = new List<string>();
            listString.Add("mama");
            listString.Add("mamba");
            listString.Add("amore");
            listString.Add("lama");
            listString.Add("zebra");

            Sort<string>(listString, (s1, s2) => s2.CompareTo(s1) < 0);

            foreach (string x in listString)
            {
                Console.WriteLine(x);
            }
        }

        static void TestSortBool()
        {
            List<bool> listBool = new List<bool>();
            listBool.Add(true);
            listBool.Add(true);
            listBool.Add(false);
            listBool.Add(true);
            listBool.Add(false);

            //Sort<bool>(listBool, (b1, b2) => !b2 && b1);
            Sort<bool>(listBool, (b1, b2) => (b2 == true) && (b1 == false));

            foreach (bool x in listBool) 
            {
                Console.WriteLine(x);
            }
        }



        static void Main(string[] args)
        {
            /* TestSortInt();
             TestSortString();
             TestSortBool();*/

            /* TestMinInt();
             TestMinString();
             TestMinBool();*/

            TestNesInt();
            TestNesString();
            TestNesStudent();
        }
    }
}
