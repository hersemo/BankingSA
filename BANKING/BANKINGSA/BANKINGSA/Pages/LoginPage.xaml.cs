using BANKINGSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BANKINGSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        BankingUserManager userManager = new BankingUserManager();
        public LoginPage ()
		{
			InitializeComponent ();
            var onLblRegisterClick = new TapGestureRecognizer();
            onLblRegisterClick.Tapped += OnLblRegisterClick_Tapped;
            lblRegister.GestureRecognizers.Add(onLblRegisterClick);

            var onLblPassClick = new TapGestureRecognizer();
            onLblPassClick.Tapped += OnLblPassClick_Tapped;
            lblPass.GestureRecognizers.Add(onLblPassClick);
		}

        async private void OnLblPassClick_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ForgotPage());
        }

        async private void OnLblRegisterClick_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }

        async private void btnLogin_Cliked(object sender, EventArgs e)
        {
            if (passwordEntry.Text == null || usernameEntry.Text == null)
            {
                await DisplayAlert("Atención", "Debe ingresar el usuario y la contraseña.", "Ok");
                return;
            }
            Banking_User _user = await userManager.Login(usernameEntry.Text,passwordEntry.Text);
            if (_user != null) {
                await Navigation.PushModalAsync(new MainPage());
                passwordEntry.Text = null;
                usernameEntry.Text = null;
            }
            else
            {
                await DisplayAlert("Atención", "Usuario y/o contraseña incorrectos.", "Ok");
                return;
            }
        }
        
    }
}