document.addEventListener("DOMContentLoaded", function () {
    const themeToggleButton = document.getElementById("themeToggle");

    // Проверка, если сохранена тема в локальном хранилище
    const savedTheme = localStorage.getItem("theme");
    if (savedTheme === "dark") {
        document.documentElement.classList.add("dark-theme");
    }

    // Обработчик для переключения темы
    themeToggleButton.addEventListener("click", function () {
        if (document.documentElement.classList.contains("dark-theme")) {
            document.documentElement.classList.remove("dark-theme");
            localStorage.setItem("theme", "light");
        } else {
            document.documentElement.classList.add("dark-theme");
            localStorage.setItem("theme", "dark");
        }

    console.log(document.documentElement.classList.contains("dark-theme"));

    });
});
