using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.WebUI.Dtos.SongDtos
{
    public class PlaySongRequestDto
    {
        public string SongUrl { get; set; }
        public string Token { get; set; }
    }
}
