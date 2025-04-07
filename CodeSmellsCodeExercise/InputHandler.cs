using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSmellsCodeExercise.Interfaces;

namespace CodeSmellsCodeExercise
{
  public class InputHandler:IInputHandler
  {
    public void NameAddressIsNullOrEmpty(string customerName, string customerAddress)
    {
      if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerAddress))
      {
        Console.WriteLine("Invalid customer details.");
        return;
      }

    }
  }
}
