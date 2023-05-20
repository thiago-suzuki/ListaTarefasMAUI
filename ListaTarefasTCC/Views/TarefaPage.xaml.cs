using ListaTarefasTCC.Infra;
using ListaTarefasTCC.Models;
using System.Threading.Tasks;

namespace ListaTarefasTCC.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class TarefaPage : ContentPage
{
    public Database Database { get; set; }
	public TarefaPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var tarefa = (Tarefa)BindingContext;
        if (tarefa.ID != 0)
            btnDeletar.IsVisible = true;
        else
            btnDeletar.IsVisible = false;
    }

    public async void Salvar(object sender, EventArgs e)
    {
        var tarefa = (Tarefa)BindingContext;

        if (string.IsNullOrEmpty(tarefa.Nome) || string.IsNullOrEmpty(tarefa.Nota))
            await DisplayAlert("Erro", "Preencha os dados corretamente!", "OK");
        else
        {
            await Database.SalvarTarefa(tarefa);
            await Navigation.PopAsync();
        } 
    }

    public async void Deletar(object sender, EventArgs e)
    {
        var tarefa = (Tarefa)BindingContext;
        await Database.DeletarTarefa(tarefa);
        await Navigation.PopAsync();
    }

    public async void Cancelar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}