using System;
using System.Drawing;
using System.Windows.Forms;
using Muhammed.Models;
using Muhammed.Services;
using Muhammed.UI;

namespace Muhammed.Forms
{
    /// <summary>
    /// Окно входа. Открывается первым при запуске программы.
    /// Если вход успешен — запоминает пользователя в CurrentUser
    /// и закрывается с результатом OK.
    /// </summary>
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // Единое оформление: цвета и шрифты берутся из класса Theme
            Theme.ApplyToForm(this);
            Theme.StylePrimaryButton(btnLogin);
            Theme.StyleGradientHeader(pnlHeader);
            lblCafeName.ForeColor = Color.White;
            lblSubtitle.ForeColor = Theme.SidebarText;
            lblCafeName.Text = Theme.CafeName;
            Text = "Вход — " + Theme.CafeName;
        }

        /// <summary>
        /// Кнопка «Войти» (или Enter — она назначена AcceptButton формы).
        /// Проверяет, что поля заполнены, и ищет пользователя с таким логином и паролем.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (login == "")
            {
                ShowError("Введите логин.");
                txtLogin.Focus();
                return;
            }
            if (password == "")
            {
                ShowError("Введите пароль.");
                txtPassword.Focus();
                return;
            }

            User user = AuthService.Login(login, password);
            if (user == null)
            {
                // Не уточняем, что именно неверно (логин или пароль), —
                // так посторонний не узнает, какие логины существуют
                ShowError("Неверный логин или пароль.");
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            CurrentUser.SignIn(user);
            DialogResult = DialogResult.OK; // форма закроется сама
        }

        /// <summary>Галочка «Показать пароль»: показывает или скрывает символы пароля.</summary>
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        /// <summary>
        /// Кнопка «Регистрация»: открывает окно регистрации.
        /// После успешной регистрации подставляет новый логин в поле «Логин».
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (RegisterForm form = new RegisterForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    txtLogin.Text = form.RegisteredLogin;
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
        }

        /// <summary>Показывает сообщение об ошибке.</summary>
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Вход", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
