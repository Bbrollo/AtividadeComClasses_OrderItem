using PedidosTreinamentoClasses.Entities;
using PedidosTreinamentoClasses.Entities.Enums;
using System.Globalization;
namespace PedidosTreinamentoClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many itens to this order? ");
            int numItensOrder = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numItensOrder; i++)
            {
                Console.WriteLine("Enter #{0} product data", i);
                Console.Write("Enter product name: ");
                string productName = Console.ReadLine();
                Console.Write("Enter product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Enter product quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, price);
                OrderItem orderItem = new OrderItem(quantity, price, product);

                order.Items.Add(orderItem);
            }

            Console.WriteLine("ORDER SUMMARY: ");
            Console.WriteLine(order);

        }
    }
}
