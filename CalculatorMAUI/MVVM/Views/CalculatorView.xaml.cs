using CalculatorMAUI.MVVM.ViewModels;

namespace CalculatorMAUI.MVVM.Views;

public partial class CalculatorView : ContentPage
{
	public CalculatorView()
	{
		InitializeComponent();
		BindingContext = new CalculatorViewModel();
	}
}