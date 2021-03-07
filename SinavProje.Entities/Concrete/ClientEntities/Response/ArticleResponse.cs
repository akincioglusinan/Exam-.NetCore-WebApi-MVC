using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SinavProje.Entities.Concrete.ClientEntities.Response
{
    public class ArticleResponse
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
