using Application.bbdd.Entities.Interfaces;
using EntityFramework.DynamicFilters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.bbdd.Filters
{
    public class SoftDeleleteFilter
    {
        public const string FILTER_NAME = "SOFT_DELETE_FILTER";

        public static void AddFilter(ref DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter(FILTER_NAME, (ISoftDelete e) => e.Deleted ,false);
        }
    }
}
