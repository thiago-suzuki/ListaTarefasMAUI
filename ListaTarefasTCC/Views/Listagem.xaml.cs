using ListaTarefasTCC.Infra;
using ListaTarefasTCC.Models;

namespace ListaTarefasTCC.Views;

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
        List<Tarefa> tarefas = await database.GetTarefas();
        listView.ItemsSource = tarefas.OrderBy(c => DateTime.Parse(c.Nota));
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
