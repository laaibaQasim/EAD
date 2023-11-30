namespace DesignPatterns
{
    //EXAMPLE 1
    // Context: ATMMachine
    public class ATMMachine
    {
        private IATMState currentState;

        public ATMMachine()
        {
            currentState = new IdleState(this);
        }

        public void SetState(IATMState state)
        {
            currentState = state;
        }

        public void InsertCard()
        {
            currentState.InsertCard();
        }

        public void EjectCard()
        {
            currentState.EjectCard();
        }

        public void EnterPIN()
        {
            currentState.EnterPIN();
        }

        public void WithdrawCash()
        {
            currentState.WithdrawCash();
        }
    }

    // State: IATMState
    public interface IATMState
    {
        void InsertCard();
        void EjectCard();
        void EnterPIN();
        void WithdrawCash();
    }

    // ConcreteState: IdleState
    public class IdleState : IATMState
    {
        private ATMMachine atmMachine;

        public IdleState(ATMMachine atmMachine)
        {
            this.atmMachine = atmMachine;
        }

        public void InsertCard()
        {
            Console.WriteLine("Card inserted. Please enter PIN.");
            atmMachine.SetState(new PINEnteredState(atmMachine));
        }

        public void EjectCard()
        {
            Console.WriteLine("No card to eject.");
        }

        public void EnterPIN()
        {
            Console.WriteLine("Please insert a card first.");
        }

        public void WithdrawCash()
        {
            Console.WriteLine("Please insert a card and enter PIN first.");
        }
    }

    // ConcreteState: PINEnteredState
    public class PINEnteredState : IATMState
    {
        private ATMMachine atmMachine;

        public PINEnteredState(ATMMachine atmMachine)
        {
            this.atmMachine = atmMachine;
        }

        public void InsertCard()
        {
            Console.WriteLine("Card already inserted.");
        }

        public void EjectCard()
        {
            Console.WriteLine("Card ejected. Returning to idle state.");
            atmMachine.SetState(new IdleState(atmMachine));
        }

        public void EnterPIN()
        {
            Console.WriteLine("PIN already entered.");
        }

        public void WithdrawCash()
        {
            Console.WriteLine("Cash withdrawn. Returning to idle state.");
            atmMachine.SetState(new IdleState(atmMachine));
        }
    }

    //EXAMPLE 2
    // Context: TrafficLight
    public class TrafficLight
    {
        private ITrafficLightState currentState;

        public TrafficLight()
        {
            currentState = new RedState(this);
        }

        public void SetState(ITrafficLightState state)
        {
            currentState = state;
        }

        public void ChangeState()
        {
            currentState.ChangeState();
        }
    }

    // State: ITrafficLightState
    public interface ITrafficLightState
    {
        void ChangeState();
    }

    // ConcreteState: RedState
    public class RedState : ITrafficLightState
    {
        private TrafficLight trafficLight;

        public RedState(TrafficLight trafficLight)
        {
            this.trafficLight = trafficLight;
        }

        public void ChangeState()
        {
            Console.WriteLine("Traffic Light: Red");
            trafficLight.SetState(new GreenState(trafficLight));
        }
    }

    // ConcreteState: GreenState
    public class GreenState : ITrafficLightState
    {
        private TrafficLight trafficLight;

        public GreenState(TrafficLight trafficLight)
        {
            this.trafficLight = trafficLight;
        }

        public void ChangeState()
        {
            Console.WriteLine("Traffic Light: Green");
            trafficLight.SetState(new YellowState(trafficLight));
        }
    }

    // ConcreteState: YellowState
    public class YellowState : ITrafficLightState
    {
        private TrafficLight trafficLight;

        public YellowState(TrafficLight trafficLight)
        {
            this.trafficLight = trafficLight;
        }

        public void ChangeState()
        {
            Console.WriteLine("Traffic Light: Yellow");
            trafficLight.SetState(new RedState(trafficLight));
        }
    }

}