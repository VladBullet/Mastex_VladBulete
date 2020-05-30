using System;
using System.Collections.Generic;
using System.Text;
using Mastex_BuleteVlad.DAL.Models;
using Mastex_VladBulete.BLL.DTO;
using Newtonsoft.Json;

namespace Mastex_VladBulete.BLL.Helpers
{
    public static class MappingExtensions
    {
        public static R ToDto<T, R>(this T th) where T : class, IModel where R : class, IDto
        {
            var serialized = JsonConvert.SerializeObject(th);
            var deserialized = JsonConvert.DeserializeObject<R>(serialized);
            return deserialized;
        }


    }
}
