using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Muhammed.Models;

namespace Muhammed.Services
{
    /// <summary>
    /// Хранит все данные программы (меню и заказы) и сохраняет их в XML-файлы.
    /// Класс статический: данные одни на всю программу, и любая форма
    /// может обратиться к ним через DataService.Dishes и DataService.Orders.
    /// </summary>
    public static class DataService
    {
        /// <summary>Список блюд меню.</summary>
        public static List<Dish> Dishes = new List<Dish>();

        /// <summary>Список всех заказов.</summary>
        public static List<Order> Orders = new List<Order>();

        /// <summary>Список пользователей программы.</summary>
        public static List<User> Users = new List<User>();

        /// <summary>Папка с файлами данных: «Data» рядом с exe (bin\Debug\Data).</summary>
        private static string DataFolder
        {
            get { return Path.Combine(Application.StartupPath, "Data"); }
        }

        /// <summary>Полный путь к файлу меню.</summary>
        private static string MenuFile
        {
            get { return Path.Combine(DataFolder, "menu.xml"); }
        }

        /// <summary>Полный путь к файлу заказов.</summary>
        private static string OrdersFile
        {
            get { return Path.Combine(DataFolder, "orders.xml"); }
        }

        /// <summary>Полный путь к файлу пользователей.</summary>
        private static string UsersFile
        {
            get { return Path.Combine(DataFolder, "users.xml"); }
        }

        /// <summary>
        /// Загружает меню, заказы и пользователей из файлов. Вызывается один раз при запуске программы.
        /// Если файла меню ещё нет (первый запуск), создаётся стартовое меню.
        /// (Первого администратора создаёт AuthService.EnsureDefaultAdmin().)
        /// </summary>
        public static void Load()
        {
            if (File.Exists(MenuFile))
            {
                Dishes = LoadList<Dish>(MenuFile);
            }
            else
            {
                Dishes = CreateDefaultMenu();
                SaveMenu();
            }

            Orders = LoadList<Order>(OrdersFile);
            Users = LoadList<User>(UsersFile);
        }

        /// <summary>Сохраняет пользователей в файл users.xml.</summary>
        public static void SaveUsers()
        {
            SaveList(UsersFile, Users);
        }

        /// <summary>Возвращает номер для нового пользователя: самый большой номер + 1.</summary>
        public static int NextUserId()
        {
            int maxId = 0;
            foreach (User user in Users)
            {
                if (user.Id > maxId)
                {
                    maxId = user.Id;
                }
            }
            return maxId + 1;
        }

        /// <summary>
        /// Ищет пользователя по логину без учёта регистра букв («Admin» = «admin»).
        /// Если не найден — возвращает null.
        /// </summary>
        public static User FindUserByLogin(string login)
        {
            foreach (User user in Users)
            {
                if (string.Equals(user.Login, login, StringComparison.OrdinalIgnoreCase))
                {
                    return user;
                }
            }
            return null;
        }

        /// <summary>Сохраняет меню в файл menu.xml.</summary>
        public static void SaveMenu()
        {
            SaveList(MenuFile, Dishes);
        }

        /// <summary>Сохраняет заказы в файл orders.xml.</summary>
        public static void SaveOrders()
        {
            SaveList(OrdersFile, Orders);
        }

        /// <summary>Возвращает номер для нового блюда: самый большой номер + 1.</summary>
        public static int NextDishId()
        {
            int maxId = 0;
            foreach (Dish dish in Dishes)
            {
                if (dish.Id > maxId)
                {
                    maxId = dish.Id;
                }
            }
            return maxId + 1;
        }

        /// <summary>Возвращает номер для нового заказа: самый большой номер + 1.</summary>
        public static int NextOrderId()
        {
            int maxId = 0;
            foreach (Order order in Orders)
            {
                if (order.Id > maxId)
                {
                    maxId = order.Id;
                }
            }
            return maxId + 1;
        }

        /// <summary>Ищет заказ по номеру. Если не найден — возвращает null.</summary>
        public static Order FindOrder(int id)
        {
            foreach (Order order in Orders)
            {
                if (order.Id == id)
                {
                    return order;
                }
            }
            return null;
        }

        /// <summary>Ищет блюдо по номеру. Если не найдено — возвращает null.</summary>
        public static Dish FindDish(int id)
        {
            foreach (Dish dish in Dishes)
            {
                if (dish.Id == id)
                {
                    return dish;
                }
            }
            return null;
        }

        /// <summary>
        /// Читает список объектов типа T из XML-файла.
        /// T — это Dish, Order или User (обобщённый метод, чтобы не писать код дважды).
        /// Если файла нет — возвращает пустой список.
        /// Если файл повреждён — делает его копию *.bad, сообщает об ошибке
        /// и возвращает пустой список (программа не падает).
        /// </summary>
        private static List<T> LoadList<T>(string path)
        {
            if (!File.Exists(path))
            {
                return new List<T>();
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                using (StreamReader reader = new StreamReader(path))
                {
                    List<T> list = (List<T>)serializer.Deserialize(reader);
                    if (list == null)
                    {
                        return new List<T>();
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                // Сохраняем копию испорченного файла, чтобы данные не потерялись окончательно
                string badCopy = path + ".bad";
                try
                {
                    File.Copy(path, badCopy, true);
                }
                catch
                {
                    // Если копию сделать не удалось — просто продолжаем
                }

                MessageBox.Show(
                    "Не удалось прочитать файл:\n" + path +
                    "\n\nПричина: " + ex.Message +
                    "\n\nКопия файла сохранена как:\n" + badCopy +
                    "\n\nПрограмма продолжит работу с пустым списком.",
                    "Ошибка загрузки данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return new List<T>();
            }
        }

        /// <summary>
        /// Записывает список объектов в XML-файл.
        /// Если папки Data нет — создаёт её.
        /// </summary>
        private static void SaveList<T>(string path, List<T> list)
        {
            try
            {
                Directory.CreateDirectory(DataFolder);

                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                using (StreamWriter writer = new StreamWriter(path))
                {
                    serializer.Serialize(writer, list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось сохранить файл:\n" + path + "\n\nПричина: " + ex.Message,
                    "Ошибка сохранения данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Стартовое меню, которое создаётся при самом первом запуске.
        /// </summary>
        private static List<Dish> CreateDefaultMenu()
        {
            List<Dish> menu = new List<Dish>();
            menu.Add(new Dish { Id = 1, Name = "Борщ", Category = "Супы", Price = 250 });
            menu.Add(new Dish { Id = 2, Name = "Солянка", Category = "Супы", Price = 290 });
            menu.Add(new Dish { Id = 3, Name = "Цезарь с курицей", Category = "Салаты", Price = 320 });
            menu.Add(new Dish { Id = 4, Name = "Пельмени", Category = "Горячее", Price = 280 });
            menu.Add(new Dish { Id = 5, Name = "Блины со сметаной", Category = "Десерты", Price = 180 });
            menu.Add(new Dish { Id = 6, Name = "Чай чёрный", Category = "Напитки", Price = 80 });
            menu.Add(new Dish { Id = 7, Name = "Капучино", Category = "Напитки", Price = 150 });
            return menu;
        }
    }
}
