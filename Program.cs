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
            op.insert(1, "Size 1 Nike, White");
            op.insert(2, "Size 2 Addidas, Black");
            op.insert(3, "Size 3 Converse, Blue");
            op.insert(4, "Size 4 Vans, Black");
            op.insert(5, "Size 5 Timberlands, Brown");
            op.insert(2, "Size 2 Addidas, White");
            op.insert(4, "Size 4 Vans, Red");
            op.insert(5, "Size 5 Timberlands, Black");
            op.insert(1, "Size 1 Nike, Green");
            op.insert(4, "Size 4 Vans, Limited Edition");
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
                hashnode nObj = new hashnode(key, data);
                int hash = key % size;
                Console.WriteLine("We are going to add shoes, {0}, into bucket {1}", data, key);
                Console.ReadKey();
                while (table[hash] != null && table[hash].getkey() % size != key % size)
                {
                    //only run this if table[hash] is not null and the the key value in the table[hash] != key%size  (if no key value, this won't run)
                    hash = (hash + 1) % size;
                }
                if (table[hash] != null && hash == table[hash].getkey() % size)
                {
                    //this runs only if table[hash] is not null and if the key at this table[hash] matches the value of the key we try to enter in
                    nObj.setNextNode(table[hash].getNextNode());
                    table[hash].setNextNode(nObj);
                    print();
                    Console.WriteLine();
                    Console.Write("-----------------------------------------------------");
                    Console.WriteLine();
                    return;
                }
                else
                {
                    //Set new hashnode into table
                    table[hash] = nObj;
                    print();
                    Console.WriteLine();
                    Console.Write("-----------------------------------------------------");
                    Console.WriteLine();
                    return;
                }
            }

            public void print()
            {
                hashnode current = null;
                for (int i = 0; i < size; i++)
                {
                    current = table[i];
                    int j = 0;  //int j just used for --> visuals on console
                    while (current != null)
                    {
                        if (j > 0)
                            Console.Write(" --> ");
                        if (j == 0)
                            Console.Write("Hash Table 'Bucket' {0} : ", i);
                        Console.Write(current.getdata());
                        current = current.getNextNode();
                        j++;
                    }
                    Console.WriteLine();
                }
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