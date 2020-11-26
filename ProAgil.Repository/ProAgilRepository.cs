using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        public readonly ProAgilContext _Context;
        
        public ProAgilRepository(ProAgilContext context)
        {
            _Context = context;
            _Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        public void Add<T>(T entity) where T : class
        {
            _Context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _Context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _Context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _Context.SaveChangesAsync() > 0;
        }

        //Evento
        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = _Context.Eventos.Include(c => c.Lotes)
                .Include(c => c.RedesSociais);
            if (includePalestrante)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(o => o.DataEvento);

            return await query.ToArrayAsync();

        }

        public async Task<Evento[]> GetAllEventoByTemaAsync(string tema, bool includePalestrante=false)
        {
            IQueryable<Evento> query = _Context.Eventos.Include(c => c.Lotes)
                .Include(c => c.RedesSociais);
            if (includePalestrante)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(o => o.DataEvento).Where(c=>c.Tema.ToUpper().Contains(tema.ToUpper()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante=false)
        {
            IQueryable<Evento> query = _Context.Eventos.Include(c => c.Lotes)
                .Include(c => c.RedesSociais);
            if (includePalestrante)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(o => o.DataEvento).Where(c=>c.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        //Palestrante
        public async Task<Palestrante[]> GetAllPalestranteByNameAsync(string name, bool includeEvento=false)
        {
            IQueryable<Palestrante> query = _Context.Palestrantes.Include(c => c.RedesSociais);
            if (includeEvento)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                    .ThenInclude(p => p.Evento);
            }

            query = query.Where(c=>c.Nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteAsync(int palestranteId, bool includeEvento=false)
        {
            IQueryable<Palestrante> query = _Context.Palestrantes.Include(c => c.RedesSociais);
            if (includeEvento)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                    .ThenInclude(p => p.Evento);
            }

            query = query.OrderBy(o => o.Nome).Where(c=>c.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}