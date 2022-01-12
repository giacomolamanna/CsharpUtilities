using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcode
{
    public class ListUtilities
    {
        
        /// <summary>
        /// Method that performs the replacement of an element in a list of strings 
        /// </summary>
        /// <param name="ListOfString">List of string elements within which a replacement is to be made </param>
        /// <param name="index">index in which to replace </param>
        /// <param name="new_string">new element string</param>
        public void Replace_ListString(List<string> ListOfString, int index, string new_string)
        {
            List<string> NewList = new List<string>();

            for (int i = 0; i < ListOfString.Count; i++)
            {
                if (i == index)
                {
                    NewList.Add(new_string);
                }
                else
                {
                    NewList.Add(ListOfString[i]);
                }
            }
            ListOfString.Clear();

            ListOfString.AddRange(NewList);
        }


        /// <summary>
        /// The method checks if the objects of list2 are all contained in list1 
        /// </summary>
        /// <param name="List1">Main list in which to search for the points of List 2 </param>
        /// <param name="List2">List of which points are searched for in List1 </param>
        /// <returns>The method returns true if all points in List2 are contained in List1 </returns>
        public bool Contains_AllItems(List<object> List1, List<object> List2)
        {
            bool result = false;

            for (int i = 0; i < List2.Count; i++)
            {
                for (int j = 0; j < List1.Count; j++)
                {
                    if (List2[i] == List1[j])
                    {
                        result = true;
                        break;
                    }
                    if (j == List1.Count - 1)
                    {
                        return false;
                    }
                }
            }

            return result;
        }

    }

}