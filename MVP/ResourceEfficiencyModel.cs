namespace Lr9.MVP
{
    public class ResourceEfficiencyModel
    {
        public double Benefits { get; set; }
        public double Costs { get; set; }

        public double CalculateEfficiency()
        {
            if (Costs <= 0)
                return 0;
                
            return Benefits / Costs;
        }
    }
}