using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();

    public ListaProduto()
    {
        InitializeComponent();

        lst_produtos.ItemsSource = lista;
    }

    protected async override void OnAppearing()
    {
        try
        {
            lista.Clear();

            List<Produto> tmp = await App.Db.GetAll();

            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoProduto());

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            string q = e.NewTextValue;

            lista.Clear();

            List<Produto> tmp = await App.Db.Search(q);

            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        double soma = lista.Sum(i => i.Total);

        string msg = $"O total ? {soma:C}";

        DisplayAlert("Total dos Produtos", msg, "OK");
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            MenuItem selecinado = sender as MenuItem;

            Produto p = selecinado.BindingContext as Produto;

            bool confirm = await DisplayAlert(
                "Tem Certeza?", $"Remover {p.Descricao}?", "Sim", "N?o");

            if (confirm)
            {
                await App.Db.Delete(p.Id);
                lista.Remove(p);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Produto p = e.SelectedItem as Produto;

            Navigation.PushAsync(new Views.EditarProduto
            {
                BindingContext = p,
            });
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void picker_filtro_clicked(object sender, EventArgs e)
    {
        try
        {
            if (picker_filtro.SelectedItem == null)
                return;

            var categoria = picker_filtro.SelectedItem.ToString();

            lista.Clear();

            List<Produto> tmp;

            if (categoria == "Todos")
            {
                tmp = await App.Db.GetAll();
            }
            else
            {
                tmp = await App.Db.GetByCategoria(categoria);
            }

            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void Total_categoria_Clicked(object sender, EventArgs e)
    {
        var alimentos = await App.Db.GetByCategoria("Alimentos");
        var higiene = await App.Db.GetByCategoria("Higiene");
        var lazer = await App.Db.GetByCategoria("Lazer");
        var limpeza = await App.Db.GetByCategoria("Limpeza");
        var farmacia = await App.Db.GetByCategoria("Farmácia");

        string msg =
            $"Alimentos: {alimentos.Sum(p => p.Total):C}\n" +
            $"Higiene: {higiene.Sum(p => p.Total):C}\n" +
            $"Lazer: {lazer.Sum(p => p.Total):C}\n" +
            $"Limpeza: {limpeza.Sum(p => p.Total):C}\n" +
            $"Farmácia: {farmacia.Sum(p => p.Total):C}";

        await DisplayAlert("Relatório", msg, "OK");
    }

}