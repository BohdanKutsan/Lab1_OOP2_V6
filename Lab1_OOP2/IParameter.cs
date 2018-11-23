using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_OOP2
{
 public   interface IParameter
    {
        void ParameterMonochrom(MonochromImage image);
    }
  public  class CON : IParameter
    {

        public void ParameterMonochrom(MonochromImage image)
        {
            string directoryName = Path.GetDirectoryName(image.GetPatch());

            string filetxt = image.GetName() + ".txt";

            string patch = Path.Combine(directoryName, filetxt);
            var fileSize = new System.IO.FileInfo(image.GetPatch()).Length;
            if (!File.Exists(patch))
            {


                File.WriteAllText(patch, "    " + Environment.NewLine);
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            string parameter = "Parameter CON:" + Environment.NewLine;
            File.AppendAllText(patch, parameter);
            string appendText = fileSize + Environment.NewLine;
            File.AppendAllText(patch, appendText);




        }
    }
   public class COR : IParameter
    {
        public void ParameterMonochrom(MonochromImage image)
        {
            string directoryName = Path.GetDirectoryName(image.GetPatch());

            string filetxt = image.GetName() + ".txt";

            string patch = Path.Combine(directoryName, filetxt);

            if (!File.Exists(patch))
            {


                File.WriteAllText(patch, "    " + Environment.NewLine);
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            string parameter = "Parameter COR:" + Environment.NewLine;
            File.AppendAllText(patch, parameter);
            string appendText = "/////////////////////////////////////" + Environment.NewLine;
            File.AppendAllText(patch, appendText);




        }
    }

    class ASM : IParameter
    {
        public void ParameterMonochrom(MonochromImage image)
        { }
    }

    class ENT : IParameter
    {
        public void ParameterMonochrom(MonochromImage image)
        { }


    }



}
