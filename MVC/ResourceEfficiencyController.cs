namespace Lr9.MVC
{
    public class ResourceEfficiencyController
    {
        private ResourceEfficiencyModel _model;

        public ResourceEfficiencyController()
        {
            _model = new ResourceEfficiencyModel();
        }

        public void SetBenefits(double benefits)
        {
            _model.Benefits = benefits;
        }

        public void SetCosts(double costs)
        {
            _model.Costs = costs;
        }

        public double CalculateEfficiency()
        {
            return _model.CalculateEfficiency();
        }

        public ResourceEfficiencyModel GetModel()
        {
            return _model;
        }
    }
}