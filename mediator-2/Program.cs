namespace mediator_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConcreteColleage1 c1 = new ConcreteColleage1();
            ConcreteColleage2 c2 = new ConcreteColleage2();
            ConcreteMediator mediator = new ConcreteMediator(c1, c2);

            c1.SetMediator(mediator);
            c2.SetMediator(mediator);

            c1.Send("Salam");
            c2.Send("Aleyk");

        }



        #region abstract classes
        public abstract class Mediator
        {
            protected ConcreteColleage1 colleage1;
            protected ConcreteColleage2 colleage2;

            public Mediator(ConcreteColleage1 colleage1, ConcreteColleage2 colleage2)
            {
                this.colleage1 = colleage1;
                this.colleage2 = colleage2;
            }

            public abstract void NotifyChange(string message, Colleage colleage);
        }

        public abstract class Colleage
        {
            protected Mediator mediator;
            public void SetMediator(Mediator mediator)
            {
                this.mediator = mediator;
            }


            public virtual void Send(string message)
            {
                mediator.NotifyChange(message, this);
            }
        }
        #endregion

        #region colleages

        public class ConcreteColleage1 : Colleage
        {
            public override void Send(string message)
            {
                Console.WriteLine($"concreteColleage1 sent : {message}");
                base.Send(message);
            }

            public void Receive(string message)
            {
                Console.WriteLine($"concreteColleage1 Received : {message}");
            }
        }


        public class ConcreteColleage2 : Colleage
        {
            public override void Send(string message)
            {
                Console.WriteLine($"concreteColleage2 sent : {message}");
                base.Send(message);
            }

            public void Receive(string message)
            {
                Console.WriteLine($"concreteColleage2 Received : {message}");
            }
        }

        #endregion

        #region Mediator

        public class ConcreteMediator : Mediator
        {
            public ConcreteMediator(ConcreteColleage1 colleage1, ConcreteColleage2 colleage2) : base(colleage1, colleage2)
            {
            }

            public override void NotifyChange(string message, Colleage colleage)
            {
                if(colleage == colleage1)
                {
                    colleage2.Receive(message);
                }
                else if(colleage == colleage2)
                {
                    colleage1.Receive(message);
                }
            }
        }

        #endregion
    }

}