#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GitScraping.Application.Bases;
using Octokit;

#endregion

namespace GitScraping.Application.Dtos.AirplaneDtos
{
    public class AirplaneDto : EntityDto
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Sha { get; set; }
        public int Size { get; set; }
        public string Url { get; set; }
        public StringEnum<ContentType> Type { get; set; }
    }
}