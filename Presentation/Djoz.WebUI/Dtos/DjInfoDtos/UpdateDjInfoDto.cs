using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.WebUI.Dtos.DjInfoDtos
{
    public class UpdateDjInfoDto
    {
        public int DjInfoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
