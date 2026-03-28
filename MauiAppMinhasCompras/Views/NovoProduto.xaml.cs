using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void Salvar_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (txt_descricao.Text == null || txt_descricao.Text == "") { throw new Exception("Preencha a descrição"); }
            if (picker_categoria.SelectedItem == null) { throw new Exception("Selecione uma categoria"); }
            if (txt_quantidade.Text == null || txt_quantidade.Text == "") { throw new Exception("Preencha a quantidade"); }
            if (txt_preco.Text == null || txt_preco.Text == "") { throw new Exception("Preencha o preço"); }
           

            Produto p = new Produto
            {
                Descricao = txt_descricao.Text, 
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text),
                Categoria = picker_categoria.SelectedItem.ToString()
        };
           

            await App.Db.Insert(p);
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");
            await Navigation.PopAsync();

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void Cancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

