using BANKINGSA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BANKINGSA.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaysPage : ContentPage
	{
        readonly IList<Banking_Service> services = new ObservableCollection<Banking_Service>();
        readonly BankingUserManager manager = new BankingUserManager();

		public PaysPage ()
		{
            BindingContext = services;
            InitializeComponent();

            OnRefreshServices();
        }

        async void OnRefreshServices()
        {
            try
            {
                var serviceCollection = await manager.GetAllServices();

                foreach (Banking_Service service in serviceCollection)
                {
                    if (service != null && services.All(b => b.Id != service.Id))
                        services.Add(service);
                }
            }
            catch 
            {

            }
        }

        void OnDetails(object sender, EventArgs e)
        {

        }
    }
}