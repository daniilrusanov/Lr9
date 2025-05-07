using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Lr9.MVVM
{
    public class ResourceEfficiencyViewModel : INotifyPropertyChanged
    {
        private ResourceEfficiencyModel _model;
        private double _benefits;
        private double _costs;
        private double _result;
        private string _errorMessage;

        public ResourceEfficiencyViewModel()
        {
            _model = new ResourceEfficiencyModel();
            // Встановлюємо початкові значення
            Benefits = 100;
            Costs = 50;
        }

        public double Benefits
        {
            get => _benefits;
            set
            {
                if (_benefits != value)
                {
                    _benefits = value;
                    OnPropertyChanged();
                    CalculateEfficiency();
                }
            }
        }

        public double Costs
        {
            get => _costs;
            set
            {
                if (_costs != value)
                {
                    _costs = value;
                    OnPropertyChanged();
                    CalculateEfficiency();
                }
            }
        }

        public double Result
        {
            get => _result;
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        private void CalculateEfficiency()
        {
            try
            {
                _model.Benefits = Benefits;
                _model.Costs = Costs;
                Result = _model.CalculateEfficiency();
                ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Помилка розрахунку: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}