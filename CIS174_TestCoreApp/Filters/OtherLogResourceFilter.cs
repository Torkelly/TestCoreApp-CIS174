using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Filters
{
    public class OtherLogResourceFilter : Attribute, IResourceFilter, IOrderedFilter
    {
        public int Order => 0;

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Debug.WriteLine("Other - LogSource Filter Executed");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Debug.WriteLine("Other - LogSource Filter Executing");

        }
    }
}
