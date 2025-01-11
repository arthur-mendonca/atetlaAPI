using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atetlaAPI.models;
using AtetlaAPI.models;

namespace AtetlaAPI.endpoints
{
    public static class AtletaEndpoints
    {
        private static readonly AtletaContext db = new AtletaContext();

        public static void GerenciarAtleta(this WebApplication app)
        {
            app.MapGet("/atletas", Get);
            app.MapGet("/atletas/{id}", GetById);
            app.MapPost("/atletas", Post);
            app.MapPut("/atletas/{id}", Put);
            app.MapDelete("/atletas/{id}", Delete);
        }

        private static IResult Get(AtletaContext db)
        {
            var atletas = db.Atletas.ToList();
            return atletas != null ? TypedResults.Ok(atletas) : TypedResults.NotFound();
        }

        private static IResult GetById(long id, AtletaContext db)
        {
            var atleta = db.Atletas.Find(id);
            return atleta != null ? TypedResults.Ok(atleta) : TypedResults.NotFound();
        }

        private static IResult Post(Atleta atleta, AtletaContext db)
        {
            atleta.Id = GeradorId.GetId();
            db.Atletas.Add(atleta);
            db.SaveChanges();
            return TypedResults.Created($"/atletas/{atleta.Id}", atleta);
        }

        private static IResult Put(long id, Atleta atleta, AtletaContext db)
        {
            if (id != atleta.Id) return TypedResults.BadRequest();

            var existingAtleta = db.Atletas.Find(id);
            if (existingAtleta == null) return TypedResults.NotFound();

            existingAtleta.Nome = atleta.Nome;
            existingAtleta.Altura = atleta.Altura;
            existingAtleta.Peso = atleta.Peso;

            db.Atletas.Update(existingAtleta);
            db.SaveChanges();
            return TypedResults.NoContent();
        }


        private static IResult Delete(long id, AtletaContext db)
        {
            var existingAtleta = db.Atletas.Find(id);
            if (existingAtleta == null) return TypedResults.NotFound();

            db.Atletas.Remove(existingAtleta);
            db.SaveChanges();
            return TypedResults.NoContent();
        }
    }
}
