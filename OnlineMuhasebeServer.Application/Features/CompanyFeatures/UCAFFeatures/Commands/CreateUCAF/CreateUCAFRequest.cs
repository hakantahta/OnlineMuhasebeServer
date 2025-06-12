using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public sealed class CreateUCAFRequest : IRequest<CreateUCAFResponse>
    {
        public String Code { get; set; }
        public String Name { get; set; }
        public Char Type { get; set; }
        public String CompanyId { get; set; }
    }
}
