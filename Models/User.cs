namespace Muhammed.Models
{
    /// <summary>
    /// Пользователь программы.
    /// Пароль открытым текстом НЕ хранится: в файле лежат только соль и хэш.
    /// Для XmlSerializer нужен публичный конструктор без параметров
    /// и публичные свойства с get; set; (конструктор создаётся автоматически).
    /// </summary>
    public class User
    {
        /// <summary>Уникальный номер пользователя.</summary>
        public int Id { get; set; }

        /// <summary>ФИО, например «Иванов Иван Иванович».</summary>
        public string FullName { get; set; }

        /// <summary>Логин для входа (без учёта регистра букв).</summary>
        public string Login { get; set; }

        /// <summary>Хэш SHA256 от «соль + пароль» в виде строки Base64.</summary>
        public string PasswordHash { get; set; }

        /// <summary>Соль: случайные байты в виде строки Base64. У каждого пользователя своя.</summary>
        public string Salt { get; set; }

        /// <summary>Роль: Администратор или Сотрудник.</summary>
        public UserRole Role { get; set; }
    }
}
