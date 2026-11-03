using System;
using System.Security.Cryptography;
using System.Text;
using Muhammed.Models;

namespace Muhammed.Services
{
    /// <summary>
    /// Вход, регистрация и работа с паролями.
    ///
    /// Как хранится пароль:
    /// 1. Для пользователя создаётся соль — 16 случайных байт.
    /// 2. Считается SHA256 от (соль + пароль).
    /// 3. В файл пишутся только соль и хэш (в виде Base64).
    /// При входе хэш считается заново с той же солью и сравнивается с сохранённым.
    /// Узнать пароль по хэшу нельзя, а соль не даёт подобрать пароль
    /// по готовым таблицам хэшей и делает хэши одинаковых паролей разными.
    /// </summary>
    public static class AuthService
    {
        /// <summary>Минимальная длина пароля.</summary>
        public const int MinPasswordLength = 6;

        /// <summary>Логин администратора по умолчанию.</summary>
        public const string DefaultAdminLogin = "admin";

        /// <summary>Пароль администратора по умолчанию (записан в README).</summary>
        public const string DefaultAdminPassword = "admin123";

        /// <summary>Создаёт новую случайную соль (16 байт) в виде строки Base64.</summary>
        public static string CreateSalt()
        {
            byte[] salt = new byte[16];
            // RNGCryptoServiceProvider — криптографически стойкий генератор случайных чисел
            // (обычный Random для паролей не годится: его значения можно предсказать)
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        /// <summary>
        /// Считает хэш SHA256 от соли и пароля. Результат — строка Base64.
        /// </summary>
        public static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Склеиваем: сначала соль, потом пароль
            byte[] data = new byte[saltBytes.Length + passwordBytes.Length];
            Buffer.BlockCopy(saltBytes, 0, data, 0, saltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, data, saltBytes.Length, passwordBytes.Length);

            using (SHA256 sha = SHA256.Create())
            {
                return Convert.ToBase64String(sha.ComputeHash(data));
            }
        }

        /// <summary>
        /// Проверяет логин и пароль.
        /// Возвращает пользователя, если всё верно, иначе null.
        /// </summary>
        public static User Login(string login, string password)
        {
            User user = DataService.FindUserByLogin(login);
            if (user == null)
            {
                return null;
            }

            string hash = HashPassword(password, user.Salt);
            if (hash != user.PasswordHash)
            {
                return null;
            }
            return user;
        }

        /// <summary>
        /// Создаёт нового пользователя с указанной ролью и сохраняет его в users.xml.
        /// Проверки ввода (пустые поля, занятый логин, длина пароля) делает форма до вызова.
        /// </summary>
        public static User Register(string fullName, string login, string password, UserRole role)
        {
            User user = new User();
            user.Id = DataService.NextUserId();
            user.FullName = fullName;
            user.Login = login;
            user.Salt = CreateSalt();
            user.PasswordHash = HashPassword(password, user.Salt);
            user.Role = role;

            DataService.Users.Add(user);
            DataService.SaveUsers();
            return user;
        }

        /// <summary>
        /// Если в программе ещё нет ни одного пользователя (первый запуск),
        /// создаёт администратора admin / admin123.
        /// </summary>
        public static void EnsureDefaultAdmin()
        {
            if (DataService.Users.Count == 0)
            {
                Register("Главный администратор", DefaultAdminLogin, DefaultAdminPassword, UserRole.Администратор);
            }
        }
    }
}
