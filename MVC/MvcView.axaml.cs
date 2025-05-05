using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using System;

namespace Lr9.MVC
{
    public partial class MvcView : UserControl
    {
        private ResourceEfficiencyController _controller;
        private TextBox _benefitsTextBox;
        private TextBox _costsTextBox;
        private TextBlock _resultTextBlock;
        private Button _calculateButton;

        public MvcView()
        {
            InitializeComponent();
            _controller = new ResourceEfficiencyController();

            _benefitsTextBox = this.FindControl<TextBox>("BenefitsTextBox");
            _costsTextBox = this.FindControl<TextBox>("CostsTextBox");
            _resultTextBlock = this.FindControl<TextBlock>("ResultTextBlock");
            _calculateButton = this.FindControl<Button>("CalculateButton");

            _calculateButton.Click += CalculateButton_Click;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(_benefitsTextBox.Text, out double benefits) &&
                double.TryParse(_costsTextBox.Text, out double costs))
            {
                _controller.SetBenefits(benefits);
                _controller.SetCosts(costs);
                double result = _controller.CalculateEfficiency();
                UpdateUI(result);
            }
            else
            {
                _resultTextBlock.Text = "Помилка вводу. Будь ласка, введіть числові значення.";
            }
        }

        private void UpdateUI(double result)
        {
            _resultTextBlock.Text = result.ToString("F2");
        }
    }
}