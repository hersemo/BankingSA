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
	public partial class RegisterPage : ContentPage
	{
        BankingUserManager userManager = new BankingUserManager();

        public RegisterPage ()
		{
			InitializeComponent ();
		}

        async private void btnRegister_Clicked(object sender, EventArgs e)
        {
            if (txtPwd.Text == null || txtPwd.Text.Length < 6)
            {
                await DisplayAlert("Atención", "La contraseña debe contener al menos 6 caracteres", "Ok");
                return;
            }
            try
            {
                User_Model user = new User_Model();
                //user.Id = txtId.Text;
                user.FirstName = txtName.Text;
                user.LastName = txtLastName.Text;
                user.Email = txtEmail.Text;
                user.PhoneNumber = txtPhone.Text;
                user.Password = txtPwd.Text;

                Banking_User _user = await userManager.Add(user);
                await Navigation.PopModalAsync();
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", "No hemos podido crear su Usuario. "+ex.Message, "Ok");
                await Navigation.PopModalAsync();
            }
        }
    }
}