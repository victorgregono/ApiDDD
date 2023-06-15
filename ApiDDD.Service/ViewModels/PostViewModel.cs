using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Application.ViewModels
{
    public class PostViewModel
    {
        public long Id { get; set; }

        public PostViewModel(long id) => Id = id;
    }
}