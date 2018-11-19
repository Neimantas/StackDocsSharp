using StackDocsSharp.Models.Const;
using StackDocsSharp.Models.DAL;
using System.Collections.Generic;

namespace StackDocsSharp.Services
{
    public interface ILower
    {
        List<DALTopics> ReadDALTopics(List<CrudArgs> args);

        List<DALDoctags> ReadDALDoctags(List<CrudArgs> args);

        List<DALExamples> ReadDALExamples(List<CrudArgs> args);
    }
}