using Muhammed.Models;

namespace Muhammed.Services
{
    /// <summary>
    /// Сессия: кто сейчас вошёл в программу.
    /// Класс статический, поэтому любая форма может узнать
    /// текущего пользователя и его роль, например: if (CurrentUser.IsAdmin) ...
    /// </summary>
    public static class CurrentUser
    {
        /// <summary>Вошедший пользователь (null — никто не вошёл).</summary>
        public static User User { get; private set; }

        /// <summary>true, если вошёл администратор.</summary>
        public static bool IsAdmin
        {
            get { return User != null && User.Role == UserRole.Администратор; }
        }

        /// <summary>Запоминает пользователя после успешного входа.</summary>
        public static void SignIn(User user)
        {
            User = user;
        }

        /// <summary>Выход: забываем пользователя.</summary>
        public static void SignOut()
        {
            User = null;
        }
    }
}
