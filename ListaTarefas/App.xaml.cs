using ListaTarefas.Views;

namespace ListaTarefas;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new NavigationPage(new Listagem())
        {
            BarTextColor = Color.FromRgb(255, 255, 255)
        };
    }
}
