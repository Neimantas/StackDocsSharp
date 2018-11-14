using StackDocsSharp.Models.Const;
using StackDocsSharp.Models.DAL;
using System.Collections.Generic;

namespace StackDocsSharp.Services
{
    public interface ILower
    {
        List<DALTopics> ReadDALTopics(params CrudArgs[] args);

        List<DALDoctags> ReadDALDoctags(params CrudArgs[] args);

        List<DALExamples> ReadDALExamples(params CrudArgs[] args);
    }
}