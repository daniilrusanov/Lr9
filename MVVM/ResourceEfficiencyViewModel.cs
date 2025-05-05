using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using Avalonia.Interactivity;
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
            CalculateCommand = new RelayCommand(CalculateEfficiency, CanCalculate);
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

        public ICommand CalculateCommand { get; }

        private bool CanCalculate(object parameter)
        {
            // Можна додати більш складну логіку валідації
            return true;
        }

        private void CalculateEfficiency(object parameter)
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

    // Проста реалізація ICommand для MVVM
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}