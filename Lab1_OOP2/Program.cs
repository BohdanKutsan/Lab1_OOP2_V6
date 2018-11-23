using Lab1_OOP2;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_OOP2
{
   public class Client
    {

        
            static void Main(string[] args)
        {
            
            string namedirectory = @"C:\Users\Богдан\Desktop\Image";
            Component dir = new Directory1(Path.GetFileNameWithoutExtension(namedirectory), namedirectory);      
            Client c = new Client();
            dir.direc(namedirectory, dir);          
            dir.Accept(new CON());
            dir.Accept(new COR());
            
        }
}  
    }
  
   
