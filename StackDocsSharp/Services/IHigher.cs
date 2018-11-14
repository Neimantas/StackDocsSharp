using StackDocsSharp.Models.BL;
using StackDocsSharp.Models.Const;
using System.Collections.Generic;

namespace StackDocsSharp.Services
{
    public interface IHigher
    {
        List<string> GetTopicsList();

        List<BLTopics> GetTopics(params CrudArgs[] args);

        string ConcatExamplesByTopicId(string id);
    }
}