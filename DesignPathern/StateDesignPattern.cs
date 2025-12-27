public interface VendingMachineState
{
    VendingMachineState InsertCoin(int amount);

    VendingMachineState SelectItem(string selectedItem, int amount);

    VendingMachineState DenpenseItem(string despenseItem);

    VendingMachineState RefillItems(int amount, string selectedItem);

    VendingMachineState ReturnCoin(int returnAmount, string reason);
}

public class NoCoinState : VendingMachineState
{
    public VendingMachineState DenpenseItem(string despenseItem)
    {
        System.Console.WriteLine("Noting to be despense");
        return this;
    }

    public VendingMachineState InsertCoin(int amount)
    {
        System.Console.WriteLine("Coin Accepted - Choose the item");
        return new HasCoinState();
    }

    public VendingMachineState RefillItems(int amount, string selectedItem)
    {
        System.Console.WriteLine("Noting to be Refill");
        return this;
    }

    public VendingMachineState ReturnCoin(int returnAmount, string reason)
    {
        System.Console.WriteLine("Noting to be Return");
        return this;
    }

    public VendingMachineState SelectItem(string selectedItem, int amount)
    {
        System.Console.WriteLine("Noting has been selected");
        return this;
    }
}

internal class HasCoinState : VendingMachineState
{
    private static int availableItems = 2;

    public HasCoinState()
    {
    }

    public VendingMachineState DenpenseItem(string despenseItem)
    {
       System.Console.WriteLine("Noting to be despense");
        return this;
    }

    public VendingMachineState InsertCoin(int amount)
    {
        System.Console.WriteLine("Coin already inserted");
        return this;
    }

    public VendingMachineState RefillItems(int amount, string selectedItem)
    {
        System.Console.WriteLine("Noting to be refill");
        return this;
    }

    public VendingMachineState ReturnCoin(int returnAmount, string reason)
    {
         return new ReturnCoinState().ReturnCoin(returnAmount, reason);
    }

    public VendingMachineState SelectItem(string selectedItem, int amount)
    {
        if (availableItems == 0)
            return new RefillState().RefillItems(amount, selectedItem);

         if (amount < 10)
        {
            return this.ReturnCoin(amount, "In-sufficient amount");
        }

        availableItems--;
        System.Console.WriteLine($"{selectedItem} : Selected. Ready to dispense");
        return new DespenseState();
    }
}

internal class DespenseState : VendingMachineState
{
    public VendingMachineState DenpenseItem(string despenseItem)
    {
        System.Console.WriteLine($"{despenseItem} : has been dispensed");
        return new NoCoinState();
    }

    public VendingMachineState InsertCoin(int amount)
    {
        System.Console.WriteLine("Despense process in-progress - coin can't be inserted");
        return this;
    }

    public VendingMachineState RefillItems(int amount, string selectedItem)
    {
        System.Console.WriteLine("Despense process in-progress - Refill can't be done");
        return this;
    }

    public VendingMachineState ReturnCoin(int returnAmount, string reason)
    {
        System.Console.WriteLine("Despense process in-progress");
        return this;
    }

    public VendingMachineState SelectItem(string selectedItem, int amount)
    {
         System.Console.WriteLine("Despense process in-progress - Item already selected");
        return this;
    }
}

internal class RefillState : VendingMachineState
{
    public VendingMachineState DenpenseItem(string despenseItem)
    {
        System.Console.WriteLine("Rifiling the items");
        return this;
    }

    public VendingMachineState InsertCoin(int amount)
    {
        System.Console.WriteLine("Rifiling the items");
        return this;
    }

    public VendingMachineState RefillItems(int amount, string selectedItem)
    {
       return new ReturnCoinState().ReturnCoin(amount, $"Select Item : {selectedItem} is not available");
    }

    public VendingMachineState ReturnCoin(int returnAmount, string reason)
    {
        System.Console.WriteLine("Rifiling the items");
        return this;
    }

    public VendingMachineState SelectItem(string selectedItem, int amount)
    {
        System.Console.WriteLine("Rifiling the items");
        return this;
    }
}

internal class ReturnCoinState : VendingMachineState
{
    public VendingMachineState DenpenseItem(string despenseItem)
    {
        System.Console.WriteLine("Coin has been return");
        return this;
    }

    public VendingMachineState InsertCoin(int amount)
    {
        System.Console.WriteLine("Coin has been return");
        return this;
    }

    public VendingMachineState RefillItems(int amount, string selectedItem)
    {
        System.Console.WriteLine("Coin has been return");
        return this;
    }

    public VendingMachineState ReturnCoin(int returnAmount, string reason)
    {
        System.Console.WriteLine($"Returing {returnAmount} for {reason}");
        return new NoCoinState();
    }

    public VendingMachineState SelectItem(string selectedItem, int amount)
    {
        System.Console.WriteLine("Coin has been return");
        return this;
    }
}

public class VendingMachine
{
    public static VendingMachine instance = new VendingMachine();
    private VendingMachine()
    {
        
    }
    private static VendingMachineState state = new NoCoinState();

    private VendingMachineState DenpenseItem(string despenseItem)
    {
        return state = state.DenpenseItem(despenseItem);
    }

    public VendingMachineState InsertCoin(int amount)
    {
        return state = state.InsertCoin(amount);
    }

    private VendingMachineState RefillItems(int amount, string selectedItem)
    {
        return state = state.RefillItems(amount, selectedItem);
    }

    private VendingMachineState ReturnCoin(int returnAmount, string reason)
    {
       return state = state.ReturnCoin(returnAmount, reason);
    }

    private VendingMachineState SelectItem(string selectedItem, int amount)
    {
        return state = state.SelectItem(selectedItem, amount);
    }
}

public static class client
{
    public static void mainn()
    {
        VendingMachine.instance.InsertCoin(5).SelectItem("beer", 15).DenpenseItem("beer");
        System.Console.WriteLine();
        VendingMachine.instance.InsertCoin(5).SelectItem("Coke", 15).DenpenseItem("Coke");
        System.Console.WriteLine();
        VendingMachine.instance.InsertCoin(5).SelectItem("Sprint", 15).DenpenseItem("Sprint");
    }
}



namespace StatePatternRefactored
{
    // 1. The Interface
    // We pass the VendingMachine (context) to the methods so the State 
    // can access data (inventory) or switch the state.
    public interface IVendingMachineState
    {
        void InsertCoin(VendingMachine context, int amount);
        void SelectItem(VendingMachine context, string item, int amount);
        void DispenseItem(VendingMachine context);
    }

    // 2. The Context
    public class VendingMachine
    {
        // Internal Data
        public int InventoryCount { get; set; } = 2;
        
        // The State Variable
        private IVendingMachineState _currentState;

        // Pre-initialized states to avoid "new" keywords during runtime (Memory Optimization)
        public IVendingMachineState NoCoin { get; private set; }
        public IVendingMachineState HasCoin { get; private set; }
        public IVendingMachineState Dispense { get; private set; }

        public VendingMachine()
        {
            // Initialize States
            NoCoin = new NoCoinState();
            HasCoin = new HasCoinState();
            Dispense = new DispenseState();

            // Set default
            _currentState = NoCoin;
        }

        public void SetState(IVendingMachineState newState)
        {
            _currentState = newState;
        }

        // --- Actions exposed to the Client ---
        public void InsertCoin(int amount)
        {
            _currentState.InsertCoin(this, amount);
        }

        public void SelectItem(string item, int amount)
        {
            _currentState.SelectItem(this, item, amount);
        }

        public void DispenseItem()
        {
            _currentState.DispenseItem(this);
        }
    }

    // 3. Concrete States

    internal class NoCoinState : IVendingMachineState
    {
        public void InsertCoin(VendingMachine context, int amount)
        {
            Console.WriteLine($"Coin ({amount}) accepted. Please select an item.");
            context.SetState(context.HasCoin);
        }

        public void SelectItem(VendingMachine context, string item, int amount)
        {
            Console.WriteLine("You must insert a coin first.");
        }

        public void DispenseItem(VendingMachine context)
        {
            Console.WriteLine("Payment required first.");
        }
    }

    internal class HasCoinState : IVendingMachineState
    {
        public void InsertCoin(VendingMachine context, int amount)
        {
            Console.WriteLine("Coin already inserted.");
        }

        public void SelectItem(VendingMachine context, string item, int amount)
        {
            // Check Context Data
            if (context.InventoryCount <= 0)
            {
                Console.WriteLine("Item Out of Stock. Returning Coin.");
                context.SetState(context.NoCoin);
                return;
            }

            if (amount < 10)
            {
                Console.WriteLine($"Insufficient amount ({amount}). returning coin.");
                context.SetState(context.NoCoin);
                return;
            }

            Console.WriteLine($"{item} selected. Processing...");
            context.SetState(context.Dispense);
        }

        public void DispenseItem(VendingMachine context)
        {
            Console.WriteLine("Please select an item first.");
        }
    }

    internal class DispenseState : IVendingMachineState
    {
        public void InsertCoin(VendingMachine context, int amount)
        {
            Console.WriteLine("Please wait, dispensing item.");
        }

        public void SelectItem(VendingMachine context, string item, int amount)
        {
            Console.WriteLine("Please wait, dispensing item.");
        }

        public void DispenseItem(VendingMachine context)
        {
            // Modify Context Data
            context.InventoryCount--;
            
            Console.WriteLine($"Item Dispensed. Inventory remaining: {context.InventoryCount}");
            context.SetState(context.NoCoin);
        }
    }

    // 4. Client Code
    public static class Client
    {
        public static void Main11()
        {
            VendingMachine machine = new VendingMachine();

            // Scenario 1: Success
            System.Console.WriteLine("--- Transaction 1 ---");
            machine.InsertCoin(10);
            machine.SelectItem("Beer", 15);
            machine.DispenseItem();

            // Scenario 2: Success
            System.Console.WriteLine("\n--- Transaction 2 ---");
            machine.InsertCoin(10);
            machine.SelectItem("Coke", 15);
            machine.DispenseItem();

            // Scenario 3: Out of Stock (Because inventory started at 2)
            System.Console.WriteLine("\n--- Transaction 3 ---");
            machine.InsertCoin(10);
            machine.SelectItem("Sprite", 15); 
            // Note: State logic will auto-return coin due to lack of inventory
        }
    }
}