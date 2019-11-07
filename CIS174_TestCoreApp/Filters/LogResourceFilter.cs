using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filters
{
    public class LogResourceFilter : Attribute, IResourceFilter, IOrderedFilter
    {
        public int Order => -1;

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Debug.WriteLine("Tori - LogSource Filter Executed");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Debug.WriteLine("Tori - LogSource Filter Executing");
        }
    }
}
