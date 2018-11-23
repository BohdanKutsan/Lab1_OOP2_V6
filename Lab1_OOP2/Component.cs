using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_OOP2
{
   public abstract class Component
    {
        protected string name;
        protected string patch;
        public Component(string name, string patch)
        {
            this.name = name;
            this.patch = patch;
        }
        public abstract void direc(string n, Component d);
        public abstract string GetName();
        public abstract string GetPatch();        
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Accept(IParameter parameter);

    }
  public  class Directory1 : Component
    {
       
        public override void Accept(IParameter parameter)
        {
            foreach (Component acc in components)
                acc.Accept(parameter);
        }


        public override string GetName()
        { return name; }
        public override string GetPatch()
        { return patch; }
        List<Component> components = new List<Component>();
        public Directory1(string name, string patch) :base(name, patch)
        {  }
       
        public override void Add(Component component)
        {
            components.Add(component);
        }
        public override void Remove(Component component)
        {
            components.Remove(component);
        }
        public override void direc(string n, Component d)
        {
            try
            {
                string[] directories = Directory.GetDirectories(n);
                string[] f = Directory.GetFiles(d.GetPatch(), "*.jpg");
                if (f.Length > 0)
                {
                    for (int j = 0; j < f.Length; j++)
                    {
                        Component f1 = new MonochromImage(Path.GetFileNameWithoutExtension(f[j]), f[j]);

                        d.Add(f1);
                    }
                }


                for (int i = 0; i < directories.Length; i++)
                {
                    Component d1 = new Directory1(Path.GetFileNameWithoutExtension(directories[i]), directories[i]);

                    d.Add(d1);

                    direc(directories[i], d1);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
  public  class MonochromImage : Component
    {

        public override string GetPatch()
        { return patch; }
        public MonochromImage(string name, string patch) : base(name, patch)
        {
        }
        public override string GetName()
        { return name; }



        public override void Accept(IParameter parameter)
        { parameter.ParameterMonochrom(this); }

       
        public override void Add(Component c)
        {
            throw new NotImplementedException();
        }
        public override void direc(string n, Component d)
        {
            throw new NotImplementedException();
        }
        public override void Remove(Component c)
        {
            throw new NotImplementedException();
        }


    }

}
