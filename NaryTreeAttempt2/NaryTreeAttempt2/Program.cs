using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NaryTreeAttempt2.DataStructures;

namespace NaryTreeAttempt2
{
    class Program
    {    
        static void Main(string[] args)
        {
            Node<string> Node1 = new Node<string>("Bomba");        
            Node<string> Node2 = new Node<string>("Ko");
            

            DataStructures.List<string> list = new DataStructures.List<string>();
            list.Add(Node1);
            list.Add(Node2);
            
        
            list.Print();
        }

    }
}