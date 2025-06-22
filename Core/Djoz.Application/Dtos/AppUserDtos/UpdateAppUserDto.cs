using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Dtos.AppUserDtos
{
    public class UpdateAppUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int ? PackageId { get; set; }
    }
}
