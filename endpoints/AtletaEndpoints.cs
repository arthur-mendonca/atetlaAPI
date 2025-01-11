using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atetlaAPI.dtos;
using atetlaAPI.models;
using AtetlaAPI.models;
using Microsoft.EntityFrameworkCore;

namespace AtetlaAPI.endpoints
{
    public static class AtletaEndpoints
    {
        private static readonly AtletaContext db = new AtletaContext();

        public static void GerenciarAtleta(this WebApplication app)
        {
            var grupo = app.MapGroup("/atletas");

            grupo.MapGet("/", GetAsync);
            grupo.MapGet("/{id}", GetByIdAsync);
            grupo.MapPost("/", PostAsync);
            grupo.MapPut("/{id}", PutAsync);
            grupo.MapDelete("/{id}", DeleteAsync);
        }

        private static async Task<IResult> GetAsync(AtletaContext db)
        {
            var atletas = await db.Atletas.ToListAsync();
            return TypedResults.Ok(atletas.Select(a => new AtletaDTO(a)));
        }

        private static async Task<IResult> GetByIdAsync(string id, AtletaContext db)
        {
            var atleta = await db.Atletas.FindAsync(Convert.ToInt64(id));
            return atleta != null ? TypedResults.Ok(new AtletaDTO(atleta)) : TypedResults.NotFound();
        }

        private static async Task<IResult> PostAsync(AtletaDTO dto, AtletaContext db)
        {
            Atleta atleta = dto.GetModel();
            atleta.Id = GeradorId.GetId();

            await db.Atletas.AddAsync(atleta);
            await db.SaveChangesAsync();

            return TypedResults.Created($"/atletas/{atleta.Id}", new AtletaDTO(atleta));
        }

        private static async Task<IResult> PutAsync(string id, AtletaDTO dto, AtletaContext db)
        {
            if (id != dto.Id) return TypedResults.BadRequest();

            var existingAtleta = await db.Atletas.FindAsync(Convert.ToInt64(id));
            if (existingAtleta == null) return TypedResults.NotFound();

            dto.PreencherModel(existingAtleta);

            db.Atletas.Update(existingAtleta);
            await db.SaveChangesAsync();
            return TypedResults.NoContent();
        }


        private static async Task<IResult> DeleteAsync(string id, AtletaContext db)
        {
            var existingAtleta = await db.Atletas.FindAsync(Convert.ToInt64(id));
            if (existingAtleta == null) return TypedResults.NotFound();

            db.Atletas.Remove(existingAtleta);
            await db.SaveChangesAsync();
            return TypedResults.NoContent();
        }
    }
}
