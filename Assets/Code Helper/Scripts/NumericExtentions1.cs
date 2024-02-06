namespace CodeHelper
{
    public static class NumericExtentions
    {
        public static int Add(ref this int self, int additional)  => self += additional;
        public static float Add(ref this float self, float additional) => self += additional;
        public static decimal Add(ref this decimal self, decimal additional) => self += additional;
        public static double Add(ref this double self, double additional) => self += additional;

        public static int Remove(ref this int self, int removable) => self -= removable;
        public static float Remove(ref this float self, float removable) => self -= removable;
        public static decimal Remove(ref this decimal self, decimal removable) => self -= removable;
        public static double Remove(ref this double self, double removable) => self -= removable;

        public static int Multiply(ref this int self, int additional) => self *= additional;
        public static float Multiply(ref this float self, float additional) => self *= additional;
        public static decimal Multiply(ref this decimal self, decimal additional) => self *= additional;
        public static double Multiply(ref this double self, double additional) => self *= additional;

        public static int Percent(this int self, int percents) => self / 100 * percents;
        public static float Percent(this float self, float percents) => self / 100 * percents;
        public static decimal Percent(this decimal self, decimal percents) => self / 100 * percents;
        public static double Percent(this double self, double percents) => self / 100 * percents;

        public static bool MoreThen(this int value1, int value2) => value1 > value2;
        public static bool MoreThen(this float value1, float value2) => value1 > value2;
        public static bool MoreThen(this decimal value1, decimal value2) => value1 > value2;
        public static bool MoreThen(this double value1, double value2) => value1 > value2;

        public static bool LowerThen(this int value1, int value2) => value1 < value2;
        public static bool LowerThen(this float value1, float value2) => value1 < value2;
        public static bool LowerThen(this decimal value1, decimal value2) => value1 < value2;
        public static bool LowerThen(this double value1, double value2) => value1 < value2;

    }
}

