using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Services
{
    public enum Errors
    {
        //ASP error code
        
        out_of_memory = 0100,
        unexpected_error = 0101,
        expecting_string_input = 0102,
        expecting_numeric_input = 0103,
        operation_not_allowed = 0104,
        index_out_of_range = 0105,
        type_mismatch = 0107,
        stack_overflow = 0108

        /*
         *   https://blogs.msdn.microsoft.com/deva/2009/06/25/error-code-list-of-asp-error-codes-its-description/
         */
    }
}