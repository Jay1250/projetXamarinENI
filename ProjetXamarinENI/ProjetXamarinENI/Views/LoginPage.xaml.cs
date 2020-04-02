using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetXamarinENI.Views
{
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {





        public LoginPage()
        {
            InitializeComponent();
        }

        private void Connection_Clicked(object sender, EventArgs e)
        {

            String identifierStr = this.identifier.Text;
            String passwordStr = this.password.Text;
            Boolean isRemember = this.remember.IsToggled;


            String name = this.Name


            this.error.IsVisible = false;

            if (String.IsNullOrEmpty(identifierStr) || identifierStr.Length < 3)
            {
                this.error.Text = "Veuillez entrer un identifiant d'au moins 3 caractères";
                this.error.IsVisible = true; return;
            }

            if (String.IsNullOrEmpty(passwordStr) || passwordStr.Length < 6)
            {
                this.error.Text = "Veuillez entrer un mot de passe d'au moins 6 caractères";
                this.error.IsVisible = true; return;
            }


         //   this.form.IsVisible = false;
          //  this.tweets.IsVisible = true;

        }
    }
}