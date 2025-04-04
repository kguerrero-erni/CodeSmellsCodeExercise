namespace CodeSmellsCodeExercise;

class Order {
    public Customer customer {get;}
    public List<Product> products {get;}
    public double totalPrice {get; private set;}

    public Order(Customer customer, List<Product> products) {
        this.customer = customer;
        this.products = products;
    }

    public void setTotalPrice(double price) {
        totalPrice = price;
    }
}