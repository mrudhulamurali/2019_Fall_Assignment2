/*
    Author: Mrudhula Murali,Vibhu Kumar,Sudeep Rajesh
    Date: 10/06/2019
    Comments: This script demonstrates use of algorithms and implementing in specific time complexity, 
                    data structures and problem solving. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;


namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static int toSearch = 0;

        public static void Main(string[] args)
        {
            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect = Intersect(nums1, nums2);
            Console.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);
            Console.WriteLine("\n");

            //int[] A = { 9, 9, 8, 8 };
            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            //Print the largest unique number in an array.
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            //int[,] image = { { 1, 1, 0, 0 }, { 1, 0, 0, 1 }, { 0, 1, 1, 1 }, { 1, 0, 1, 0 } };
            int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            //Call the FlipAndInvertImage method .
            int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            //Print the resulting flipped and inverted image.
            Console.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(flipAndInvertedImage);
            Console.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            //int[,] intervals = { { 7, 10 }, { 2, 4 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");

            string s = "abca";
            if (ValidPalindrome(s))
            {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }

            Console.ReadLine();
        }

        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int n = nums.Length;
                int result = searchAlgo(nums, 0, n - 1, target);

                return result; // Write your code here 
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }

            return 0;
        }

        public static int searchAlgo(int[] nums, int l, int r, int x)
        {

            if (r >= l)
            {
                int mid = l + (r - l) / 2; //dividing into mid point for right and left half for o(logn)


                if (nums[mid] == x)
                    return mid;


                else if (nums[mid] > x)
                {
                    toSearch = mid - 1;
                    return searchAlgo(nums, l, mid - 1, x); // searching left half if number, notice recursion
                }


                // Else the element can only be present 
                // in right half 
                else
                {
                    toSearch = mid + 1;
                    return searchAlgo(nums, mid + 1, r, x);
                }


            }
            return toSearch;
        }


        // computes the intersection of arrays
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            int[] array1 = { };
            try
            {
                int len1 = nums1.Length;
                int len2 = nums2.Length;
                //array to store the common values
                ArrayList mylist = new ArrayList();
                //Sorting array
                Array.Sort(nums1);
                Array.Sort(nums2);
                int i = 0;
                int j = 0;
                //while loop to take out the common values in arrays
                while (i < len1 && j < len2)
                {
                    if (nums1[i] == nums2[j])
                    {
                        mylist.Add(nums1[i]);


                        i++; j++;

                    }

                    else if (nums1[i] < nums2[j])
                    {
                        i++;
                    }

                    else

                        j++;

                }
                //loop for printing out the common array
                for (int k = 0; k < mylist.Count; k++)
                {
                    Console.Write(mylist[k] + " ");
                }
                array1 = (int[])mylist.ToArray(typeof(int));


            }

            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }

            return array1;

        }


        /*Given an array of integers A, this method  return the largest integer that only occurs once.
         If no integer occurs once, return -1.
         Time complexity of the method should not exceed O(n). */
        public static int LargestUniqueNumber(int[] A)
        {
            try
            {
                Dictionary<int, int> distinctDictionary = new Dictionary<int, int>();
                int largestNumber;

                /*Loop through the input array.Here we are looping through n elements of array and the time complexity
                 will be O(n).*/
                for (int i = 0; i < A.Length; i++)
                {
                    //When adding the values from array to the dictionary and remove all the values which is repeating more than once.
                    if (distinctDictionary.ContainsValue(A[i]))
                    {
                        int keyValue = distinctDictionary.FirstOrDefault(x => x.Value == A[i]).Key;
                        distinctDictionary.Remove(keyValue);
                    }
                    //Add array values to dictionary
                    else
                    {
                        distinctDictionary.Add(i, A[i]);
                    }
                }
                //If the there are no unique values in the array the dictionary will be empty and will output -1. 
                if (distinctDictionary.Count == 0)
                {
                    largestNumber = -1;
                }
                //we can get the largest value from the input by taking the max in dictionary.
                else
                {
                    largestNumber = distinctDictionary.Values.Max();
                }
                //Return the largest number.
                return largestNumber;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()" + ex.Message);
                return -1;
            }

        }

        public static int LargestNumber(Dictionary<int, int> sarray)
        {
            //int value;
            int value = sarray.Values.Max();
            return value;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                IDictionary<char, int> d = new Dictionary<char, int>(); //create dict
                char[] charArr = keyboard.ToCharArray(); //convert to char array
                char[] wordArr = word.ToCharArray(); //convert to char array
                int i = 0;
                int temp = 0; int next = 0; int result = 0;
                foreach (char ch in charArr)
                {

                    d.Add(ch, i); //add keyboard to dictionary
                    i++;
                }

                //var d = charArr.ToDictionary(x => Array.IndexOf(charArr, x));

                foreach (char ch in wordArr)
                {
                    next = d[ch];

                    result = result + (Math.Abs(next - temp)); //calculate timings

                    temp = next;
                }
                return result;
                //Console.WriteLine("this is the keyboard time" + result);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        /*This method when given a binary matrix A, will flip the image horizontally, then invert it, 
        and return the resulting image.*/
        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {
                //initialize a temporaray array
                int[,] tempArray = new int[1, 2];
                //get the length of the array.
                int lastElement = A.GetUpperBound(0);

                //Loop through the inner and outer array to loop through all the elements in the array.
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1) && lastElement >= 0 && j <= lastElement; j++, lastElement--)
                    {
                        /*Flip the elements in the array using temporary array and then invert the values of array from 1 to 0 
                        and 0 to 1.*/
                        tempArray[0, 0] = (A[i, j] == 0) ? 1 : 0;
                        A[i, j] = (A[i, lastElement] == 0) ? 1 : 0;
                        A[i, lastElement] = tempArray[0, 0];
                    }
                    lastElement = A.GetUpperBound(0);
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }
            //return the resulting output array after flip and invert.
            return A;
        }

        /* Computes the minimum number of meeting rooms required to hold 
         all the scheduled meetings in the specified start and end intervals*/
        public static int MinMeetingRooms(int[,] intervals)
        {
            //intialize the minimum number of meeting rooms to 1.
            int meetingRoomCnt = 1;
            try
            {
                //intialise a temporary variable.
                int[,] temp = new int[2, 2];

                //intialise a sarray to store the sorted start intervals from the intervals array.
                int[] sarray = new int[intervals.GetLength(0)];

                //intialise a earray to store the end intervals corressponding to the
                //sorted start intervals from the intervals array.
                int[] earray = new int[intervals.GetLength(0)];
                int j = 0;
                int k = 0;

                //this for loop loops through all the elements in the intervals array 
                //by sorting the start interval.
                for (int i = 0; i < intervals.GetUpperBound(0); i++)
                {
                    //Sorting meeting intervals
                    if (intervals[i, j] > intervals[i + 1, j])
                    {
                        temp[0, 0] = intervals[i, j];
                        intervals[i, j] = intervals[i + 1, j];
                        intervals[i + 1, j] = temp[0, 0];

                        temp[0, 1] = intervals[i, j + 1];
                        intervals[i, j + 1] = intervals[i + 1, j + 1];
                        intervals[i + 1, j + 1] = temp[0, 1];
                    }
                }

                //this for loop create separate arrays for both start and end intervals.
                for (int i = 0; i <= intervals.GetUpperBound(0); i++, k++)
                {
                    sarray[k] = intervals[i, 0];
                    earray[k] = intervals[i, 1];
                }

                //this for loop checks whether the end interval of current interval is greater than the
                //start interval of next interval ,if it is greater increment the meetingroom counter.
                for (int i = 1; i < sarray.Length; i++)
                {
                    if (sarray[i] < earray[i - 1])
                    {
                        meetingRoomCnt++;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }
            //return the meetingroom count.
            return meetingRoomCnt;
        }
        /*Given an array of integers A sorted in non-decreasing order, return an array of the squares of each number,
            also in sorted non-decreasing order.The time complexity of the method should not exceed O(n)*/
        public static int[] SortedSquares(int[] A)
        {
            //initialize the output array.
            int[] squareArray = new int[A.Length];
            try
            {

                int squareArrCnt = 0;
                int negativeCount = 0;

                /*Get the count of the negative numbers in the array.Here we are looping through n elements of 
                array and the time complexity will be O(n)*/
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] >= 0)
                    {
                        //break when the number in the array is positive.
                        break;
                    }
                    //increment the count when the number in the array is negative.
                    negativeCount++;
                }
                //get the index of the smallest negative number in the array since that will be largest when squared.
                int negativeLoop = negativeCount - 1;
                //get the starting index of positive numbers.
                int positiveLoop = negativeCount;

                //this loop continues till all the values in the array is squared.
                while (positiveLoop < A.Length || negativeLoop >= 0)
                {
                    //assign only the positive square values to the squared array since there are no negative numbers.
                    if (negativeLoop < 0)
                    {
                        squareArray[squareArrCnt] = A[positiveLoop] * A[positiveLoop];
                        positiveLoop++;
                        squareArrCnt++;
                    }
                    //assign only the negative square values to the squared array since there are no positive numbers.
                    else if (positiveLoop >= A.Length)
                    {
                        squareArray[squareArrCnt] = A[negativeLoop] * A[negativeLoop];
                        negativeLoop--;
                        squareArrCnt++;
                    }
                    //assign the negative number square since negative number square is less than positive number square.
                    else if (A[negativeLoop] * A[negativeLoop] < A[positiveLoop] * A[positiveLoop])
                    {
                        squareArray[squareArrCnt] = A[negativeLoop] * A[negativeLoop];
                        negativeLoop--;
                        squareArrCnt++;
                    }
                    //assign the positive number square since positive number square is less than negative number square.
                    else
                    {
                        squareArray[squareArrCnt] = A[positiveLoop] * A[positiveLoop];
                        positiveLoop++;
                        squareArrCnt++;
                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            return squareArray;
        }

        public static bool ValidPalindrome(string s)
        {
            try
            {
                string copy = s;

                if (!s.SequenceEqual(s.Reverse())) //initial palindrome check
                {

                    foreach (char ch in copy)
                    {
                        copy = s.Replace(ch.ToString(), string.Empty); //remove each and every character and check
                        if (copy.SequenceEqual(copy.Reverse()))
                        {
                            return true;

                        }// Write your code here
                    }
                }
                else
                    return true;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }
    }
}

