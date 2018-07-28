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
	public partial class TransfersPage : ContentPage
	{
        readonly IList<Banking_Transfer> transfers = new ObservableCollection<Banking_Transfer>();
        readonly BankingUserManager manager = new BankingUserManager();

		public TransfersPage ()
		{
            BindingContext = transfers;
            InitializeComponent();

            OnRefreshTransfer();
        }

        async void OnRefreshTransfer()
        {
            try
            {
                var transfersCollection = await manager.GetAllTransfers();

                foreach (Banking_Transfer transfer in transfersCollection)
                {
                    if (transfer != null && transfers.All(b => b.Id != transfer.Id))
                        transfers.Add(transfer);
                }
            }
            catch (Exception ex)
            {

            }
        }

        async void OnDetails(object sender, EventArgs e)
        {

        }
    }
}