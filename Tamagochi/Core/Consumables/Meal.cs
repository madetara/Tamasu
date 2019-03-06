namespace Tamagochi.Core.Consumables
{
    public struct Meal
    {
        public int fullnessMod;
        public int hapinnesMod;
        public int intellectMod;

        public Meal(int fullness, int hapinnes, int intellect)
        {
            fullnessMod = fullness;
            hapinnesMod = hapinnes;
            intellectMod = intellect;
        }
    }
}