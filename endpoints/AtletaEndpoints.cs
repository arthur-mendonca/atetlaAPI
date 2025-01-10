using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtetlaAPI.models;

namespace AtetlaAPI.endpoints
{
    public static class AtletaEndpoints
    {
        private static readonly IList<Atleta> objetos;
        static AtletaEndpoints()
        {
            objetos = [];
        }

        public static void AdicionarAtletaEndpoint(this WebApplication app)
        {
            app.MapGet("/atletas", Get);
            app.MapGet("/atletas/{id}", GetById);
            app.MapPost("/atletas", Post);
            app.MapPut("/atletas/{id}", Put);
            app.MapDelete("/atletas/{id}", Delete);
        }

        private static IResult Get()
        {
            return objetos != null ? TypedResults.Ok(objetos) : TypedResults.NotFound();
        }

        private static IResult GetById(long id)
        {
            var obj = objetos.FirstOrDefault(x => x.Id == id);

            if (obj == null) return TypedResults.NotFound();

            return TypedResults.Ok(obj);
        }

        private static IResult Post(Atleta atleta)
        {
            atleta.Id = (objetos.MaxBy(x => x.Id) ?? new Atleta()).Id + 1;
            objetos.Add(atleta);

            return TypedResults.Created($"atletas/{atleta.Id}", atleta);
        }

        private static IResult Put(long id, Atleta atleta)
        {
            if (id != atleta.Id) return TypedResults.BadRequest();

            var obj = objetos.FirstOrDefault(x => x.Id == id);

            if (obj == null) return TypedResults.NotFound();

            obj.Nome = atleta.Nome;
            obj.Altura = atleta.Altura;
            obj.Peso = atleta.Peso;

            return TypedResults.NoContent();
        }


        private static IResult Delete(long id)
        {
            var obj = objetos.FirstOrDefault(x => x.Id == id);

            if (obj == null) return TypedResults.NotFound();

            objetos.Remove(obj);

            return TypedResults.NoContent();
        }
    }
}
