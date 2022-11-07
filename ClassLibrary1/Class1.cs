namespace ClassLibrary1
{
    public static class Inventory
    {
        public static int BananaCount { get; set; } = 5;
    }

    public class Cart
    {
        IInventory inventory;
        public Cart(IInventory storeInventory)
        {
            inventory = storeInventory;
            
        }

        private int secretValue;

        private void resetSecretValue(int newVal) => 
            secretValue = newVal;

        public int NumItems { get; private set; }
        public void AddBanana(int numBananas)
        {
            if (inventory.BananaCount < numBananas)
            {
                throw new InsufficientInventoryException();
            }

            NumItems += numBananas;
            inventory.BananaCount -= numBananas;
        }

        public void RemoveBananas(int numBananas)
        {
            NumItems -= numBananas;
            inventory.BananaCount += numBananas;
        }
    }
    public class InsufficientInventoryException: Exception
    {

    }
}