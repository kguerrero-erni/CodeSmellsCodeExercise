using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise.Entities
{
  public class User
  {
    public User(string name, string address)
    {
      Name = name;
      Address = address;
    }

    public string Name {  get; set; }
    public string Address { get; set; }
  }
}
