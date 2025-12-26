using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Movies.Application.Models
{
    public class GetAllMoviesOptions
    {
        public required string? Title { get; set; }
        public required int? Year { get; set; }
        public string? SortField { get; set; }
        public SortOrder? SortOrder { get; set; }
        public Guid? userId { get; set; }
    }

    public enum SortOrder
    {
        Unsorted,
        Ascending,
        Descending
    }
}
