namespace Lr9.MVP
{
    public interface IResourceEfficiencyView
    {
        double GetBenefits();
        double GetCosts();
        void SetResult(double result);
        void ShowError(string message);
    }
}