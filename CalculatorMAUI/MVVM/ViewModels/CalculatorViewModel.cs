using PropertyChanged;
using System.Data;
using System.Windows.Input;

namespace CalculatorMAUI.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalculatorViewModel
    {
        public ICommand NumberCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand OperatorCommand { get; }
        public ICommand EqualCommand { get; }

        public ICommand DeleteCommand { get; }

        private string display;
        public string Display
        {
            get { return display; }
            set
            {
                if (display != value)
                {
                    display = value;

                }
            }
        }
        public CalculatorViewModel()
        {
            NumberCommand = new Command<string>(AddNumber);
            ClearCommand = new Command(ClearDisplay);
            OperatorCommand = new Command<string>(ApplyOperator);
            EqualCommand = new Command(PerformCalculation);
            DeleteCommand = new Command(DeleteLastNumber);
        }

        private void DeleteLastNumber()
        {
            if (!string.IsNullOrEmpty(Display))
            {
                Display = Display.Substring(0, Display.Length - 1);
            }
        }

        private void PerformCalculation()
        {
            DataTable dataTable = new DataTable();
            var result = dataTable.Compute(Display, "");
            Display = result.ToString();
        }

        private void AddNumber(string number)
        {
            Display += number;
        }

        private void ClearDisplay()
        {
            Display = string.Empty;
        }

        private void ApplyOperator(string op)
        {
            Display += op;
        }

    }
}

