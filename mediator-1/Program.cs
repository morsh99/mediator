namespace mediator_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Concrete1 concrete1 = new Concrete1();
            Concrete2 concrete2 = new Concrete2();

            concrete1.SetConnector(concrete2);
            concrete2.SetConnector(concrete1);

            concrete1.Send("Salam khobi?");
            concrete2.Send("Salam merci");

            Console.ReadKey();
        } 
    }

    //ارتباط بین دوتا کلاس بدون mediator

    //abstract class for users
    public abstract class Connector
    {
        public abstract void Send(string message);
    }

    //user 1
    public class Concrete1 : Connector
    {
        private Concrete2 concrete2;

        public void SetConnector(Concrete2 concrete)
        {
            this.concrete2 = concrete;
        }

        public override void Send(string message)
        {
            Console.WriteLine($"Concrete1 sent : {message}");
            concrete2.Recieve(message);
        }

        public void Recieve(string message)
        {
            Console.WriteLine($"Concrete1 Recieved : {message}");
        }
    }


    //user2
    public class Concrete2 : Connector
    {
        private Concrete1 concrete1;

        public void SetConnector(Concrete1 concrete)
        {
            this.concrete1 = concrete;
        }
        public override void Send(string message)
        {
            Console.WriteLine($"Concrete2 Sent : {message}");
            concrete1.Recieve(message);
        }

        public void Recieve(string message)
        {
            Console.WriteLine($"Concrete2 Recieved : {message}");
        }
    }



}