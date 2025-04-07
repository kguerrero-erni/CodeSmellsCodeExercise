using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise.Interfaces
{
  public interface IInputHandler
  {
    public void NameAddressIsNullOrEmpty(string customerName, string customerAddress);
  }
}
