using System;
using System.Drawing;
using System.Windows.Forms;
using Muhammed.Models;
using Muhammed.Services;
using Muhammed.UI;

namespace Muhammed.Forms
{
    /// <summary>
    /// Окно регистрации нового пользователя.
    /// Новый пользователь всегда получает роль «Сотрудник»:
    /// сделать его администратором может только администратор (в «Пользователях»).
    /// </summary>
    public partial class RegisterForm : Form
    {
        /// <summary>Логин зарегистрированного пользователя (для подстановки в окно входа).</summary>
        public string RegisteredLogin { get; private set; }

        public RegisterForm()
        {
            InitializeComponent();

            // Единое оформление: цвета и шрифты берутся из класса Theme
            Theme.ApplyToForm(this);
            Theme.StylePrimaryButton(btnRegister);
            Theme.StyleMuted(lblHint);
            Theme.StyleGradientHeader(pnlHeader);
            lblCafeName.ForeColor = Color.White;
            lblSubtitle.ForeColor = Theme.SidebarText;
            lblCafeName.Text = Theme.CafeName;
            lblHint.Text = "Пароль — не короче " + AuthService.MinPasswordLength + " символов";
        }

        /// <summary>
        /// Кнопка «Зарегистрироваться»: проверяет ввод и создаёт пользователя.
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            string password2 = txtPassword2.Text;

            // 1. Все поля заполнены
            if (fullName == "")
            {
                ShowError("Введите ФИО.", txtFullName);
                return;
            }
            if (login == "")
            {
                ShowError("Введите логин.", txtLogin);
                return;
            }
            if (password == "")
            {
                ShowError("Введите пароль.", txtPassword);
                return;
            }
            if (password2 == "")
            {
                ShowError("Повторите пароль.", txtPassword2);
                return;
            }

            // 2. В логине нет пробелов (иначе его неудобно вводить)
            if (login.Contains(" "))
            {
                ShowError("Логин не должен содержать пробелов.", txtLogin);
                return;
            }

            // 3. Логин не занят (без учёта регистра: «Admin» и «admin» — один логин)
            if (DataService.FindUserByLogin(login) != null)
            {
                ShowError("Логин «" + login + "» уже занят. Придумайте другой.", txtLogin);
                return;
            }

            // 4. Пароль достаточной длины
            if (password.Length < AuthService.MinPasswordLength)
            {
                ShowError("Пароль должен быть не короче " + AuthService.MinPasswordLength + " символов.", txtPassword);
                return;
            }

            // 5. Пароли совпадают
            if (password != password2)
            {
                ShowError("Пароли не совпадают.", txtPassword2);
                return;
            }

            AuthService.Register(fullName, login, password, UserRole.Сотрудник);
            RegisteredLogin = login;

            MessageBox.Show(
                "Пользователь «" + login + "» зарегистрирован с ролью «Сотрудник».\n" +
                "Теперь войдите с этим логином и паролем.",
                "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK; // форма закроется сама
        }

        /// <summary>Показывает сообщение об ошибке и ставит курсор в поле с ошибкой.</summary>
        private void ShowError(string message, TextBox field)
        {
            MessageBox.Show(message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            field.Focus();
            field.SelectAll();
        }
    }
}
