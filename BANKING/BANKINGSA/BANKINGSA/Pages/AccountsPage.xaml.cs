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
	public partial class AccountsPage : ContentPage
	{
        readonly IList<Banking_BankAccount> accounts = new ObservableCollection<Banking_BankAccount>();
        readonly BankingUserManager manager = new BankingUserManager();

        public AccountsPage ()
		{
            BindingContext = accounts;
			InitializeComponent ();

            OnRefresh();
		}

        async void OnRefresh()
        {
            try
            {
                var accountCollection = await manager.GetAllAccounts();

                foreach (Banking_BankAccount account in accountCollection)
                {
                    if (account!=null && accounts.All(b => b.Id != account.Id))
                        accounts.Add(account);
                }
            }catch(Exception ex)
            {

            }
        }

        async void OnDetails(object sender, EventArgs e)
        {

        }

    }
}