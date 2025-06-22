﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Application.Dtos.SongDtos
{
    public class UpdateSongDto
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string Singer { get; set; }
        public IFormFile? SongFile { get; set; }
        public string? SongUrl { get; set; } //mevcut dosya yolu
    }
}
