﻿using StackDocsSharp.Models.BL;
using StackDocsSharp.Models.Const;
using StackDocsSharp.Models.DAL;
using System.Collections.Generic;

namespace StackDocsSharp.Services
{
    public interface IHigher
    {
        List<string> GetTopicsList();

        List<BLTopics> GetTopics(List<CrudArgs> args);
    }
}