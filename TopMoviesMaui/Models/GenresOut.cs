﻿using System.Runtime.Serialization;

namespace TopMoviesMaui.Detail
{
    [DataContract]
    public class GenresOut
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }

        [DataMember(Name = "name")]
        public string Name { get; private set; }
    }
}