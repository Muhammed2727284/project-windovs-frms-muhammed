# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Проект

Учебный (университетский) проект «Учёт заказов кафе». Windows Forms, **.NET Framework 4.7.2** (не .NET Core / .NET 5+). Пространство имён — `Muhammed`. Полный исходный текст задания от пользователя лежит в `ЗАДАНИЕ.md`. Требования бери оттуда, план — из `PLAN.md`.

## Сборка

```sh
"/c/Program Files/Microsoft Visual Studio/18/Community/MSBuild/Current/Bin/MSBuild.exe" Muhammed.csproj -nologo -v:minimal
```

Результат сборки: `bin\Debug\Muhammed.exe`. Тестовых проектов нет. Проверяет пользователь вручную в программе по тестам из PLAN.md.

## Порядок работы (обязательно)

1. В начале каждого сеанса прочитай `PLAN.md` и продолжай с первого шага со статусом `[ ]`.
2. Выполняй **строго один шаг** за раз и не забегай вперёд.
3. После шага собери проект и исправь все ошибки.
4. Затем напиши пользователю, что сделано и как это проверить в программе (по пункту «Как проверить» из плана).
5. Жди, пока пользователь напишет «дальше». Только после этого отметь шаг в `PLAN.md` как `[x]` и переходи к следующему.

## Технические правила

- **Старый формат csproj.** Каждый новый файл нужно вручную добавить в `Muhammed.csproj`:
  - для формы: `<Compile Include="Forms\X.cs"><SubType>Form</SubType></Compile>`;
  - для страницы (`UserControl`): `<Compile Include="Forms\X.cs"><SubType>UserControl</SubType></Compile>`;
  - для обычного класса: `<Compile Include="UI\X.cs" />`;
  - для дизайнера: `<Compile Include="Forms\X.Designer.cs"><DependentUpon>X.cs</DependentUpon></Compile>`;
  - для ресурсов: `<EmbeddedResource Include="Forms\X.resx"><DependentUpon>X.cs</DependentUpon></EmbeddedResource>`.

  Если файл не добавить, он не скомпилируется.
- **C# 7.3.** Нельзя использовать `new()` без типа, nullable reference types, records, switch-выражения, `using var`, диапазоны и индексы (`^1`, `..`), `init`.
- Только стандартная библиотека .NET Framework. Без NuGet и сторонних библиотек.
- **У каждой формы есть `.Designer.cs`**, и элементы управления создаются в `InitializeComponent()` в стиле, который понимает конструктор VS: поля `private`, `this.x = new ...`, `SuspendLayout`/`ResumeLayout`, без лямбд и циклов. Обработчики событий пиши в основном `.cs` файле.
- Структура папок:
  - `Models/` — классы данных: `Dish`, `Order`, `OrderItem`, `DailyReport`, `User`, перечисления `OrderStatus` и `UserRole`;
  - `Services/` — работа с файлами (`DataService`, XmlSerializer), логика (`OrderService` — фильтр, `ReportService` — отчёт), `AuthService` (вход, регистрация, хэш паролей) и `CurrentUser` (сессия: кто вошёл);
  - `UI/` — `Theme`: цвета, шрифты и методы оформления;
  - `Forms/` — формы (`LoginForm`, `RegisterForm`, `MainForm`, `MenuForm`, `DishEditForm`, `OrderForm`, `ReportForm`, `UsersForm`) и страницы главного окна (`OrdersPage`, `MenuViewPage`, `AdminPage` — это `UserControl`).
- **Главное окно.** `MainForm` — это рамка: верхняя панель, боковое меню и `pnlContent`. Метод `ShowPage(page, button)` кладёт страницу в `pnlContent` и подсвечивает пункт меню. Новый раздел = новый `UserControl` + кнопка в боковом меню.
- **Оформление только через `Theme`.** Цвета и шрифты вручную в формах не задаём. В конструкторе после `InitializeComponent()` вызываем `Theme.ApplyToForm(this)` (для страниц `Theme.ApplyToPage(this)`), затем при необходимости `StylePrimaryButton`, `StyleDangerButton`, `StyleHeader`, `StyleMuted`, `SetIcon(button, Theme.IconXxx)` (иконки — символы шрифта Segoe MDL2 Assets), `StyleTileButton`, `EnableStatusBadges`. Скруглённые кнопки, поля, карточки (GroupBox) и пункты меню рисуются в обработчиках `Paint` внутри `Theme`, поэтому `Button.Tag` занят иконкой, а подписи (`Label`) делаются прозрачными. Базовый шрифт — Segoe UI 9: если его поменять, WinForms пересчитает размеры элементов (`AutoScaleMode.Font`).
- **Роли.** `Администратор` и `Сотрудник`. Права проверяются через `CurrentUser.IsAdmin`: кнопки сотрудника скрываются, а окна только для админа (`MenuForm`, `ReportForm`, `UsersForm`) проверяют права ещё раз в `OnLoad`. Сотрудник создаёт и меняет заказы, меняет статус. Меню, отчёт, пользователи и удаление заказов доступны только администратору.
- **Пароли.** Открытым текстом не храним. В `User` лежат `Salt` (16 случайных байт, `RNGCryptoServiceProvider`) и `PasswordHash` = SHA256(соль + пароль), обе строки в Base64. При первом запуске `AuthService.EnsureDefaultAdmin()` создаёт `admin` / `admin123`.
- Данные хранятся в XML через `XmlSerializer`: файлы `Data\menu.xml`, `Data\orders.xml` и `Data\users.xml` рядом с exe (`Application.StartupPath`). Загрузка при запуске в `Program.cs`, сохранение после каждого изменения. У сериализуемых классов должны быть публичный конструктор без параметров и публичные свойства с `get; set;`.
- В `OrderItem` хранится **копия** названия и цены блюда, поэтому изменение меню не меняет старые заказы. Выручка в отчёте — сумма только заказов со статусом «Оплачен».
- Каждый ввод проверяется: пустые поля, цена (число > 0), количество, номер стола, логин (не занят, без учёта регистра), пароль (не короче 6 символов, повтор совпадает). Ошибки показываются через `MessageBox`.
- Интерфейс, сообщения и комментарии — на русском. Код простой, без лишних абстракций, понятный студенту, с комментариями к каждому методу и неочевидным местам.
