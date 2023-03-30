﻿using Microsoft.EntityFrameworkCore;

namespace wedApi_join.Model
{
    public class equiposContext : DbContext
    {
        public equiposContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<equipos> equipos { get; set; }
        public DbSet<estados_equipo> estados_equipo { get; set; }
        public DbSet<marcas> marcas { get; set; }
        public DbSet<tipo_equipo> tipo_equipo { get; set; }
    }
}
