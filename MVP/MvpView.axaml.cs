using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using System;

namespace Lr9.MVP
{
    public partial class MvpView : UserControl, IResourceEfficiencyView
    {
        private ResourceEfficiencyPresenter _presenter;
        private TextBox _benefitsTextBox;
        private TextBox _costsTextBox;
        private TextBlock _resultTextBlock;
        private Button _calculateButton;

        public MvpView()
        {
            InitializeComponent();

            _benefitsTextBox = this.FindControl<TextBox>("BenefitsTextBox");
            _costsTextBox = this.FindControl<TextBox>("CostsTextBox");
            _resultTextBlock = this.FindControl<TextBlock>("ResultTextBlock");
            _calculateButton = this.FindControl<Button>("CalculateButton");

            // Створюємо презентер і передаємо йому посилання на вид (this)
            _presenter = new ResourceEfficiencyPresenter(this);

            _calculateButton.Click += CalculateButton_Click;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            _presenter.OnCalculateClicked();
        }

        // Методи інтерфейсу IResourceEfficiencyView
        public double GetBenefits()
        {
            if (double.TryParse(_benefitsTextBox.Text, out double benefits))
                return benefits;

            throw new FormatException("Вигоди від ресурсу повинні бути числовим значенням");
        }

        public double GetCosts()
        {
            if (double.TryParse(_costsTextBox.Text, out double costs))
                return costs;

            throw new FormatException("Загальні витрати повинні бути числовим значенням");
        }

        public void SetResult(double result)
        {
            _resultTextBlock.Text = result.ToString("F2");
        }

        public void ShowError(string message)
        {
            _resultTextBlock.Text = message;
        }
    }
}
