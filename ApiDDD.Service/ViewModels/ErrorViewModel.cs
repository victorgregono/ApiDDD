using System.Collections.Generic;

namespace ApiDDD.Application.ViewModels
{
    public class ErrorViewModel
    {
        public List<string> Errors { get; set; }

        public ErrorViewModel(List<string> erros) => Errors = erros;
    }
}