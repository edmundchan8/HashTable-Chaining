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
            opentable op = new opentable();
            op.insert(1, "123");
            op.insert(2, "234");
            op.insert(3, "5678");
            op.insert(1, "875");
            op.insert(3, "972364");
            op.insert(4, "72963434");

            op.print();
        }



        class opentable 
        {
            //the linked list nodes that will be in our hash tables
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
                hashnode nObj = new hashnode(key, data);
                int hash = key % size;
                while (table[hash] != null && table[hash].getkey() % size != key % size)
                {
                    hash = (hash + 1) % size;
                }
                if (table[hash] != null && hash == table[hash].getkey() % size)
                {
                    nObj.setNextNode(table[hash].getNextNode());
                    table[hash].setNextNode(nObj);
                    return;
                }
                else
                {
                    table[hash] = nObj;
                    return;
                }
            }
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
            public void print()
            {
                hashnode current = null;
                for (int i = 0; i < size; i++)
                {
                    current = table[i];
                    while (current != null)
                    {
                        Console.Write(current.getdata() + " ");
                        current = current.getNextNode();
                    }
                    Console.WriteLine();
                }
            }

        }
        
    }
}