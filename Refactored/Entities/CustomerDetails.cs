using System;

namespace CodeSmellsCodeExercise.Entities;

public class CustomerDetails
{
    public string CustomerName {get; set;}
    public string CustomerAddress {get; set;}

    public CustomerDetails(string customerName, string customerAddress){
        CustomerName = customerName;
        CustomerAddress = customerAddress;
    }

}
