using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace getLargestCommonSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Please enter an integer between 1 and 20 to define the size of the array a: ");
            string a_array_size_input = Console.ReadLine();
            int a_array_size = int.Parse(a_array_size_input);

            int[] a_array = new int[a_array_size];

            Console.Write("Please enter the values in a array comma separated: ");

            string[] a_array_values_input = Console.ReadLine().Split(",");

            //Console.WriteLine("");

            for (int i = 0; i < a_array_size; i++)
            {
                a_array[i] = int.Parse(a_array_values_input[i]);
            }

            /*
            foreach (int a in a_array)
            {
                Console.WriteLine(a);
            }
            */

            Console.Write("Please enter an integer between 1 and 20 to define the size of the array b: ");
            string b_array_size_input = Console.ReadLine();
            int b_array_size = int.Parse(b_array_size_input);

            int[] b_array = new int[b_array_size];

            Console.Write("Please enter the values in b array comma separated: ");

            string[] b_array_values_input = Console.ReadLine().Split(",");

            for (int i = 0; i < b_array_size; i++)
            {
                b_array[i] = int.Parse(b_array_values_input[i]);
            }

            /*
            foreach (int b in b_array)
            {
                Console.WriteLine(b);
            }
            */

            int[] LargestCommonSubArray = getLargestCommonSubArray(a_array, b_array);

            Console.WriteLine("FINAL Result");
            Console.Write("[");
            for (int i = 0; i < LargestCommonSubArray.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write(LargestCommonSubArray[i]);
                }
                else
                {
                    Console.Write("," + LargestCommonSubArray[i]);
                }
                
            }
            
            Console.Write("]");
        }

        public static int[] getLargestCommonSubArray(int[] a_arr, int[] b_arr)
        {
            //int matching_count = 0;

            Array.Sort(a_arr);
            Array.Sort(b_arr);

            int a_arr_length = a_arr.Length;
            int b_arr_length = b_arr.Length;

            var list_common_sub_array = new List<int>();

            //for each element in array A
            for (int i = 1; i <= a_arr.Length - 1; i++)
            {
                //checking for contiguous subarray 
                bool search = false;
                //if (a_arr[i] == a_arr[i - 1] + 1 || a_arr[i] == a_arr[i + 1] - 1)
                if (a_arr[i] == a_arr[i-1] + 1)
                {
                    if (i == 1)
                    {
                        //search for a_arr[i-1];
                        Console.WriteLine("calling search with index" + (i-1));
                        search = SearchInArray(a_arr[i - 1], b_arr);
                        if (search == true)
                        {
                            list_common_sub_array.Add(a_arr[i - 1]);
                        }
                        
                    }

                    //search for a_arr[i];
                    Console.WriteLine("calling search with index" + (i));
                    search = SearchInArray(a_arr[i], b_arr);
                    if (search == true)
                    {
                        list_common_sub_array.Add(a_arr[i]);
                    }
                    

                }

                else if (i != a_arr.Length - 1)
                {
                    if (a_arr[i] == a_arr[i + 1] - 1)
                    {
                        //search for a_arr[i];
                        Console.WriteLine("calling search with index" + (i));
                        search = SearchInArray(a_arr[i], b_arr);
                        if (search == true)
                        {
                            list_common_sub_array.Add(a_arr[i]);
                        }
                    }

                }

             }

            foreach (int match in list_common_sub_array)
            {
                Console.WriteLine(match);
            }

            int[] CommonSubArray = findCommonSubArray(list_common_sub_array);

            return CommonSubArray;
            
        }

        public static bool SearchInArray(int match_val, int[] b_array)
        {
            int low = 0;
            int high = (b_array.Length) - 1;
            int mid = (low + high) / 2;
            int middle_value = 0;
            int track_middle_high = 0;

            while (low <= high)
            {
                mid = (low + high) / 2;
                middle_value = b_array[mid];

                if (middle_value == match_val)
                {
                    Console.WriteLine("Search Element Found");
                    return true;
                    
                }

                else if (middle_value > match_val && track_middle_high != middle_value)
                {
                    high = mid - 1;
                    //Console.WriteLine("In Else If Found this integer: " + middle_value + " But that's not it!");
                    track_middle_high = middle_value;
                }

                else
                {
                    low = mid + 1;

                    //Console.WriteLine("In Else Found this integer: " + middle_value + " But that's not it!");
                }

            }

            if (low > high)
            {
                Console.WriteLine("");
                Console.WriteLine("Could not locate your integer value in the search. Please try again... ");
                return false;
            }

            return false;

        }

        public static int[] findCommonSubArray(List<int> common_sub_array)
        {
            //int[] final_common_sub_array = new int[10];

            //List<int> common_sub_array = new List<int>() { 1, 3, 4, 6, 7 };
            List<int> temp1 = new List<int>();
            List<int> temp2 = new List<int>();
            bool temp1_available = true;
            bool temp2_available = true;

            for (int i = 0; i < common_sub_array.Count - 1; i++)
            {
                //comparing sub-arrays

                if (temp1_available == false && temp2_available == false)
                {
                    if (temp1.Count == temp2.Count)
                    {

                        if (temp1[0] > temp2[0])
                        {
                            temp2.Clear();
                        }


                        else
                        {
                            temp1.Clear();
                        }
                    }

                    else if (temp1.Count > temp2.Count)
                    {
                        temp2.Clear();
                    }
                    else
                    {
                        temp1.Clear();
                    }


                    Console.WriteLine("temp1 after comparision 1");

                    for (int j = 0; j < temp1.Count; j++)
                    {
                        Console.WriteLine(temp1[j]);

                    }


                    Console.WriteLine("temp2 after comparision 1");
                    for (int j = 0; j < temp2.Count; j++)
                    {
                        Console.WriteLine(temp2[j]);

                    }


                }


                if (common_sub_array[i] == (common_sub_array[i + 1] - 1))
                {
                    if (temp1_available == true || temp1.Count == 0)
                    {
                        if (temp1.Count == 0)
                        {
                            temp1.Add(common_sub_array[i]);
                            temp1.Add(common_sub_array[i + 1]);

                        }
                        else
                        {
                            temp1.Add(common_sub_array[i + 1]);

                        }
                    }

                    else
                    {
                        if (temp1.Count != 0)
                        {
                            temp1_available = false;
                        }
                        else { }

                        if (temp2.Count == 0)
                        {
                            temp2.Add(common_sub_array[i]);
                            temp2.Add(common_sub_array[i + 1]);

                        }
                        else if (temp2_available == true)
                        {

                            temp2.Add(common_sub_array[i + 1]);
                        }
                    }
                    if (i == common_sub_array.Count - 2)
                    {
                        temp1_available = false;
                        temp2_available = false;
                    }
                }
                else
                {

                    if (temp1.Count != 0)
                    {
                        temp1_available = false;
                    }
                    else { }

                    if ((common_sub_array[i] == (common_sub_array[i + 1] - 1)) && temp2.Count == 0)
                    {
                        temp2.Add(common_sub_array[i]);
                        temp2.Add(common_sub_array[i + 1]);
                    }
                    else if (common_sub_array[i] == (common_sub_array[i + 1] - 1) && temp2_available == true)
                    {
                        temp2.Add(common_sub_array[i + 1]);
                    }
                    else if (temp2.Count != 0)
                    {
                        temp2_available = false;
                    }

                    if (i == common_sub_array.Count - 2)
                    {
                        temp1_available = false;
                        temp2_available = false;
                    }
                }

                if (i == common_sub_array.Count - 2)
                {
                    temp1_available = false;
                    temp2_available = false;
                }
            }

            Console.WriteLine("temp1");

            for (int i = 0; i < temp1.Count; i++)
            {
                Console.WriteLine(temp1[i]);

            }
            Console.WriteLine(temp1_available);

            Console.WriteLine("temp2");
            for (int i = 0; i < temp2.Count; i++)
            {
                Console.WriteLine(temp2[i]);

            }
            Console.WriteLine(temp1_available);

            if (temp1_available == false && temp2_available == false)
            {
                if (temp1.Count == temp2.Count)
                {

                    if (temp1[0] > temp2[0])
                    {
                        temp2.Clear();
                    }


                    else
                    {
                        temp1.Clear();
                    }
                }

                else if (temp1.Count > temp2.Count)
                {
                    temp2.Clear();
                }
                else
                {
                    temp1.Clear();
                }

                Console.WriteLine("temp1 after comparision 2");

                for (int j = 0; j < temp1.Count; j++)
                {
                    Console.WriteLine(temp1[j]);

                }


                Console.WriteLine("temp2 after comparision 2");
                for (int j = 0; j < temp2.Count; j++)
                {
                    Console.WriteLine(temp2[j]);

                }


            }

            //int final_common_sub_array_size = 0;

            if(temp1.Count > temp2.Count)
            {
                //final_common_sub_array_size = temp1.Count;
                int[] final_common_sub_array = temp1.ToArray();
                return final_common_sub_array;
            }
            else
            {
                int[] final_common_sub_array = temp2.ToArray();
                return final_common_sub_array;

            }

             
        }

    }
}
