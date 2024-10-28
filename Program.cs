namespace Parrallel.ForeachEaxample
{
    internal class Program
    {

        static List<OrderViewModel> orders = new List<OrderViewModel>
        {

            new OrderViewModel
            {
                OrderId = 1,
                Items = new List<OrderItem>
                {
                    new OrderItem { Price = 10.0m, Quantity = 2 },
                    new OrderItem { Price = 5.0m, Quantity = 3 }
                }
            },
            new OrderViewModel
            {
                OrderId = 2,
                Items = new List<OrderItem>
                {
                    new OrderItem { Price = 8.0m, Quantity = 1 },
                    new OrderItem { Price = 12.0m, Quantity = 2 }
                }
            },
            new OrderViewModel
            {
                OrderId = 3,
                Items = new List<OrderItem>
                {
                    new OrderItem { Price = 7.5m, Quantity = 4 },
                    new OrderItem { Price = 3.5m, Quantity = 5 }
                }
            }
       };

        static void Main(string[] args)
        {

            Parallel.ForEach(orders, order =>
            {
                order.TotalAmount = order.Items.Sum(item => item.Price * item.Quantity);
            });

            foreach (var order in orders)
            {
                Console.WriteLine($" Id = {order.OrderId} : Total = {order.TotalAmount}");

            }

        }
    }
}
public class OrderViewModel
{
    public int OrderId { get; set; }
    public List<OrderItem> Items { get; set; }
    public decimal TotalAmount { get; set; }
}

public class OrderItem
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

