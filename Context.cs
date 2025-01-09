using Microsoft.EntityFrameworkCore;
using KSPBD_Rulit.Models;

namespace KSPBD_Rulit
{
    public class Context : DbContext
    {
        public DbSet<ВидПериода> ВидПериода { get; set; }
        public DbSet<ВидРабот> ВидРабот { get; set; }
        public DbSet<ЕИ> ЕИ { get; set; }
        public DbSet<Объект> Объект { get; set; }
        public DbSet<Период> Период { get; set; }
        public DbSet<ПланРабот> ПланРабот { get; set; }
        public DbSet<Подраздел> Подраздел { get; set; }
        public DbSet<Помещение> Помещение { get; set; }
        public DbSet<Раздел> Раздел { get; set; }
        public DbSet<Секция> Секция { get; set; }
        public DbSet<Этаж> Этаж { get; set; }
        public DbSet<Пользователь> Пользователи { get; set; }


        public DbSet<СправочникАдресов> СправочникАдресов { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

    }
}

