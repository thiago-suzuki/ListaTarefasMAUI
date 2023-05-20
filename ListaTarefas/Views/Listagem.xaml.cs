using ListaTarefas.Infra;
using ListaTarefas.Models;

namespace ListaTarefas.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Listagem : ContentPage
{
    private Database database;
    public Listagem()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        database = await Database.Instance();
        listView.ItemsSource = await database.GetTarefas();
    }

    public async void AdicionarNovaTarefa(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TarefaPage
        {
            BindingContext = new Tarefa(),
            Database = database
        });
    }

    public async void EditarTarefa(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new TarefaPage
            {
                BindingContext = e.SelectedItem as Tarefa,
                Database = database
            });
        }
    }
}
