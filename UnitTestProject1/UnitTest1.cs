using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1_OOP2;
using System.IO;

namespace UnitTestLab1_OOP2
{
    [TestClass]
    public class TestComponent
    {   Component dir = new Directory1("Image", @"C:\Image");
        Component d1 = new Directory1("Foto", @"C:\Image\Foto");
        Component f1 = new MonochromImage("1", @"C:\Image\1.jpg");
        Component d2 = new Directory1("Family", @"C:\Image\Foto\Family");
        Component d3 = new Directory1("Friend", @"C:\Image\Foto\Friend");
        Component f2 = new MonochromImage("2", @"C:\Image\Foto\Family\2.jpg");
        MonochromImage f3 = new MonochromImage("3", @"C:\Image\Foto\Friend\3.jpg");
       
        public void DirectoryAdd()
        {
            dir.Add(d1);
            dir.Add(f1);
            d1.Add(d2);
            d1.Add(d3);
            d2.Add(f2);
            d3.Add(f3);
        }
        [TestMethod]
        public void TestGetName()
        {
            DirectoryAdd();
            Assert.AreEqual<string>("2", f2.GetName());
        }
        [TestMethod]
        public void TestGetPatch()
        {
            DirectoryAdd();
            Assert.AreEqual<string>(@"C:\Image\Foto\Family\2.jpg", f2.GetPatch());
        }

        [TestMethod]
        public void TestCOR()
        {
            string patch = @"C:\Image\Foto\Friend";
           IParameter c = new COR();
            DirectoryInfo dnew = Directory.CreateDirectory(patch);
            c.ParameterMonochrom(f3);
            Assert.AreEqual<bool>(true, File.Exists(@"C:\Image\Foto\Friend\3.txt"));
        }
    }
   
}
