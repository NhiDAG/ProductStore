using BussinessObjects;
using Microsoft.Identity.Client;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductStore
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IAccountRepository iAccountRepositories;
        public LoginWindow()
        {
            InitializeComponent();
            iAccountRepositories = new AccountRepository();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            AccountMember account = iAccountRepositories.GetAccountById(txtUser.Text);
            if (account != null && account.MemberPassword.Equals(txtPass.Password) 
                && account.MemberRole == 1){
                this.Hide();
                MainWindow main = new MainWindow();
                main.Show();
            }
            else
            {
                MessageBox.Show("You are not permission!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
