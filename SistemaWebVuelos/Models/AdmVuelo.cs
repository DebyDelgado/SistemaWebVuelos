using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SistemaWebVuelos.Models;
using SistemaWebVuelos.Data;

namespace SistemaWebVuelos.Models
{
    public static class AdmVuelo
    {
        private static VueloDbContext context = new VueloDbContext();
        public static List<Vuelo> Listar()
        {
            return context.Vuelos.ToList();
        }
        public static Vuelo Listar(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);
            context.Entry(vuelo).State = EntityState.Detached;
            return vuelo;
        }
        public static void Cargar(Vuelo vuelo)
        {
            context.Vuelos.Add(vuelo);
            context.SaveChanges();
        }
        public static void Modificar(Vuelo vuelo)
        {
            context.Vuelos.Attach(vuelo);
            context.Entry(vuelo).State = EntityState.Modified;
            context.SaveChanges();
        }
        public static void Borrar(Vuelo vuelo)
        {
            context.Vuelos.Attach(vuelo);
            context.Vuelos.Remove(vuelo);
            context.SaveChanges();
        }
        public static List<Vuelo> BuscarPorDestino(string destino)
        {
            var vuelo = (from v in context.Vuelos
                         where v.Destino == destino
                         select v).ToList();
            return vuelo;
        }
    }
}