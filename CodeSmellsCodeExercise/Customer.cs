using CodeSmellsCodeExercise.Interfaces;

namespace CodeSmellsCodeExercise;

class Customer : ICustomer
{
    public string FullName;
    public string Address;

    public Customer(string FullName, string Address)
    {
        this.FullName = FullName;
        this.Address = Address;
    }

    string ICustomer.FullName => FullName;

    string ICustomer.Address => Address;


    public ICustomer GetCustomerInformation()
    {
        return new Customer(FullName, Address);
    }

}