using ApiCoreCrudDepartamentos.Data;
using ApiCoreCrudDepartamentos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudDepartamentos.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;
        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }
        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }
        public async Task<Departamento> FindDepartamentoAsync(int id)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(z => z.IdDepartamento == id);
        }
        public async Task InsertarDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = id;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            this.context.Departamentos.Add(departamento);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdateDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamento depa = await this.FindDepartamentoAsync(id);
            depa.Nombre = nombre;
            depa.Localidad = localidad;
            await this.context.SaveChangesAsync();
        }
        public async Task DeleteDepartamentoAsync(int id)
        {
            Departamento depar = await this.FindDepartamentoAsync(id);
            this.context.Departamentos.Remove(depar);
            await this.context.SaveChangesAsync();
        }
    }
}
