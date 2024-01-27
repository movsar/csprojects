
namespace CakesWpf
{
    internal class Kitchen
    {
        private Storage storage;

        public Kitchen(Storage storage)
        {
            this.storage = storage;
        }

        internal object GetAvailableRecipes()
        {
            throw new NotImplementedException();
        }

        internal void MakeCake(string selectedCakeName)
        {
            throw new NotImplementedException();
        }
    }
}