using Assignment_thinhvdph26886.Models;
using System;
using System.Text.RegularExpressions;
namespace Assignment_thinhvdph26886.Views.ViewModel

{
    public partial class Login 
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void loginButton_Click(object sender, EventArgs e)
        //{
        //    string username = UserName.Text;
        //    string password = passwordTextBox.Text;

        //    if (!IsValidUsername(username))
        //    {
        //        Response.Write("<script>alert('Invalid username. Username must be at least 6 characters long and can only contain letters and numbers.');</script>");
        //        return;
        //    }

        //    if (!IsValidPassword(password))
        //    {
        //        Response.Write("<script>alert('Invalid password. Password must be at least 6 characters long and can only contain letters and numbers.');</script>");
        //        return;
        //    }

        //    // Redirect to home page
        //    Response.Redirect("Home.aspx");
        //}

        private bool IsValidUsername(string username)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 6)
            {
                return false;
            }

            return Regex.IsMatch(username, @"^[a-zA-Z0-9]+$");
        }

        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                return false;
            }

            return Regex.IsMatch(password, @"^[a-zA-Z0-9]+$");
        }
    }
}
