using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    public class CombineTwoCustomList
    {
        /* Made by Jesper Ahasverusen Kielsgaard
         * Date: 17-03-2018
         * 
         * To combine to list where the both have a ID to match.
         */

        public void run()
        {
            // Here i making the to list out of the two custom classes
            List<ListA> _ListA = new List<ListA>();
            List<ListB> _ListB = new List<ListB>();
            List<CompleteList> cl = new List<CompleteList>();

            // Fill list one with data from 1 to 9
            for (int i = 0; i < 10; i++)
            {
                _ListA.Add(new ListA {
                    ID = i.ToString(),
                    DataA = (i * 10).ToString()
                });
            }
            // Fill list two with data from 9 to 1
            for (int i = 20; i >= 0; i--)
            {
                _ListB.Add(new ListB
                {
                    ID = i.ToString(),
                    DataB = (i * 100).ToString()
                });
            }

            // First going through list one and making a check up check up if there is any ID match it will add all data from both list
            // is there is no match it will only put data in from the list A into the cl list
            foreach (ListA item_A in _ListA)
            { 
                if (_ListB.Any(B => B.ID==item_A.ID))
                {
                    string DataB = _ListB.Find(B => B.ID == item_A.ID).DataB;

                    cl.Add(new CompleteList
                    {
                        ID = item_A.ID,
                        DataA = item_A.DataA,
                        DataB = DataB
                    });
                }
                else
                {
                    cl.Add(new CompleteList
                    {
                        ID = item_A.ID,
                        DataA = item_A.DataA
                    });
                }
            }

            // Now it will run listB through and if are any data in listB that is not in the cl list yet 
            // it will add it
            foreach (ListB item_B in _ListB)
            {
                if (!_ListA.Any(A => A.ID == item_B.ID))
                {
                    cl.Add(new CompleteList
                    {
                        ID = item_B.ID,
                        DataB = item_B.DataB
                    });
                }
            }
           
            // Only to see the completelist data
            foreach (CompleteList item in cl)
            {
                Console.WriteLine(item.ID + " - " + item.DataA + " - " + item.DataB);
            }
        }
    }


    // Making three custom string class where the first contain 2 strings
    // and the second class also only contain 2 strings
    // the third class is a completelist that contian the ID from both list and then the 
    // dataone and datatwo, this is to make a complete list when sort the data and
    // you cannot work with a list that is in use so making a third class is making
    // is easyer to work with
    public class ListA
    {
        public string ID;
        public string DataA;
    }

    public class ListB
    {
        public string ID;
        public string DataB;
    }

    public class CompleteList
    {
        public string ID;
        public string DataA;
        public string DataB;
    }
}
