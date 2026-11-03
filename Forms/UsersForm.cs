using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Muhammed.Models;
using Muhammed.Services;
using Muhammed.UI;

namespace Muhammed.Forms
{
    /// <summary>
    /// Окно «Пользователи» (админ-панель): список пользователей, смена роли и удаление.
    /// Нельзя удалить самого себя и нельзя снять роль администратора с самого себя —
    /// иначе в программе может не остаться ни одного администратора.
    /// </summary>
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();

            // Единое оформление: цвета и шрифты берутся из класса Theme
            Theme.ApplyToForm(this);
            Theme.StylePrimaryButton(btnChangeRole);
            Theme.SetIcon(btnChangeRole, Theme.IconCheck);
            Theme.StyleDangerButton(btnDelete);
            Theme.SetIcon(btnDelete, Theme.IconDelete);
            Theme.StyleMuted(lblCount);

            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                cmbRole.Items.Add(role);
            }
            cmbRole.SelectedIndex = 0;

            RefreshUsers();
        }

        /// <summary>
        /// Защита: окно доступно только администратору,
        /// даже если его откроют не из админ-панели.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!CurrentUser.IsAdmin)
            {
                MessageBox.Show("Управлять пользователями может только администратор.", "Нет доступа",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
        }

        /// <summary>
        /// Заново заполняет таблицу пользователей (сортировка по ФИО).
        /// </summary>
        /// <param name="selectId">Номер пользователя, которого нужно выделить (0 — первого).</param>
        private void RefreshUsers(int selectId = 0)
        {
            List<User> sorted = new List<User>(DataService.Users);
            sorted.Sort(CompareUsers);

            dgvUsers.Rows.Clear();
            foreach (User user in sorted)
            {
                // Рядом со своей учётной записью пишем «(вы)», чтобы было видно, кто вошёл
                string name = user.FullName;
                if (user == CurrentUser.User)
                {
                    name += " (вы)";
                }

                int rowIndex = dgvUsers.Rows.Add(user.Id, name, user.Login, user.Role.ToString());
                if (user.Id == selectId)
                {
                    dgvUsers.CurrentCell = dgvUsers.Rows[rowIndex].Cells[colFullName.Index];
                }
            }

            lblCount.Text = "Пользователей: " + DataService.Users.Count;
        }

        /// <summary>Правило сортировки пользователей: по ФИО.</summary>
        private static int CompareUsers(User a, User b)
        {
            return string.Compare(a.FullName, b.FullName, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// Возвращает пользователя из выделенной строки.
        /// Если ничего не выделено — показывает сообщение и возвращает null.
        /// </summary>
        private User GetSelectedUser()
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Выберите пользователя в таблице.", "Пользователи",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells[colUserId.Index].Value);
            foreach (User user in DataService.Users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        /// <summary>При выборе строки показываем текущую роль пользователя в списке «Роль».</summary>
        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                return;
            }

            int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells[colUserId.Index].Value);
            foreach (User user in DataService.Users)
            {
                if (user.Id == id)
                {
                    cmbRole.SelectedItem = user.Role;
                }
            }
        }

        /// <summary>«Изменить роль»: ставит выбранному пользователю роль из списка.</summary>
        private void btnChangeRole_Click(object sender, EventArgs e)
        {
            User user = GetSelectedUser();
            if (user == null)
            {
                return;
            }

            UserRole newRole = (UserRole)cmbRole.SelectedItem;
            if (user.Role == newRole)
            {
                MessageBox.Show("У пользователя «" + user.Login + "» уже роль «" + newRole + "».", "Роль",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Себя понизить нельзя: иначе можно остаться без администратора
            if (user == CurrentUser.User && newRole != UserRole.Администратор)
            {
                MessageBox.Show("Нельзя снять роль администратора с самого себя.", "Роль",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.SelectedItem = user.Role;
                return;
            }

            user.Role = newRole;
            DataService.SaveUsers();
            RefreshUsers(user.Id);
        }

        /// <summary>«Удалить»: удаляет выбранного пользователя после подтверждения.</summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            User user = GetSelectedUser();
            if (user == null)
            {
                return;
            }

            if (user == CurrentUser.User)
            {
                MessageBox.Show("Нельзя удалить самого себя.", "Удаление пользователя",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Удалить пользователя «" + user.FullName + "» (логин " + user.Login + ")?\n\n" +
                "Он больше не сможет войти в программу.",
                "Удаление пользователя",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                DataService.Users.Remove(user);
                DataService.SaveUsers();
                RefreshUsers();
            }
        }
    }
}
