namespace Tamagochi.Core.Consumables
{
    public struct Amusement
    {
        public int fullnessMod;
        public int hapinnesMod;
        public int intellectMod;

        public Amusement(int fullness, int hapinnes, int intellect)
        {
            fullnessMod = fullness;
            hapinnesMod = hapinnes;
            intellectMod = intellect;
        }
    }
}