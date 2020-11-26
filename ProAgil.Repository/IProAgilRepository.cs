using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        //Geral
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
       
        Task<bool> SaveChangeAsync();
        
        
        //Eventos
        Task<Evento[]> GetAllEventoByTemaAsync(string tema, bool includePalestrante);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrante);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrante);
        
        //Palestrante
        Task<Palestrante[]> GetAllPalestranteByNameAsync(string name, bool includeEvento);
        Task<Palestrante> GetPalestranteAsync(int palestranteId, bool includeEvento);
    }
}