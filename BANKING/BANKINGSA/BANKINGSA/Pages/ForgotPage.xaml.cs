using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BANKINGSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgotPage : ContentPage
	{
		public ForgotPage ()
		{
			InitializeComponent ();
		}

        async private void btnForgot_Clicked(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("hermes.sm2010@gmail.com", "Equipo Banking");
                message.To.Add(txtEmail.Text);
                message.Subject = "Recuperación Contraseña";
                message.Body = "Has olvidado la contraseña, favor contacta a los administradores de la app!";
                //client.UseDefaultCredentials = true;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("hermes.sm2010@gmail.com", "hermes15");
                client.Send(message);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Atención", "Error al enviar el correo. "+ ex.ToString(), "Ok");
            }
        }
    }
}