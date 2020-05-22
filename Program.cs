using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Edmund's and Richard's walkthrough of Hash Table - Chaining");
            Console.WriteLine("Please note, the variable 'size' is always 10 in our case");
            Console.WriteLine();
            opentable op = new opentable();
            op.insert(40, "Nike, $40");
            op.insert(40, "Nike, $41");
            op.insert(30, "Addidas, $30");
            op.insert(32, "Converse, $32");
            op.insert(49, "Vans, $49");
            op.insert(99, "Timberlands, $99");
            op.insert(59, "Addidas, $59");
            op.insert(45, "Vans, $45");
            op.insert(120, "Timberlands, $120");
            op.insert(77, "Nike, $77");
            op.insert(55, "Vans, $55");
        }


        class opentable 
        {
            //creating the linked list nodes that will be in our hash tables
            class hashnode
            {
                int key;
                string data;
                hashnode next;
                public hashnode(int key, string data)
                {
                    this.key = key;
                    this.data = data;
                    next = null;
                }
                public int getkey()
                {
                    return key;
                }
                public string getdata()
                {
                    return data;
                }
                public void setNextNode(hashnode obj)
                {
                    next = obj;
                }
                public hashnode getNextNode()
                {
                    return this.next;
                }
            }


            //variables to create the hashnode table
            hashnode[] table;
            const int size = 10;


            //constructor that produces the table
            public opentable()
            {
                table = new hashnode[size];
                for (int i = 0; i < size; i++)
                {
                    table[i] = null;
                }
            }
           

            public void insert(int key, string data)
            {
                Console.WriteLine("We are going to add the shoes, {0}, into a bucket in the hashtable based off of the key, {1}.", data, key);
                Console.ReadKey();

                hashnode nObj = new hashnode(key, data);
                int hash = key % size;  //This handles the hash index which will determine where to put the new hashnode to

                Console.WriteLine("Our hash is calculated with key % size, which in this case is:");
                Console.WriteLine("{0} % {1} which evalutates to {2}", key, size, hash);
                Console.WriteLine();
                Console.WriteLine("Check if there is a value in hash location of {0}", hash);
                Console.ReadKey();
                Console.WriteLine("******");

                while (table[hash] != null && table[hash].getkey() % size != key % size)
                {
                    //only run this if table[hash] is not null and the the key value in the table[hash] != key%size  (if no key value, this won't run)
                    hash = (hash + 1) % size;
                }
                if (table[hash] != null && hash == table[hash].getkey() % size)
                {
                    //this runs only if table[hash] is not null and if the key at this table[hash] matches the value of the key we try to enter in
                    print();
                    Console.WriteLine();
                    Console.WriteLine("Current hash location of {0} is not empty, so we'll add it to the linked list", hash);
                    Console.Write("******");
                    Console.WriteLine();
                    Console.ReadKey();
                    nObj.setNextNode(table[hash].getNextNode());
                    table[hash].setNextNode(nObj);
                    print();
                    return;
                }
                else
                {
                    print();
                    Console.WriteLine();
                    Console.WriteLine("The hash location at {0} is empty, so we'll just slot our value in there", hash);
                    Console.Write("******");
                    Console.WriteLine();
                    Console.ReadKey();
                    //Set new hashnode into table
                    table[hash] = nObj;
                    print();
                    return;
                }
            }

            public void print()
            {
                hashnode current = null;
                for (int i = 0; i < size; i++)
                {
                    current = table[i];
                    if (current == null)
                        Console.Write("- Unused Hash Table 'Bucket'");
                    int j = 0;  //int j just used for --> visuals on console
                    while (current != null)
                    {
                        if (j > 0)
                            Console.Write(" --> ");
                        if (j == 0)
                            Console.Write("Hash Table 'Bucket' {0} : ", i);
                        Console.Write("[" + current.getdata() + "]");
                        current = current.getNextNode();
                        j++;
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("------------------------------");
                Console.WriteLine();
            }

            /*
            public string retrieve(int key)
            {
                int hash = key % size;
                while (table[hash] != null && table[hash].getkey() % size != key % size)
                {
                    hash = (hash + 1) % size;
                }
                hashnode current = table[hash];
                while (current.getkey() != key && current.getNextNode() != null)
                {
                    current = current.getNextNode();
                }
                if (current.getkey() == key)
                {
                    return current.getdata();
                }
                else
                {
                    return "nothing found!";
                }
            }
            public void remove(int key)
            {
                int hash = key % size;
                while (table[hash] != null && table[hash].getkey() % size != key % size)
                {
                    hash = (hash + 1) % size;
                }
                //a current node pointer used for traversal, currently points to the head
                hashnode current = table[hash];
                bool isRemoved = false;
                while (current != null)
                {
                    if (current.getkey() == key)
                    {
                        table[hash] = current.getNextNode();
                        Console.WriteLine("entry removed successfully!");
                        isRemoved = true;
                        break;
                    }

                    if (current.getNextNode() != null)
                    {
                        if (current.getNextNode().getkey() == key)
                        {
                            hashnode newNext = current.getNextNode().getNextNode();
                            current.setNextNode(newNext);
                            Console.WriteLine("entry removed successfully!");
                            isRemoved = true;
                            break;
                        }
                        else
                        {
                            current = current.getNextNode();
                        }
                    }

                }

                if (!isRemoved)
                {
                    Console.WriteLine("nothing found to delete!");
                    return;
                }
            }

    */
        }

    }
}