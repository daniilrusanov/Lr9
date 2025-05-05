namespace Lr9.MVP
{
    public class ResourceEfficiencyPresenter
    {
        private ResourceEfficiencyModel _model;
        private IResourceEfficiencyView _view;

        public ResourceEfficiencyPresenter(IResourceEfficiencyView view)
        {
            _model = new ResourceEfficiencyModel();
            _view = view;
        }

        public void OnCalculateClicked()
        {
            try
            {
                _model.Benefits = _view.GetBenefits();
                _model.Costs = _view.GetCosts();
                double result = _model.CalculateEfficiency();
                _view.SetResult(result);
            }
            catch (System.Exception ex)
            {
                _view.ShowError($"Помилка розрахунку: {ex.Message}");
            }
        }
    }
}