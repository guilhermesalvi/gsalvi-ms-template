using System.Collections.Generic;

namespace GSalvi.Template.Api.Controllers.Responses
{
    public sealed class Response<TData>
    {
        public bool Succeeded { get; set; }
        public TData Data { get; set; }
        public IEnumerable<ResponseError> Errors { get; set; }
    }
}
