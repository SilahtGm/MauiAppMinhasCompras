using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
    public EditarProduto()
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
            

            Produto produto_anexado = BindingContext as Produto;

            Produto p = new Produto
            {
                Id = produto_anexado.Id,
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text), 
                Categoria = Convert.ToString(picker_categoria.SelectedItem)
            };

            await App.Db.Update(p);
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
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