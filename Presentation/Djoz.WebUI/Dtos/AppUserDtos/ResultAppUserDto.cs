using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.WebUI.Dtos.AppUserDtos
{
    public class ResultAppUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? PackageId { get; set; }
        public string PackageName { get; set; }

        [NotMapped]
        public string Username { get; set; }
    }
}
