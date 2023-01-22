using System.Collections.Generic;

namespace Store.Application.Models
{
    public class PagedListViewModel<TViewModel> where TViewModel : class
    {
        public IEnumerable<TViewModel> Data { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
    }
}
