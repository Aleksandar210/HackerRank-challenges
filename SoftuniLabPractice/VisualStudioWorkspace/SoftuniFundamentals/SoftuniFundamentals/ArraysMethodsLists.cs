﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SoftuniFundamentals
{
    class ArraysMethodsLists
    {
        public void Rotation()
        {
            string[] elements = Regex.Split(Console.ReadLine(), "\\s+");
            int numberRotations = int.Parse(Console.ReadLine());
            while(numberRotations-- > 0)
            {
                string firstElement = elements[0];
                for(int i = 1; i < elements.Length; i++)
                {
                    elements[i - 1] = elements[i];
                }
                elements[elements.Length - 1] = firstElement;
            }

            foreach(string item in elements)
            {
                Console.Write(item+" ");
            }

        }

        public void EqualSums()
        {
            int[] numbers = Regex.Split(Console.ReadLine(), "\\s+").Select(e => int.Parse(e)).ToArray();
            int leftSum = 0;
            int rightSum = 0;
            for(int i = 0; i < numbers.Length-1; i++)
            {
                if (i == 0)
                {
                    for (int l = i + 1; l < numbers.Length; l++)
                    {
                        rightSum += numbers[l];
                    }

                }
                else
                {
                    for(int l = i + 1; l < numbers.Length; l++)
                    {
                        rightSum += numbers[l];
                    }

                    for(int k = 0; k < i; k++)
                    {
                        leftSum += numbers[k];
                    }
                }


                if (leftSum == rightSum)
                {
                    Console.Write(numbers[i]+" ");
                }
            }

           

        }

        public void KaminoFactory()
        {
            List<string> sequences = new List<string>();
            List<string> newSortedList;
            string enterSequence;
            do
            {
                enterSequence = Console.ReadLine();
                if(enterSequence.Equals("Clone Them!", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    sequences.Add(string.Join("",Regex.Split(enterSequence, "\\s+")));
                    
                }


            }
            while (!enterSequence.Equals("Clone Them!", StringComparison.OrdinalIgnoreCase));

            newSortedList = sequences.OrderByDescending(c => c).ToList();
            int bestIndex = GetDnaPosition(sequences, newSortedList.First());
            
            Console.WriteLine("Best DNA is {0} -> {1}",bestIndex,newSortedList[bestIndex-1]);
        }

        private int GetDnaPosition(List<string> sequences, string bestSequence)
        {
            int bestIndex = 0;
            for(int i = 0; i < sequences.Count; i++)
            {
                if (sequences[i].Equals(bestSequence))
                {
                    bestIndex = i + 1;
                }
            }

            return bestIndex;
        }

        public void LadyBug()
        {
            int size = int.Parse(Console.ReadLine());
            string[] enterLadyBugIndexex = Regex.Split(Console.ReadLine(),"\\s+");
            
            int[] field = new int[size];
            FillField(enterLadyBugIndexex.Select(e => int.Parse(e)).ToArray(), field);
            string enterCommand;
            do
            {
                enterCommand = Console.ReadLine();
                if(enterCommand.Equals("end", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    int indexOfBug = int.Parse(Regex.Split(enterCommand,"\\s+")[0]);
                    string command = Regex.Split(enterCommand, "\\s+")[1];
                    int length = int.Parse(Regex.Split(enterCommand, "\\s+")[2]);

                    indexOfBug += length;
                    if((indexOfBug += length) > field.Length || (indexOfBug += length) < field.Length)
                    {

                    }else 
                    {
                        if (field[indexOfBug] == 1)
                        {
                            indexOfBug += length;
                            if((indexOfBug += length) > field.Length || (indexOfBug += length) < field.Length)
                            {

                            }
                            else
                            {
                                field[indexOfBug] = 1;
                            }
                        }
                        else
                        {
                            field[indexOfBug] = 1;
                        }
                    }

                   
                }

            }
            while (!enterCommand.Equals("end" , StringComparison.OrdinalIgnoreCase));


        }

        private void FillField(int[] indexes,int[] field)
        {
            
            for(int i = 0; i < field.Length; i++)
            {
                if (indexes.Contains(i))
                {
                    field[i] = 1;
                }
                else
                {
                    field[i] = 0;
                }
            }
        }


        public void Messaging()
        {
            string enterNumbers = Console.ReadLine();
            string[] indexes = enterNumbers.Split().ToArray(); 
            string message = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < indexes.Length; i++)
            {
                sb.Append(message.ElementAt(GetSumDigits(indexes[i])));
            }

            Console.WriteLine(sb.ToString());

        }

        private int GetSumDigits(string digits)
        {
            int sum = digits.ToCharArray().Select(a=>int.Parse(a.ToString())).Aggregate((a,b)=>a+b);
            return sum;
        }

        public void CarRace()
        {
            int[] numbers = Console.ReadLine().Split().Select(e => int.Parse(e)).ToArray();
            int leftTime = 0;
            int rightTime = 0;
            for(int i = 0, k=numbers[numbers.Length-1]; i < numbers.Length / 2; i++,k--)
            {
                if (numbers[i] == 0 )
                {
                    leftTime -= leftTime / 20;
                }
                if (numbers[k] == 0)
                {
                    rightTime -= rightTime / 20;
                }

                leftTime += numbers[i];
                rightTime += numbers[k];

            }

            if (leftTime > rightTime)
            {
                Console.WriteLine($"Winner is Right Car with {rightTime} time");
            }
            else
            {
                Console.WriteLine($"Winner is Left Car with {leftTime} time");
            }
        }

        public void SecretMessage()
        {
            List<string> currentMessage = new List<string>(Console.ReadLine().ToCharArray()
                .Select(e => e.ToString()).ToArray().ToList());
            // List<int> numbers = new List<int>(currentMessage.Where(e=> Regex.IsMatch(e, "[0-9]"))
            //   .Select(e=> {
            //      currentMessage.Remove(e);
            //      return int.Parse(e);
            //   }).ToList());

            int[] numbers = (from t in currentMessage
                              where char.IsDigit(char.Parse(t))
                              select (int.Parse(t))).ToArray();


            List<string> noWords = (from t in currentMessage
                                    where !char.IsDigit(char.Parse(t))
                                    select t).ToList();

            List<int> skip = new List<int>();
            List<int> take = new List<int>();
           for(int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    take.Add(numbers[i]);
                }
                else
                {
                    skip.Add(numbers[i]);
                }
            }
            
        }

    }
}